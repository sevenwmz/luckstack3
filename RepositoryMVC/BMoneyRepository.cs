using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class BMoneyRepository
    {
        private MvcRepository repository = new MvcRepository();


        /// <summary>
        /// Add new row into BMoney database.
        /// </summary>
        /// <param name="InsertInfo">Need Info of insert data</param>
        public void AddNewRow(BMoney InsertInfo)
        {
            repository.BMoneys.Add(InsertInfo);
            repository.SaveChanges();
        }
    }
}
