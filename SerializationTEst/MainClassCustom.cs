using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SerializationTEst
{
    [Serializable]
    public class MainClassCustom : ISerializable, IDeserializationCallback
    {
        private int id;
        //При добавлении нового поля - для преодоления проблем версионности при десериализации
        //При десериализации - будет установлено значение по уммолчанию
        [OptionalField]
        bool isTest;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string testStr = "Тестовая строка";
        public string TestStr
        {
            get { return testStr; }
            set { testStr = value; }
        }

        public ClassForAggregation ClassForAggregation { get; set; }

        public MainClassCustom() { }
        public MainClassCustom(int id)
        {
            this.id = id;       
        }

        #region CustomSerialization
        //Должен быть реализован интерфейс ISerializible и специальный конструктор для последующего востановления экземпляра с SerializationInfo
        //Конструктор может быть private

        private MainClassCustom(SerializationInfo info, StreamingContext context)
        {
            Console.WriteLine("Context state - {0}", context.State.ToString());

            this.TestStr = info.GetString("TestStrCustom");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Console.WriteLine("Context state - {0}", context.State.ToString());

            info.AddValue("TestStrCustom", TestStr);
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            ///Будет вызван после сериализации
            ///Так же. можно воспользовать аттрибутами [OnSerialized], [OnSerializing], [OnDeserialized], [OnDesrializing]. Метод должен содержать аргумент типа StreamingContext.

            Console.WriteLine("Сработал IDeserializationCallback.OnDeserialization для", sender);
        }

        #endregion
    }
}
