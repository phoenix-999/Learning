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
            User alex = new User()
            {
                Name = "Alex",
                Age = 27
            };
            User yurii = new Manager()
            {
                Name = "Yurii",
                Age = 30,
                Level = 1
            };
            Departament mainOffice = new Departament()
            {
                Name = "MainOffice"
            };
            mainOffice.Users.Add(alex);
            mainOffice.Users.Add(yurii);

            using (EF_People_ModelFirstContainer context = new EF_People_ModelFirstContainer())
            {
                
                context.Departaments.Add(mainOffice); //Данные о связанных экземплярах будут добавлены автоматически
                //context.Users.AddRange(new User[] { alex, yurii }); //Можно и так, данные не задублируются. После добавления первый раз - статус обьекта не будет помечен как новый
                context.SaveChanges();
                Console.WriteLine("Данные успешно добавлены");
            }
        }
    }
}
