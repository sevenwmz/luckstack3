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
    public class SeriesService : BaceService
    {
        private SeriesRepository _repo;
        public SeriesService()
        {
            _repo = new SeriesRepository(dbContext);
        }

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

        /// <summary>
        /// Get childSeries info
        /// </summary>
        /// <param name="userId">Need userId</param>
        /// <returns>Return childSeries info</returns>
        public ChildSeriesModel GetSideSeries(int userId)
        {
            ChildSeriesModel model = new ChildSeriesModel 
            {
                Items = connectedMapper.Map<IList<ChildSeriesModel>>(_repo.OnGetSeries(userId))
            };
            model.AuthorId = model.Items.Select(s => s.AuthorId).FirstOrDefault();
            model.AuthorName = model.Items.Select(s => s.AuthorName).FirstOrDefault();
            return model;
        }
    }
}
