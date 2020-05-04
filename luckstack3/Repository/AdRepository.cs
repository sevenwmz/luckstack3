using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Repository
{
    public class AdRepository
    {
        public static IList<Ad> _repository;

        static AdRepository()
        {
            _repository = new List<Ad>
            {
                new Ad{ AdName = "学编程，来 “源栈”！飞哥精品小班等着你……" ,Id =1},
                new Ad{ AdName = "免费广告位，抢到就是赚到！" ,Id = 2},
                new Ad{ AdName = "免费广告位，抢到就是赚到！" ,Id = 3},
                new Ad{ AdName = "免费广告位，抢到就是赚到！" ,Id = 4},
                new Ad{ AdName = "免费广告位，抢到就是赚到！" ,Id = 5},
                new Ad{ AdName = "本站主机由西部数码提供" ,Id = 6},
            };
        }
        public IList<Ad> Get()
        {
            return _repository;
        }

    }
}
