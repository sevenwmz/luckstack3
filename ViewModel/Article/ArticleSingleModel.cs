using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ViewModel.Article
{
    public class ArticleSingleModel
    {
        public int Id { set; get; }
        public string Author { set; get; }

        public string Title { set; get; }
        [AllowHtml]
        public string Body { set; get; }

        public DateTime PublishTime { get; set; }

        public string ChoosSeries { set; get; }

        public IList<KeywordModel> Keywords { set; get; }

        public IList<string> Comments { set; get; }



        public int SeriesId { set; get; }
        public string SeriesTitle { set; get; }

        public int LastArticleId { set; get; }
        public string LastArticleTitle { set; get; }

        public int NextArticleId { set; get; }
        public string NextArticleTitle { set; get; }





    }
}
