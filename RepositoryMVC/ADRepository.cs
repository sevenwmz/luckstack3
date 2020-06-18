using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class ADRepository : BaceRepository
    {
        /// <summary>
        /// Get AD from database
        /// </summary>
        /// <param name="choosAd">Need AD name</param>
        /// <returns>Return AD</returns>
        public AD GetAD(string choosAd)
        {
            return Context.ADs.Where(a => a.ContentOfAd == choosAd).FirstOrDefault();
        }
    }
}
