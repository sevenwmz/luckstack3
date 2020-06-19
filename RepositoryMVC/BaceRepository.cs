using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class BaceRepository<T> where T : BaceEntity
    {
        protected DbContext context;

        public BaceRepository(DbContext context)
        {
            this.context = context;
        }


        protected DbSet<T> entities
        {
            get => context.Set<T>();
        }

        public T Find(int id)
        {
            return entities.Find(id);
        }

    }
}
