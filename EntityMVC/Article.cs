using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMVC
{
    public class Article : BaceEntity
    {
        public string Title { set; get; }
        public string Summary { set; get; }
        public string Body { set; get; }
        public DateTime PublishTime { set; get; }
        public User Author { set; get; }
        public AD UseAd { set; get; }
        public Series UseSeries { set; get; }
        public IList<KeywordsAndArticle> OwnKeyword { set; get; }

        public Article PublishArticle(Article article)
        {
            article.PublishTime = DateTime.Now;
            return article;
        }

        public string GetSumarry(string body)
        {
            string summary = string.Empty;
            if (string.IsNullOrEmpty(summary))
            {
                summary = body.PadRight(255).Substring(0, 255).Trim();
            }
            else
            {
                summary = summary.Trim();
                if (summary.Length > 255)
                {
                    summary = summary.Substring(0, 255);
                }//else nothing.
            }
            return summary;
        }
    }
}
