using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{   [BindProperties]
    public class MineModel : PageModel
    {
        public User UserInfo { set; get; }
        public IList<Keyword> Keyword { set; get; }

        public int SumOfArticle { set; get; }
        public IList<MessageMine> Items { set; get; }

        private MessageRepository _repository;
        
        public MineModel()
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
            _repository = new MessageRepository();
        }






        public void OnGet()
        {

            string exclude = Request.Query["exclude"];
            if (string.IsNullOrEmpty(exclude))
            {
                Items = _repository.Get();
            }
            else
            {
                Items = _repository.GetExclude(Enum.Parse<MessageStatus>(exclude));
            }

            int pageIndex = Convert.ToInt32(Request.RouteValues["id"]);
            int pageSize = 2;

            SumOfArticle = _repository.GetSum();
            Items = Items.GetPaged(pageSize, pageIndex);
        }
    }
}