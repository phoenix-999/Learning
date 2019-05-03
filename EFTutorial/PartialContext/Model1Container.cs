using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.IO;
using System.Data.Entity.Infrastructure.Interception;

namespace EFTutorial
{
    public partial class Model1Container
    {
        static Model1Container()
        {
            DbInterception.Add(new NLogCommandInterceptor());
            Database.SetInitializer<Model1Container>(new DropCreateDatabaseAlways<Model1Container>());
        }

        private void DefaultLogger(string message)
        {
            using (TextWriter log = File.CreateText("LOG.txt"))
            {
                log.WriteAsync(message);
            }
        }
    }
}
