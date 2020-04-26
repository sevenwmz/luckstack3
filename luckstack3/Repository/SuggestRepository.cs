using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Repository
{
    public class SuggestRepository
    {

        private static IList<Suggest> _suggest;
        private static IList<Suggest> _asideSuggest;
        static SuggestRepository()
        {
            _suggest = new List<Suggest>
            {
                new Suggest
                {
                    Id = 1,
                    Title = "操作不方便",
                    Summary ="习惯了按返回键返回上一个界面，结果就退出了App",
                    status = SuggestStatus.Unhandled,
                    Author = new User("ataitai","abcabc")
                    {
                        NickName = "atai",
                        Id = 3,
                        Level = "①"
                    }
                },
                new Suggest
                {
                    Id = 2,
                    Title = "test",
                    Summary ="test",
                    status = SuggestStatus.Suggest,
                    Author = new User("yezifei","abcabc")
                    {
                        NickName = "叶飞大胖飞",
                        Id = 1,
                        Level = "⑩"
                    }
                },
                new Suggest
                {
                    Id = 3,
                    Title = "人人都是程序猿 学习进度 ",
                    Summary ="这个能不能进度快一些 个人觉得有些慢了 还有 讲到现在是在讲有关计算机的事情 " +
                    "和编程沾不到边 可能我看的心太急了吧 ",
                    status = SuggestStatus.Finish,
                    Author = new User("yuanyuan","abcabc")
                    {
                        NickName = "圆圆",
                        Id = 4,
                        Level = "①"
                    }
                },
                new Suggest
                {
                    Id = 4,
                    Title = "操作不方便",
                    Summary ="习惯了按返回键返回上一个界面，结果就退出了App",
                    status= SuggestStatus.Bug,
                    Author = new User("ataitai","abcabc")
                    {
                        NickName = "atai",
                        Id = 3,
                        Level = "①"
                    }
                },
                new Suggest
                {
                    Id = 5,
                    Title = " 评论文章后点赞，会直接跳到错误页面呢！",
                    Summary ="但刷新页面后再点赞就报提示：自己不能给自己点赞。",
                    status = SuggestStatus.Bug,
                    Author = new User("ataitai","abcabc")
                    {
                        NickName = "atai",
                        Id = 3,
                        Level = "①"
                    }
                },
                new Suggest
                {
                    Id = 6,
                    Title = "2个小bug",
                    Summary ="1.消息列表：勾选所有的复选框，全选框没有自动勾选2.反馈的建议中粘贴的图片，点击修改时不会显示",
                    status = SuggestStatus.Bug,
                    Author = new User("ataitai","abcabc")
                    {
                        NickName = "atai",
                        Id = 3,
                        Level = "①"
                    }
                },
                new Suggest
                {
                    Id = 7,
                    Title = "点赞就报错啦",
                    Summary =" ",
                    status = SuggestStatus.Finish,
                    Author = new User("ataitai","abcabc")
                    {
                        NickName = "atai",
                        Id = 3,
                        Level = "①"
                    }
                },
                new Suggest
                {
                    Id = 8,
                    Title = "这是咋情况？",
                    Summary =" ",
                    status = SuggestStatus.Bug,
                    Author = new User("ataitai","abcabc")
                    {
                        NickName = "atai",
                        Id = 3,
                        Level = "①"
                    }
                },
                new Suggest
                {
                    Id = 9,
                    Title = "好像发现了一个bug",
                    Summary ="点消息里面的文章链接，报错：链接：http://17bang.ren/Article/125",
                    status = SuggestStatus.Bug,
                    Author = new User("ataitai","abcabc")
                    {
                        NickName = "atai",
                        Id = 3,
                        Level = "①"
                    }
                },
            };
            _asideSuggest = new List<Suggest>
            {
                new Suggest
                {
                    News = "每周榜单：慷慨哥/奉献帝，求助单页可邀请"
                },
                new Suggest
                {
                    News = "协助流程中引入“开始协助”，总结付费阅读，及其评价评论 "
                },
                new Suggest
                {
                    News = "新增：帮帮币的购买和出售，使用帮帮币发布广告，用户捐赠，以及彩色用户标识功能 "
                },
                new Suggest
                {
                    News = "新增：我的关注关键字筛选和补足功能 "
                },
                new Suggest
                {
                    News = "新增：新人测试功能 "
                },
                new Suggest
                {
                    News = "新增：用户间消息/帮帮豆功能，重构评价功能，调整帮帮币使用和系统奖励政策等 "
                },
                new Suggest
                {
                    News = "新增：精品文章板块 "
                },
                new Suggest
                {
                    News = "新增：星级评价/求助总结/注册流程重构等功能"
                },
                new Suggest
                {
                    News = "新增：邀请注册/Email通知/酬谢时评价/个人资料/个人主页等功能 "
                },
            };
        }

        public IList<Suggest> Get()
        {
            return _suggest;
        }

        public int GetSum()
        {
            return _suggest.Count;
        }
        public IList<Suggest> GetExclude(SuggestStatus status)
        {
            return _suggest.Where(p => p.status == status).ToList();
        }
    }

    public static class SuggestExtension
    {
        public static IList<Suggest> GetPage(this IList<Suggest> ClassName, int pageSize, int pageIndex)
        {
            return ClassName.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}
