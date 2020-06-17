using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class MvcRepository : DbContext
    {
        public DbSet<User> UsersInfo { set; get; }
        public DbSet<BMoney> BMoneys { set; get; }


        public MvcRepository() : base("MvcRepository")
        {
#if DEBUG
            Database.Log = s => File.AppendAllText("C:\\EF.log", s);
#endif
        }


    }
}
