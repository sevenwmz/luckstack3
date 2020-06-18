using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class SeriesRepository : BaceRepository
    {
        /// <summary>
        /// Get Series
        /// </summary>
        /// <param name="choosSeries">Need Series Name</param>
        /// <returns>Return Series</returns>
        public Series GetSeries(int choosSeries)
        {
            return Context.Series.Where(s => s.Id == choosSeries).FirstOrDefault();
        }

        public IList<Series> OnGetSeries(int userId)
        {
            return Context.Series.Where(s=>s.OwnerId == userId).ToList();
        }
    }
}
