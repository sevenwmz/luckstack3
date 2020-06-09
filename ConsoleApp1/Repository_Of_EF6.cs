using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Of_EF6
{
    public class Repository_Of_EF6 : DbContext
    {
        public DbSet<User> users { set; get; }

        public Repository_Of_EF6() : base("EF6")
        {
#if DEBUG
            new Repository_Of_EF6().Database.Log = Console.Write;
#endif
        }

    }
}
