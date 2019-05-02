using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstTutorial.Models;

namespace CodeFirstTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User() { Name = "Yurii", Age = 27 };
            User user2 = new User() { Name = "Liubov", Age = 38 };
            Sarea sarea1 = new Sarea() { SareaName = "Sarea1", User = user1 };
            using (UserContext userContext = new UserContext())
            {
                userContext.Users.AddRange(new User[] { user1, user2 });
                userContext.Sareas.Add(sarea1);
                userContext.SaveChanges();
            }

            User user3 = new Admin() { Name = "Alex", Age = 30, Level = 1 };
            using (UserContext userContext = new UserContext())
            {
                userContext.Users.Add(user3);
                userContext.SaveChanges();
            }

            using (UserContext userContext = new UserContext())
            {


                Console.WriteLine("Users:");
                foreach(User user in userContext.Users)
                {
                    Console.WriteLine("\t Name = {0}, Age = {1}", user.Name, user.Age);
                }

                Console.WriteLine("Sareas:");
                foreach (Sarea sarea in userContext.Sareas)
                {
                    Console.WriteLine("\t SareaName = {0}", sarea.SareaName);
                }
            }

            #region LINQ

            #endregion

        }
    }
}
