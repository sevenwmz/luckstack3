using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace _17bang.Repository
{
    public class MessageRepository
    {
        private static IList<MessageMine> _repository;

        static MessageRepository()
        {
            _repository = new List<MessageMine>
            {
                new MessageMine
                {
                    Id = 1,
                    PublishTime = DateTime.Now.AddDays(-5),
                    Status = MessageStatus.Refresh,
                    Content = "你因为登录获得系统随机分配给你的 帮帮豆 14 枚，可用于感谢赞赏等。 ",
                    Select = true
                },
                new MessageMine
                {
                    Id = 2,
                    PublishTime = DateTime.Now.AddDays(-7),
                    Status = MessageStatus.SomeOnePickUp,
                    Content = "你因为登录获得系统随机分配给你的 帮帮豆 25 枚，可用于感谢赞赏等。 ",
                    Select = true
                },
                new MessageMine
                {
                    Id = 3,
                    PublishTime = DateTime.Now.AddDays(-12),
                    Status = MessageStatus.Target,
                    Content = "DK捡走了你掉落的 帮帮币 7枚  ",
                    Select = true
                },
                new MessageMine
                {
                    Id = 4,
                    PublishTime = DateTime.Now.AddDays(-15),
                    Status = MessageStatus.AutoCancle,
                    Content = "DK捡走了你掉落的 帮帮币 7枚  ",
                    Select = true
                },
                new MessageMine
                {
                    Id = 5,
                    PublishTime = DateTime.Now.AddDays(-16),
                    Status = MessageStatus.HaveReward,
                    Content = "DK捡走了你掉落的 帮帮币 7枚  ",
                    Select = true
                },
                new MessageMine
                {
                    Id = 6,
                    PublishTime = DateTime.Now.AddDays(-17),
                    Status = MessageStatus.InviteHelp,
                    Content = "DK捡走了你掉落的 帮帮币 7枚  ",
                    Select = true
                },
                new MessageMine
                {
                    Id = 7,
                    PublishTime = DateTime.Now.AddDays(-18),
                    Status = MessageStatus.Target,
                    Content = "DK捡走了你掉落的 帮帮币 7枚  ",
                    Select = true
                },
                new MessageMine
                {
                    Id = 8,
                    PublishTime = DateTime.Now.AddDays(-19),
                    Status = MessageStatus.Target,
                    Content = "DK捡走了你掉落的 帮帮币 7枚  ",
                    Select = true
                }
            };
        }

        public IList<MessageMine> Get()
        {
            return _repository;
        }
        public void Add(MessageMine value)
        {
            _repository.Add(value);
        }
        public IList<MessageMine> GetExclude(MessageStatus status)
        {
            return _repository.Where(p => p.Status == status).ToList();
        }

        public int GetSum()
        {
            return _repository.Count;
        }

    }
    public static class MessageExtension
    {
        public static IList<MessageMine> GetPaged(this IList<MessageMine> ClassName, int pageSize, int pageIndex)
        {
            return ClassName.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
