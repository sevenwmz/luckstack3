using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Repository
{
    public class NoticeRepository
    {
        private static IList<Notice> _notice;

        static NoticeRepository()
        {
            _notice = new List<Notice>
            {
                new Notice
                {
                    Id = 1,
                    Title = "模拟测试1",

                },
                new Notice
                {
                    Id = 2,
                    Title = "模拟测试1",
                },
                new Notice
                {
                    Id = 3,
                    Title = "模拟测试1",
                },
                new Notice
                {
                    Id = 4,
                    Title = "模拟测试1",
                },
            };
        }

        public IList<Notice> Get()
        {
            return _notice;
        }
    }
}
