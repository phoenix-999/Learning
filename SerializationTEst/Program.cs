using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Security;
using System.IO;


namespace SerializationTEst
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerialize();
            CustomSerialization();
        }

        static void XmlSerialize()
        {
            //DataSet суриализуется в XML способом вызова метода экземпляра DataSet.WriteXml()
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

        static void CustomSerialization()
        {
            MainClassCustom mainClassCustom = new MainClassCustom();
            mainClassCustom.TestStr = "Custom string";

            using (FileStream stream = new FileStream("CustomSerialization.dat", FileMode.OpenOrCreate, FileAccess.Write))
            {
                //Сериализация
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    //Метод Serialize проверит реализует ли указанный тип экземпляра интерфейс ISerialization
                    //Если истина - создаст экземпляр SerializationInfo и передаст его в метод ISerializable.GetObjectData для напонения данными
                    //SerializationInfo чем то напоминает словарь
                    //Сериализованы будут заголовки класса и добавленные в SerializationInfo данные
                    formatter.Serialize(stream, mainClassCustom);
                    Console.WriteLine("Сериализовано!");
                }
                catch(SerializationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(SecurityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //Десериализация
            MainClassCustom newMainClassCustom;
            using (FileStream stream = File.OpenRead("CustomSerialization.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                //Будет вызван специальный конструктор
                try
                {
                    newMainClassCustom = formatter.Deserialize(stream) as MainClassCustom;
                    Console.WriteLine("Десериализовано!");
                    Console.WriteLine(newMainClassCustom.TestStr);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (SecurityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
