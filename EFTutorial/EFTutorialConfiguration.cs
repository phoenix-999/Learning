using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace EFTutorial
{
    class EFTutorialConfiguration : DbConfiguration
    {
        public EFTutorialConfiguration()
        {
            //Включение проверки транзакций и повторного запуска в случае сбоя. Исправлена ошибка: транзакция завершена успешно - сообщения о завершении не доставлено клиенту
            //SetTransactionHandler(SqlProviderServices.ProviderInvariantName, () => new CommitFailureHandler());
            //Стратегия для SQlServer разрешающая повторный запуск транзакций
            //SetExecutionStrategy(SqlProviderServices.ProviderInvariantName, () => new SqlAzureExecutionStrategy());
        }
    }
}
