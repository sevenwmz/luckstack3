using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices
{
    public class BMoneyService : BaceService
    {

        private BMoney _bMoney;
        private BMoneyRepository _repository;
        public BMoneyService()
        {
            _bMoney = new BMoney();
            _repository = new BMoneyRepository(dbContext);
        }
        internal void PublishProblem(int rewardMoney)
        {
            _bMoney = _bMoney.PublicProblemMinusBMoney(rewardMoney, _repository.GetByAuthorBMoney(CurrentUserId));
            _repository.AddNewRow(_bMoney);
        }
    }
}
