using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace DataProviderFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string cnStr = ConfigurationManager.ConnectionStrings["OleDb"].ConnectionString;
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(provider);
            using (DbConnection conn = dbFactory.CreateConnection())
            {
                conn.ConnectionString = cnStr;
                conn.Open();
                using (DbCommand command = conn.CreateCommand())
                {
                    command.CommandText = "select * from Inventory";
                    using (DbDataReader dbReader = command.ExecuteReader())
                    {
                        while(dbReader.Read())
                        {
                            for(int i =0; i < dbReader.FieldCount; i++)
                            {
                                Console.WriteLine("{0}: {1}", dbReader.GetName(i), dbReader[i]);
                            }
                        }
                    }
                }
            }
        }
    }
}
