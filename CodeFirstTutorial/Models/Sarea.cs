using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTutorial.Models
{
    public class Sarea
    {
        public int SareaId { get; set; }
        public string SareaName { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Sarea()
        {
            Users = new HashSet<User>();
        }
    }
}
