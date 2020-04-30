using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _17bang
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public User UserInfo { set; get; }
        public IList<Keyword> Keyword { set; get; }

        public Article EditPublish { set; get; }

        private ArticleRepository _repository { set; get; }

        public IList<SelectListItem> AdOfArticle { set; get; }

        public IList<SelectListItem> SeriesOfSelect { get; } =
         new List<SelectListItem>
         {
                new SelectListItem{Text= "默认分类",Value= "1" },
                new SelectListItem{Text= "讲课这些天",Value= "2" },
                new SelectListItem{Text= "ASP.NET",Value= "3" },
                new SelectListItem{Text= "Razor",Value= "4" },
                new SelectListItem{Text= "CSharp",Value= "5" },
                new SelectListItem{Text= "折腾",Value= "6" },
                new SelectListItem{Text= "空系列",Value= "6" },
         };
        public EditModel()
        {
            UserInfo = new User
            {
                NickName = "wpz",
                Level = "⑩",
                Gender = "男",
                Birthday = "1981 年 4 月 ",
                Constellation = " 金牛座",
                SelfIntroduction = "十年磨一剑，专注于ASP.NET网站开发"
            };
            Keyword = new List<Keyword>
            {
                new Keyword{Name = "安装" },
                new Keyword{Name = "ASP.NET" },
                new Keyword{Name = "SQL" }
            };
            AdOfArticle = new List<SelectListItem>
            {
                new SelectListItem{Text= "----- 使用新的广告 -----",Value= "1" },
                new SelectListItem{Text= "微商宣传广告语 日加1000精准",Value= "2" },
                new SelectListItem{Text= "如果你听了一课之后发现不喜欢这门课程，那你可以要求退回你的学费，但必须用法语说。",Value= "3" },
                new SelectListItem{Text= "煮酒论英雄才子赢天下",Value= "4" },
            };
            _repository = new ArticleRepository();
        }


        public void OnGet()
        {
            int pageId = Convert.ToInt32(Request.RouteValues["id"]);
            EditPublish = ArticleRepository.GetId(pageId);
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            Article.ChangeArticleContent(EditPublish);
            _repository.Save(EditPublish);



        }
    }

}