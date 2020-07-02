using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class SeriesRepository : BaceRepository<Series>
    {
        public SeriesRepository(DbContext context) : base(context)
        {

        }
        /// <summary>
        /// Get Series
        /// </summary>
        /// <param name="choosSeries">Need Series Name</param>
        /// <returns>Return Series</returns>
        public Series GetSeries(int choosSeries)
        {
            return entities.Where(s => s.Id == choosSeries).FirstOrDefault();
        }

        public IList<Series> OnGetSeries(int userId)
        {
            return entities.Include(s=>s.Owner).Where(s=>s.OwnerId == userId).ToList();
        }
    }
}
