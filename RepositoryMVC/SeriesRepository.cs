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
        public Series GetSeries(string choosSeries)
        {
            return Context.Series.Where(s => s.ContentOfSeries == choosSeries).FirstOrDefault();
        }
    }
}
