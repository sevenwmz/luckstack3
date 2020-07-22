using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.Repository;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class SingleModel : PageModel
    {
        #region Model
        public SingleModel SingleArticle { set; get; }
        public int Id { set; get; }
        public string Title { set; get; }
        public DateTime PublishTime { set; get; }
        public string Author { set; get; }
        public string Body { set; get; }
        public string ChoosSeries { set; get; }
        [BindProperty]
        public string Comments { set; get; }
        public string SeriesTitle { set; get; }
        public string LastArticleTitle { set; get; }
        public string NextArticleTitle { set; get; }
        public int LastArticleId { set; get; }
        public int NextArticleId { set; get; }
        public IList<Keyword> Keywords { set; get; }
        public IList<Comment> BelongArticleComments { set; get; }

        #endregion


        public void OnGet(int id)
        {
            SingleModel SingleArticle = new SingleModel
            {
                Id = 45,
                Title = "here is test title",
                PublishTime = DateTime.Now,
                Author = "HandSome wpz",
                Body = "123111111111111111111111111111111111111111"
            };
            BelongArticleComments = new CommoentsRepository().Get(id);
        }

        public void OnPost(int id)
        {
            new CommoentsRepository().SaveComments(Comments, id);
        }

    }



}
