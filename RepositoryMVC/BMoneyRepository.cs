using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class BMoneyRepository :BaceRepository<BMoney>
    {
        public BMoneyRepository(DbContext contenxt) :base(contenxt) 
        {

        }
        /// <summary>
        /// Add new row into BMoney database.
        /// </summary>
        /// <param name="InsertInfo">Need Info of insert data</param>
        public void AddNewRow(BMoney InsertInfo)
        {
            entities.Add(InsertInfo);
            context.SaveChanges();
        }

        /// <summary>
        /// Add new info to 
        /// </summary>
        /// <param name="inviter"></param>
        /// <returns></returns>
        public BMoney GetByAuthorBMoney(int? authorId)
        {
            return entities.OrderByDescending(b => b.Latestime).Where(b => b.OwnerId == authorId).FirstOrDefault();
        }
    }
}
