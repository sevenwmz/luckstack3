using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang
{
    [IgnoreAntiforgeryToken]
    public class Index : PageModel
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

        public Index NewMessage { set; get; }

        public void OnGet(bool getNewestMessage)
        {
        }

        public void OnPost(bool getNewestMessage)
        {
            NewMessage = new NavNewMessageRepo().GetNewMessage(getNewestMessage);
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

            _navNewMessage = new List<Index>
            {
                new Index
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
                new Index
                {
                    IsAward = false,


                    Id = 2,
                    CreateTime = DateTime.Now.AddDays(-10),
                    FromWho = wpz,
                    TransactionBy = "帮帮点",
                    MonetaryUnit = 10,
                    GiveTo = atai
                },
                new Index
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
        private static IList<Index> _navNewMessage { set; get; }

        internal Index GetNewMessage(bool getNewestMessage = true)
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


