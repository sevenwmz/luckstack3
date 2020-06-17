using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class SqlContext : DbContext
    {
        public DbSet<User> Users { set; get; }
        public DbSet<BMoney> BMoneys { set; get; }


        public SqlContext() : base("MvcRepository")
        {
#if DEBUG
            Database.Log = s => File.AppendAllText("C:\\EF.log", s);
#endif
        }


    }
}
