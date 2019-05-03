using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirstTutorial.Models;

namespace CodeFirstTutorial
{
    class Program 
    {
        static UsersContext Context;
        static void Main(string[] args)
        {
            Sarea sarea1 = new Sarea() { SareaName = "Sarea1" };
            User user1 = new User() { Name = "Yurii", Age = 27, Sarea = sarea1 };
            User user2 = new User() { Name = "Alex", Age = 37, Sarea = sarea1 };

            using (Context = new UsersContext())
            {
                Context.Users.AddRange(new User[] { user1, user2 });
                Context.SaveChanges();

                var users = from user in Context.Users
                            select new { user.Name, user.Age, user.Sarea.SareaName };

                foreach (var user in users)
                {
                    Console.WriteLine("Name = {0}, Age = {1}, SareaName = {2}", user.Name, user.Age, user.SareaName);
                }
            }
        }
    }
}
