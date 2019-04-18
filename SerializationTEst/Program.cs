using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SerializationTEst
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerialize();
        }

        static void XmlSerialize()
        {
            Console.WriteLine("XML Serialize");

            MainClass mainClass = new MainClass(1);
            mainClass.ClassForAggregation = new ClassForAggregation();
            mainClass.ClassForAggregation.Id = 2;

            using (FileStream fs = new FileStream("XMLSerialization.xls", FileMode.Create, FileAccess.Write))
            {
                //Сериализация
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(MainClass));
                //Для сериализации экземпляр сериализируемого класса должен иметь контруктор без параметров
                //Так же, класс должен быть помечен как public
                //Сериализует и агрегируемые экземпляры
                //Поля помечены как private НЕ сериализуються
                xmlSerializer.Serialize(fs, mainClass);
            }

            using (FileStream fs = new FileStream("XMLSerialization.xls", FileMode.Open, FileAccess.Read))
            {
                //Десериализация
                //Экземпляр будет создан конструктором без параметров и открытым полям будут присвоены значения
                //Если имеется открытое поле только для чтения - будет установлено значения по уммолчанию. В случае если значения прописано итеральной константой(за хардкожено) - оно сохранится.
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(MainClass));
                MainClass deserializeClass = xmlSerializer.Deserialize(fs) as MainClass;
                Console.WriteLine("MainClass.Id = {0}", deserializeClass.Id);
                Console.WriteLine("MainClass.TestStr = {0}", deserializeClass.TestStr);
                Console.WriteLine("MainClass.ClassForAggregation.Id= {0}", deserializeClass.ClassForAggregation.Id);
            }
        }
    }
}
