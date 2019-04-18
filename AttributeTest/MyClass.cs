using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeTest
{
    [My("2019-04-18", Number = 1)]
    class MyClass
    {
        /// <summary>
        /// При использовании классов декорированных аттрибутами создаются экземпляры класса атрибутаа на каждую декорацию.
        /// Скорее всего: ссылка на экземпляр аатрибута записывается в метаданные элемента
        /// </summary>
        [My("2019-02-17", Number = 2)]
        public void Method()
        {
            Console.WriteLine("MyClass.Method()");
        }
    }
}
