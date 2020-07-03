using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class SeriesRepository : BaceRepository<Series>
    {
        public SeriesRepository(DbContext context) : base(context)
        {

        }
        /// <summary>
        /// Get Series
        /// </summary>
        /// <param name="choosSeries">Need Series Name</param>
        /// <returns>Return Series</returns>
        public Series GetSeries(int choosSeries)
        {
            return entities.Where(s => s.Id == choosSeries).FirstOrDefault();
        }

        public IList<Series> OnGetSeries(int userId)
        {
            return entities.Include(s => s.Owner).Where(s => s.OwnerId == userId).ToList();
        }

        public IList<Series> CategoryScendSeries(int id)
        {
            return entities.Include(s => s.SeriesLevel)
                    .Where(s => s.SeriesLevel.Id == id)
                    .ToList();
        }

        public IList<Series> GetBrotherSeries(int id)
        {
            Series series = entities.Find(id);
            if (series.SeriesLevel == null)
            {
                int authorId = entities.Where(s => s.Id == id).SingleOrDefault().ArticleUse[0].Author.Id;
                return entities.Where(s => s.SeriesLevelId == null).Where(s => s.OwnerId == authorId).ToList();
            }
            else
            {
                int parentId = entities.Where(s => s.SeriesLevelId == id).SingleOrDefault().Id;
                return entities.Where(s => s.SeriesLevelId == parentId).ToList();
            }
        }


        /// <summary>
        /// For childSeries take all series
        /// </summary>
        /// <param name="userId">CurrentId of series</param>
        /// <returns>Return all of current series </returns>
        public Series CategorySeries(int id)
        {
            return entities.Include(s => s.SeriesLevel)
                        .Where(s => s.Id == id)
                        .FirstOrDefault()
                        ;
        }


    }
}
