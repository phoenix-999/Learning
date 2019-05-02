using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CodeFirstTutorial.Models
{
    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [DefaultValue(typeof(DateTime),"GETDATE()")]
        public DateTime? ActionTime { get; set; }
        
    }
}
