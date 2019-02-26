using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityServiceClient.EchoClaims;
using System.ServiceModel.Security;
using System.Data;
using System.Threading;

namespace SecurityServiceClient
{
    class ClientRunner
    {
        public void Run(string protocol)
        {
            EchoClaimsClient client = null;
            if (protocol.ToLower() == "tcp")
            {
                client = new EchoClaimsClient("tcpIEchoClaims");
                //Console.WriteLine("Введите логин:");
                //client.ClientCredentials.UserName.UserName = Console.ReadLine();
                //Console.WriteLine("Введите пароль:");
                //client.ClientCredentials.UserName.Password = Console.ReadLine();
            }
            else if (protocol.ToLower() == "https")
            {
                client = new EchoClaimsClient("httpsIEchoClaims");//Не работает
                Console.WriteLine("Введите логин:");
                client.ClientCredentials.UserName.UserName = Console.ReadLine();
                Console.WriteLine("Введите пароль:");
                client.ClientCredentials.UserName.Password = Console.ReadLine();
            }
            else if (protocol.ToLower() == "http")
            {
                client = new EchoClaimsClient("httpIEchoClaims");
            }
            else if (protocol == null)
            {
                throw new ArgumentException("Протокол соединения не указан!");
            }
            else
            {
                throw new ArgumentException("Протокол соединения указан не верно!");
            }
            
            
            try
            {
                new Thread(()=> { client.Test(); }).Start();
                DataSet ds = client.SendDataSet();
                for(int r=0; r < ds.Tables[0].Rows.Count; r++)
                {
                    for(int c=0; c<ds.Tables[0].Columns.Count; c++)
                    {
                        Console.WriteLine("Column: {0}, Row: {1}", ds.Tables[0].Columns[c], ds.Tables[0].Rows[r][c]);
                    }
                }
            }
            catch (System.ServiceModel.Security.SecurityNegotiationException ex)
            {
                Console.WriteLine("Доступ зпарещен! {0}", ex.Message);
            }
            catch (System.ServiceModel.CommunicationException ex)
            {
                Console.WriteLine("Ошибка подключения к серверу: {0}", ex.Message);
            }
            catch (System.TimeoutException ex)
            {
                Console.WriteLine("Превышено время ожидания подключения: {0}", ex.Message);
            }

            for (int i = 0; i < 2; i++)
            {
                try
                {
                    client.TestFault();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
