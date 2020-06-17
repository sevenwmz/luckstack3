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
        private SqlContext _repository = new SqlContext();


        /// <summary>
        /// Add new row into BMoney database.
        /// </summary>
        /// <param name="InsertInfo">Need Info of insert data</param>
        public void AddNewRow(BMoney InsertInfo)
        {
            _repository.BMoneys.Add(InsertInfo);
            _repository.SaveChanges();
        }

        /// <summary>
        /// Add new info to 
        /// </summary>
        /// <param name="inviter"></param>
        /// <returns></returns>
        public BMoney GiveInviterPrize(int id)
        {
            BMoney bMoney = _repository.BMoneys
                .OrderByDescending(b => b.Latestime)
                .Where(b => b.OwnerId == id)
                .FirstOrDefault();

            return new BMoney
            {
                OwnerId = id,
                Latestime = DateTime.Now,
                Detail = "Inviter success award 10 BMoney",
                Freezing = bMoney.Freezing + 0,
                Change = 10,
                LeftBMoney = bMoney.LeftBMoney + 10,
                Status = BMoneyDirection.BMoneyIn
            };
        }



    }
}
