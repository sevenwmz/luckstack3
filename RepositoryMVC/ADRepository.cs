using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class ADRepository : BaceRepository<AD>
    {

        public ADRepository(DbContext content) :base( content)
        {

        }


        /// <summary>
        /// Get AD from database
        /// </summary>
        /// <param name="choosAd">Need AD name</param>
        /// <returns>Return AD</returns>
        public AD GetAD(int choosAd)
        {
            return entities.Where(a => a.Id == choosAd)
                    .Where(a => a.IsDeletedAd == false)
                    .FirstOrDefault()
                    ;
        }

        /// <summary>
        /// Get AD id and save to database
        /// </summary>
        /// <param name="aD">Need AD</param>
        /// <returns>Return AD id</returns>
        public int AddADToDatabase(AD aD)
        {
            entities.Add(aD);
            return aD.Id;
        }


        public IList<AD> OnGetAD(int userId)
        {
            return entities.OrderByDescending(a=>a.Id)
                        .Where(a => a.OwnerId == userId)
                        .Where(a=>a.IsDeletedAd == false)
                        .ToList()
                        ;
        }

        /// <summary>
        /// Take specified ad of childAD
        /// </summary>
        /// <param name="getADSum">Need num of get AD count</param>
        /// <returns>Return specified AD</returns>
        public IList<AD> GetChildAD(int getADSum)
        {
            return entities.OrderBy(a => a.Id)
                        .Where(a=>a.IsDeletedAd == false)
                        .Take(getADSum)
                        .ToList()
                        ;
        }
    }
}
