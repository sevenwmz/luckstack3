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
        public AD GetAD(int choosAd)
        {
            return Context.ADs.Where(a => a.Id == choosAd).FirstOrDefault();
        }

        /// <summary>
        /// Get AD id and save to database
        /// </summary>
        /// <param name="aD">Need AD</param>
        /// <returns>Return AD id</returns>
        public int AddADToDatabase(AD aD)
        {
            Context.ADs.Add(aD);
            Context.SaveChanges();
            return aD.Id;
        }

        public IList<AD> OnGetAD(int userId)
        {
            return Context.ADs.Where(a => a.OwnerId == userId).ToList();
        }
    }
}
