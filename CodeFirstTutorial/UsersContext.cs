using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirstTutorial.Models;

namespace CodeFirstTutorial
{
    class UsersContext : DbContext
    {
        static UsersContext() { Database.SetInitializer<UsersContext>(new DropCreateDatabaseAlways<UsersContext>()); }
        public UsersContext():base("UsersContext") {}

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Sarea> Sareas { get; set; }
    }
}
