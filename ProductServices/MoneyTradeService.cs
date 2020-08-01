using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.MoneyTrade;

namespace ProductServices
{
    public class MoneyTradeService : BaceService
    {
        public SaleModel GetCurrentUserLeftBMoney()
        {
            SaleModel model = Mapper.Map<SaleModel>(new BMoneyRepository(dbContext).GetByAuthorBMoney(CurrentUserId));
            model.SaleCount = 0;
            model.Message = null; 
            return model;
        }

        public void FreezingMoney(SaleModel model)
        {
            BMoneyRepository repo = new BMoneyRepository(dbContext);
            BMoney addNewRecord = new BMoney();
            addNewRecord.FreezingSale();
            addNewRecord.Owner = CurrenUser;
            addNewRecord.Detail = $"{model.Message} + 系统自动添加：" +
                                    $"用户出售给{UserRepository.GetBy(model.ByFrom).UserName} 了" +
                                    $"{model.SaleCount} 枚帮帮币,出售总金额为{model.TotalSaleMoney}";
            addNewRecord.LeftBMoney =
                repo.GetByAuthorBMoney(CurrentUserId).LeftBMoney - model.CanSale;

            addNewRecord.Freezing = model.SaleCount;
            addNewRecord.Change = model.SaleCount;
            repo.AddNewRow(addNewRecord);

        }
    }
}
