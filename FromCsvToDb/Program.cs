using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Transactions;
using System.Data.Entity;
using System.Threading;

namespace AddUsersApp
{
    class Program
    {
        static int SareaId { get; } = 999; 
        static List<Users> users = new List<Users>();
        static void Main(string[] args)
        {
            Console.WriteLine($"Start time: {DateTime.Now}");

            users = ReadCsvUsers(@"D:\data.csv").ToList<Users>();
            Console.WriteLine($"Table Users count {users.Count}");

            int count = AddUsers(users);
            Console.WriteLine($"Data added. Count = {count}");

            Console.WriteLine($"End time: {DateTime.Now}");
            Console.ReadLine();
        }

        static IEnumerable<Users> ReadCsvUsers(string path)
        {
            IEnumerable<Users> result;
            using (StreamReader reader = new StreamReader(path, Encoding.GetEncoding("windows-1251")))
            {
                using (CsvReader csvReader = new CsvReader(reader))
                {
                    csvReader.Configuration.Delimiter = ";";
                    
                    result = csvReader.GetRecords<Users>().ToList();
                }
            }
            return result;
        }

        static int AddUsers(IEnumerable<Users> users)
        {
            int result = 0;
            //using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel=IsolationLevel.ReadCommitted, Timeout=TransactionManager.MaximumTimeout}))
            //{
            using (var ctx = new MainGetonEntities())
            {
                long countProcessedItems = 0;
                using (var dbContextTransaction = ctx.Database.BeginTransaction())
                {
                    ctx.Database.ExecuteSqlCommand("SELECT TOP (1) IdUser FROM Users WITH (TABLOCKX, HOLDLOCK)"); //блокировка таблицы для ЛЮБЫХ операций (включая чтения) до завршение транзакции
                    int nextId = ctx.Users.Where(u => u.SareaId == Program.SareaId).Max(u => u.IdUser) + 1;
                    foreach (var user in users)
                    {
                        //using (var dbContextTransaction = ctx.Database.BeginTransaction())
                        //{
                        //    ctx.Database.ExecuteSqlCommand("SELECT TOP (1) IdUser FROM Users WITH (TABLOCKX, HOLDLOCK)"); //блокировка таблицы для ЛЮБЫХ операций (включая чтения) до завршение транзакции
                        //user.IdUser = ctx.Users.Where(u => u.SareaId == Program.SareaId).Max(u => u.IdUser) + 1;
                        user.IdUser = nextId;
                        ctx.Users.Add(user);
                        //result += ctx.SaveChanges();
                        nextId++;
                        //dbContextTransaction.Commit();
                        //}
                        countProcessedItems++;
                        if (countProcessedItems % 1000 == 0)
                            Console.WriteLine($"Processed: {countProcessedItems} items");
                    }
                    Console.WriteLine("Save...");
                    result += ctx.SaveChanges();
                    dbContextTransaction.Commit();
                }
            }
            //    transaction.Complete();
            //}

                return result;
        }
    }
}
