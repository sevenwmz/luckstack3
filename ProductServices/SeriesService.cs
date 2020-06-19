using EntityMVC;
using RepositoryMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel;

namespace ProductServices
{
    public class SeriesService : BaceService
    {
        /// <summary>
        /// Get Series date
        /// </summary>
        /// <param name="userId">Need user id</param>
        /// <returns>Return IList<SeriesModel></returns>
        public IList<SeriesModel> GetSeries(int userId)
        {
            IList<Series> series = new List<Series>();
            series = new SeriesRepository(dbContext).OnGetSeries(userId);

            IList<SeriesModel> tempSeries = new List<SeriesModel>();
            foreach (var item in series)
            {
                tempSeries.Add(new SeriesModel { Id = item.Id, ContentOfSeries = item.ContentOfSeries });
            }
            return tempSeries;
        }

        /// <summary>
        /// Get OnGet Of SeriesList
        /// </summary>
        /// <param name="ts">Need IList<Series></param>
        /// <returns>Return IList<SelectListItem></returns>
        public IList<SelectListItem> GetDropDownList(IList<SeriesModel> ts)
        {
            List<SelectListItem> dropDownList = new List<SelectListItem>();
            foreach (var item in ts)
            {
                dropDownList.Add(new SelectListItem { Text = item.ContentOfSeries.ToString(), Value = item.Id.ToString() });
            }
            return dropDownList;
        }
    }
}
