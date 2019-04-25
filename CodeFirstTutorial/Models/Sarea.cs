using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTutorial.Models
{
    class Sarea
    {
        public int SareaId { get; set; }

        public string SareaName { get; set; }
        public User User { get; set; }
    }
}
