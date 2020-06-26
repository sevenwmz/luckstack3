using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel;
using ViewModel.ChildAction;

namespace ProductServices
{
    public class AdService : BaceService
    {
        public int Add(string contentOfAd, string webSite)
        {
            AD aD = new AD
            {
                ContentOfAd = contentOfAd,
                WebSite = webSite
            };
            aD = aD.PublishAd(aD);

            return new ADRepository(dbContext).AddADToDatabase(aD);
        }

        /// <summary>
        /// Get Ad date
        /// </summary>
        /// <param name="userId">Need user id</param>
        /// <returns>Return IList<ADModel></returns>
        public IList<ADModel> GetAD(int userId)
        {
            IList<AD> ads = new List<AD>();
            ads = new ADRepository(dbContext).OnGetAD(userId);

            IList<ADModel> tempADs = new List<ADModel>();
            foreach (var item in ads)
            {
                tempADs.Add(new ADModel { Id = item.Id, ContentOfAd = item.ContentOfAd });
            }
            return tempADs;
        }

        /// <summary>
        /// Get AD form repo
        /// </summary>
        /// <param name="getADSum">Need num of AD </param>
        /// <returns>Return ChildAdModel with specified num</returns>
        public ChildADModel GetChildAD(int getADSum)
        {
            IList<AD> aD = new List<AD>();
            aD = new ADRepository(dbContext).GetChildAD(getADSum);

            ChildADModel aDModel = new ChildADModel
            {
                Items = connectedMapper.Map<IList<ChildADModel>>(aD)
            };
            return aDModel;
        }

        /// <summary>
        /// Get OnGet Of ADList
        /// </summary>
        /// <param name="ts">Need IList<ADModel></param>
        /// <returns>Return IList<ADModel></returns>
        public IList<SelectListItem> GetDropDownList(IList<ADModel> ts)
        {
            List<SelectListItem> dropDownList = new List<SelectListItem>();
            foreach (var item in ts)
            {
                dropDownList.Add(new SelectListItem { Text = item.ContentOfAd, Value = item.Id.ToString() });
            }
            return dropDownList;
        }



    }
}
