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
            IList<User> users = new List<User>();
            users = UserRepository.GetUserRank(getRankSum);

            ChildRankModel childRank = new ChildRankModel()
            {
                Items = connectedMapper.Map<List<ChildRankModel>>(users)
            };

            return childRank;
        }
    }
}
