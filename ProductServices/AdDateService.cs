using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.AdInWidget;

namespace ProductServices
{
    public class AdDateService : BaceService
    {
        public InUseRepository _repo;
        public AdDateService()
        {
            _repo = new InUseRepository(dbContext);
        }

        public _DateOfAd GetAdPositionBy(int positionId)
        {
            return new _DateOfAd
            {
                AdPosition = Mapper.Map<List<ViewModel.AdInWidget.InUseDate>>(_repo.GetUsedAdPositionDateBy(positionId))
            };
        }


    }
}
