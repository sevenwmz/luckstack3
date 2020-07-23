using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ChildAction;

namespace ProductServices
{
    public class LogOnService : BaceService
    {
        public LogOnModel GetCurrentUserInfo()
        {
            LogOnModel model = new LogOnModel();
            if (CurrentUserId == null)
            {
                return model;
            }

            User findUserInfo = new UserRepository(dbContext).GetLogOnInfo(CurrentUserId.Value);
            model.Id = findUserInfo.Id;
            model.UserName = findUserInfo.UserName;
            model.LeftBMoney = findUserInfo.Wallet.OrderByDescending(m=>m.Latestime).Select(m => m.LeftBMoney).FirstOrDefault();
            return model;

        }
    }
}
