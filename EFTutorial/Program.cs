using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            AddDefaultData();
        }

        static void AddDefaultData()
        {
            Geography koreaSeul = new Geography() { Country = "South Korea", City = "Seul" };
            Company samsung = new Company()
            {
                CompanyName = "Samsung",
                Geography = koreaSeul
            };
            Phone samsungS5 = new Phone()
            {
                Model = "S5",
                Price = 10000,
                Company = samsung
            };

            Phone samsungS6 = new Phone()
            {
                Model = "S6",
                Price = 15000,
                Company = samsung
            };

            Geography usaWashington = new Geography() { Country = "USA", Region = "Washington", City = "Redmond" };
            Company microsoft = new Company()
            {
                CompanyName = "Microsoft",
                Geography = usaWashington
            };
            Phone nokiaLumia830 = new Phone()
            {
                Model = "Nokia Lumia 830",
                Price = 8000,
                Company = microsoft
            };
            Phone nokiaLumia930 = new Phone()
            {
                Model = "Nokia Lumia 930",
                Price = 20000,
                Company = microsoft
            };

            using (Model1Container ctx = new Model1Container())
            {
                ctx.Phones.AddRange(new Phone[] { samsungS5, samsungS6, nokiaLumia830, nokiaLumia930 });
                ctx.SaveChanges();
            }
        }
    }
}
