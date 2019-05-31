using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.IO;
using System.Data.Entity.Infrastructure.Interception;
using System.Transactions;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Threading;

namespace EFTutorial
{
    public partial class Model1Container
    {
        static Model1Container()
        {
            DbInterception.Add(new NLogCommandInterceptor());
            Database.SetInitializer<Model1Container>(new CreateDatabaseIfNotExists<Model1Container>());
            //Работает только в CodeFirst
            //Database.SetInitializer<Model1Container>(new MigrateDatabaseToLatestVersion<Model1Container, Migrations.Configuration>(true, new Migrations.Configuration()));
        }

        private void DefaultLogger(string message)
        {
            using (TextWriter log = File.CreateText("LOG.txt"))
            {
                log.WriteAsync(message);
            }
        }

        public override int SaveChanges()
        {
            int result = 0;

            //Запучтить сохранеение с использованием транзакции
            try
            {
                result = SaveChangesInTransaction();
            }
            catch (InvalidOperationException ex)
            {
                //Если InvalidOperationException - запустить метод без транзакции
                result = SaveChangesWithoutTransaction();
                //InvalidOperationException возникнет в случае использования стратегии без поддержки поьзовательских транзакций
            }
            return result;    
        }

        private int SaveChangesWithoutTransaction()
        {
            int result = 0;

            result = SaveChangesFullData();

            return result;
        }
        private int SaveChangesInTransaction()
        {
            int result = 0;
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
#if DEBUG
                    Console.WriteLine(Transaction.Current);
#endif
                    result = SaveChangesFullData();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("ERROR!!! Does not saved:");
                    foreach (var entry in ex.Entries)
                    {
                        Console.WriteLine(entry);
                    }
                }
                transaction.Complete();
            }
            return result;
        }
        private int SaveChangesFullData()
        {
            int result = 0;
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    result = base.SaveChanges();
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    var entry = ex.Entries.Single(); //Перезагрузка исходного значения свойства сущности с БД для решения проблемы оптимистичного параллелизма.
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues()); 
                }
            }while (saveFailed) ;

            return result;
        }

        async private Task<int> SaveChangesAsyncTryInTransaction()
        {
            int result = 0;
            try
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await SaveChangesFullDataAsync(); //Метод сам вызовет операции во вторичном потоке
                    transaction.Complete();
                }
            }
            catch (InvalidOperationException)
            {
                result = await SaveChangesFullDataAsync(); //Метод сам вызовет операции во вторичном потоке
            }

            return result;
        }

        async private Task<int> SaveChangesFullDataAsync()
        {
            int result = 0;
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    result = await base.SaveChangesAsync(); //Метод сам вызовет операции во вторичном потоке
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    var entry = ex.Entries.Single(); //Перезагрузка исходного значения свойства сущности с БД для решения проблемы оптимистичного параллелизма. Приоритет клиента
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }
            } while (saveFailed);

            return result;
        }

        public override Task<int> SaveChangesAsync()
        {
            return this.SaveChangesAsyncTryInTransaction();
        }
    }
}
