using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EFCodeFirstTutorialEntities context = new EFCodeFirstTutorialEntities())
            {
                Console.WriteLine("Users:");
                foreach (Users user in context.Users)
                {
                    Console.WriteLine("\t Name = {0}, Age = {1}", user.Name, user.Age);
                }

                Console.WriteLine("Sareas:");
                foreach (Sareas sarea in context.Sareas)
                {
                    Console.WriteLine("\t SareaName = {0}, UserId = {1}", sarea.SareaName, sarea.User_UserId);
                }
            }
        }
    }
}
