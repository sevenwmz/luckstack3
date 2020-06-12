using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    [BindProperties]
    public class MineModel : PageModel
    {
        public User UserInfo { set; get; }
        public IList<Keyword> Keyword { set; get; }

        public int SumOfArticle { set; get; }
        public IList<MessageMine> Messages { set; get; }

        private MessageRepository _repository;

        public bool CheckAll { set; get; }


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
            int pageIndex = Convert.ToInt32(Request.RouteValues["id"]);
            Messages = _repository.Get();
            SumOfArticle = _repository.GetSum();
            if (SumOfArticle % 2 == 1)
            {
                ++SumOfArticle;
            }
            Messages = Messages.GetPaged(Const.PAGE_SIZE, pageIndex);
        }
        public ActionResult OnPost()
        {
            string request = Request.RouteValues["opt"].ToString();


            foreach (var item in Messages)
            {
                if (CheckAll)
                {
                    item.HasCheck = true;
                }
                if (item.HasCheck)
                {
                    if (request == "read")
                    {
                        _repository.GetHasRead(item.Id).HasRead = true;
                    }
                    else if (request == "delete")
                    {
                        _repository.Remove(item.Id);
                    }
                }
            }
            return RedirectToPage();

        }

    }
}