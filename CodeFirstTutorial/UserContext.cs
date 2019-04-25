using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirstTutorial.Models;

namespace CodeFirstTutorial
{
    class UserContext : DbContext
    {
        public UserContext() : base("DBConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Sarea> Sareas { get; set; }
    }
}
