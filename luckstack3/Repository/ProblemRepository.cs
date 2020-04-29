using _17bang.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Repository
{
    public class ProblemRepository : BaceRepository<Problem>
    {
        private static int _latestId;
        private static IList<Problem> _problem;

        static ProblemRepository()
        {
            _problem = new List<Problem>
            {
                new Problem
                {
                    Author = new User("yezifei","abcabc")
                    {
                        NickName = "大飞哥",
                        Id = 2,
                        Level = "⑩"
                    },
                    Id = 1,
                    Status = ProblemStatus.inprocess,
                    Title = "ASP 网站迁移 ",
                    Summary = "在服务器上把原先的asp网站整体迁移出来，在新的服务器上重新布置……",
                    Keywords = new List<Keyword>
                    {
                        new Keyword{Name = " asp "},
                        new Keyword{Name = " 数据库 "},
                    }
                },
                new Problem
                {
                    Author = new User("wpzwpz","abcabc")
                    {
                        NickName = "王月半子",
                        Id = 1,
                        Level = "⑩"
                    },
                    Id = 2,
                    Status = ProblemStatus.assist,
                    Title = "",
                    Summary = "",
                    Keywords = new List<Keyword>
                    {
                        new Keyword{Name = " 多线程 "},
                        new Keyword{Name = " JAVA "},
                        new Keyword{Name = " 编程开发语言 "}
                    },
                    Body = "123123123"
                },
                new Problem
                {
                    Author = new User("yezifei","abcabc")
                    {
                        NickName = "大飞哥",
                        Id = 2,
                        Level = "⑩"
                    },
                    Id = 3,
                    Status = ProblemStatus.Rewarded,
                    Title = "Winform里控件绑定数据源就会报错",
                    Summary = "项目里的控件绑定属性都会出现这个问题",
                    Keywords = new List<Keyword>
                    {
                        new Keyword{Name = "VisualStudio"},
                        new Keyword{Name = " 工具软件 "},
                        new Keyword{Name = " C# "},
                    }
                },
                new Problem
                {
                    Author = new User("yezifei","abcabc")
                    {
                        NickName = "大飞哥",
                        Id = 2,
                        Level = "⑩"
                    },
                    Id = 4,
                    Status = ProblemStatus.cancelled,
                    Title = "SQL Server多表查询,中间表有字段可能为空",
                    Summary = "如图,表B中的D,E,F可能会是空,SQL怎么写,才能保证数据的一致性",
                    Keywords = new List<Keyword>
                    {
                        new Keyword{Name = "数据库"},
                        new Keyword{Name = "sqlserver"},
                        new Keyword{Name = "SQL"},
                    }
                },
                new Problem
                {
                    Author = new User("yezifei","abcabc")
                    {
                        NickName = "大飞哥",
                        Id = 2,
                        Level = "⑩"
                    },
                    Id = 5,
                    Status = ProblemStatus.assist,
                    Title = "西安大专应届生找个JAVA开发的工作，有没有推荐的",
                    Summary = "本人3个月后毕业，自学3年JAVA，对J2EE的一整套开发体系非常熟悉，OA类的项目做的比较多。" +
                    "荣获第八届蓝桥杯JAVA C组个人赛全国一等奖，之后去上海实习几个月，因为一些原因必须回西安发展，" +
                    "但是投简历无数，要么没有音信，要么第一轮面试结束没有消息，要么学历不过关--。智联上西安的JAVA校招几乎没有" +
                    "，1个月过去了，还是没有工作，我都不求工资，只求有长远发展，不会的我都愿意学，但是不想去那种混日子的公司" +
                    "，要有激情，有创新，有热血的公司。有没有推荐的，或者那位大神觉得我可以内推一下我，至少给个面试机会",
                    Keywords = new List<Keyword>
                    {
                        new Keyword{Name = "JAVA"},
                        new Keyword{Name = "职场"},
                        new Keyword{Name = "顾问咨询"},
                    }
                }
            };
        }

        public static Problem GetId(int pageId)
        {
            return _problem.Where(p => p.Id == pageId).SingleOrDefault();
        }

        public int Save(Problem model)
        {
            _latestId++;
            model.Id = _latestId;
            _problem.Add(model);
            return _latestId;
        }

        public int GetSum()
        {
            return _problem.Count;
        }
        public IList<Problem> Get()
        {
            return _problem;
        }
        public void Add(Problem value)
        {
            _problem.Add(value);
        }
        public IList<Problem> GetExclude(ProblemStatus status)
        {
            return _problem.Where(p => p.Status == status).ToList();
        }


    }

    public static class ProblemExtension
    {
        public static IList<Problem> GetPage(this IList<Problem> ClassName, int pageSize, int pageIndex)
        {
            return ClassName.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }



}
