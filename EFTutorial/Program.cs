using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;

namespace EFTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread = {0}", Thread.CurrentThread.ManagedThreadId);
            try
            {
                ClearDb();
            }
            catch { }
            AddDefaultData();
            LocalChanged();
            LiqnGroupBy();
            UpdateData();

            Console.ReadKey();
        }

        static void ClearDb()
        {
            using (Model1Container ctx = new Model1Container())
            {
                foreach (Phone phone in ctx.Phones)
                {
                    ctx.Phones.Remove(phone);
                }

                foreach (Company company in ctx.Companies)
                {
                    ctx.Companies.Remove(company);
                }

                foreach (Geography geography in ctx.Geography)
                {
                    ctx.Geography.Remove(geography);
                }

                ctx.SaveChanges();
            }
        }

        async static void AddDefaultData()
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
            Phone nokiaLumia830_v2 = new Phone()
            {
                Model = "Nokia Lumia 830",
                ModelDetail = "V 2.0",
                Price = 8000,
                Company = microsoft
            };
            Phone nokiaLumia930 = new Phone()
            {
                Model = "Nokia Lumia 930",
                Price = 20000,
                Company = microsoft
            };

            Phone nokiaLumia1030 = new Phone()
            {
                Model = "Nokia Lumia 1030",
                Price = 30000,
                Company = microsoft
            };

            using (Model1Container ctx = new Model1Container())
            {
                Phone[] phones = new Phone[] { samsungS5, samsungS6, nokiaLumia830, nokiaLumia830_v2, nokiaLumia930, nokiaLumia1030 };
                ctx.Phones.AddRange(phones);

                //При переопредлении методов Equals и GetHashCode - Навигационные свойства после первого обращения может удаляются с последующих классов.
                //После первого испоьзования ссылка не отслеживается контекстом.
                //Метод SaveChanges() используетколлекцию которая и использует GetHashCode и Equals
                //Необходимо учитывать это при переопределении методов
                //В случае, если IDictionary выявит 2 идентичных экземпляров - навигационное свойство второго (и третьего и т.д.) будет null
                
                ctx.SaveChanges();

                //Асинхорнный вызов
                //await ctx.SaveChangesAsync();

                Console.WriteLine("Default data added.");
            }
        }

        static void LocalChanged()
        {
            Console.WriteLine("LocalChanged Thread = {0}", Thread.CurrentThread.ManagedThreadId);
            IEnumerable<Phone> phones;
            //Выгрузка данных с БД
            using (Model1Container ctx = new Model1Container())
            {
                phones = (from phone in ctx.Phones
                         select phone as Phone).ToList<Phone>();
            }

            //Изменение локальных данных
            Console.WriteLine("Local data:");
            foreach (Phone phone in phones)
            {
                if (phone.ModelDetail == null)
                {
                    phone.ModelDetail = "no detail";
                }
                Console.WriteLine(phone);                
            }

            //Попытка изменить обьекты в БД используя локальные обьекты - успешно
            using (Model1Container ctx = new Model1Container())
            {
                foreach (var newPhone in phones)
                {
                    ctx.Phones.Attach(newPhone);
                    ctx.Entry<Phone>(newPhone).State = System.Data.Entity.EntityState.Modified;
                }

                ctx.SaveChanges();

                Console.WriteLine("Db data after changes:");
                foreach (var phone in ctx.Phones)
                {
                    Console.WriteLine(phone);
                }
            }


        }

        static void LiqnGroupBy()
        {

            Console.WriteLine("LiqnGroupBy Thread = {0}", Thread.CurrentThread.ManagedThreadId);
            using (Model1Container ctx = new Model1Container())
            {
                var query = from phone in ctx.Phones
                                          let FullModel = phone.Model + " " + phone.ModelDetail
                                          where phone.Company.Geography.Region != null
                                          group new { FullModel, phone.Price} by phone.Price into phonesModels
                                          select new { Key = phonesModels.Key, Count = phonesModels.Count(), Group = phonesModels };

                Console.WriteLine("SQL запрос: \n\t {0}", query);

                Console.WriteLine("\n\tВывод содержимого выборки:");
                foreach (var group in query)
                {
                    int sum = 0;
                    foreach (var fullModel in group.Group)
                    {
                         sum += fullModel.Price;
                    }
                    Console.WriteLine("\tKey = {0}, Sum = {1}", group.Key, sum);
                }
            }
        }

        static void UpdateData()
        {
            using (Model1Container ctx = new Model1Container())
            {
                foreach (Phone phone in ctx.Phones )
                {
                    phone.ModelDetail = "To Update";
                    Console.WriteLine("OriginalValues = {0}", ctx.Entry<Phone>(phone).OriginalValues.GetValue<string>("ModelDetail"));
                }

                ctx.SaveChanges();
            }
        }
    }
}
