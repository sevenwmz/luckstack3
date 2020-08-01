using EntityMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.ChildAction;

namespace ProductServices
{
    public class ChildRankService : BaceService
    {
        public ChildRankModel GetRank(int getRankSum)
        {
            IList<EntityMVC.User> users = new List<EntityMVC.User>();
            users = UserRepository.GetUserRank(getRankSum);

            ChildRankModel childRank = new ChildRankModel()
            {
                Items = Mapper.Map<List<ChildRankModel>>(users)
            };

            return childRank;
        }
    }
}
