using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTEst
{
    public class MainClass
    {
        private int id;
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

        public MainClass() { }
        public MainClass(int id)
        {
            this.id = id;       
        }

    }
}
