using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    public class _NavNewMessage : ViewComponent
    {
        #region Model Area
        //Actually here is enum ,but lazy to do it....
        public bool IsAward { set; get; }


        public int Id { set; get; }
        public DateTime CreateTime { set; get; }
        public string ContentType { set; get; }
        public string InfoContent { set; get; }
        public User FromWho { set; get; }
        public string BehaviorType { set; get; }
        public string TransactionBy { set; get; }
        public int MonetaryUnit { set; get; }

        public User GiveTo { set; get; }
        #endregion

        public IViewComponentResult Invoke()
        {
            _NavNewMessage model = new _NavNewMessage();
            model = new NavNewMessageRepo().GetNewMessage();

            return View(model);
        }
    }

    public class NavNewMessageRepo
    {
        static NavNewMessageRepo()
        {
            User wpz = new User()
            {
                UserName = "wpz",
                Level = "10",
            };
            User atai = new User()
            {
                UserName = "atai",
                Level = "1",
            };
            User ljp = new User()
            {
                UserName = "ljp",
                Level = "1",
            };

            _navNewMessage = new List<_NavNewMessage>
            {
                new _NavNewMessage
                {
                    IsAward = true,

                    Id = 1,
                    CreateTime = DateTime.Now,
                    ContentType = "文章",
                    InfoContent = "源栈培训：ASP.NET MVC：Route",
                    FromWho = wpz,
                    BehaviorType = "打赏",
                    TransactionBy = "帮帮币",
                    MonetaryUnit = 1
                },
                new _NavNewMessage
                {
                    IsAward = false,


                    Id = 2,
                    CreateTime = DateTime.Now.AddDays(-10),
                    FromWho = wpz,
                    TransactionBy = "帮帮点",
                    MonetaryUnit = 10,
                    GiveTo = atai
                },
                new _NavNewMessage
                {
                    IsAward = false,

                    Id = 3,
                    CreateTime = DateTime.Now.AddDays(-11),
                    FromWho = wpz,
                    TransactionBy = "帮帮点",
                    MonetaryUnit = 10,
                    GiveTo = ljp
                }
            };

        }
        private static IList<_NavNewMessage> _navNewMessage { set; get; }

        internal _NavNewMessage GetNewMessage(bool getNewestMessage = true)
        {
            if (getNewestMessage)
            {
                return _navNewMessage.OrderByDescending(m => m.CreateTime).First();
            }
            else
            {
                return _navNewMessage.OrderBy(m => m.CreateTime).First();
            }
        }
    }




}


