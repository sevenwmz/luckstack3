using Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Repository
{
    public class ArticleRepository
    {
        private DBHelper _support { set; get; }

        private static IList<Article> _article;

        static ArticleRepository()
        {
            User wpz = new User("wpzwpz", "abcabc")
            {
                NickName = "王月半子",
                Id = 2
            };

            _article = new List<Article>
            {

                new Article("ASP.NET RazorPages：CSRF跨站点请求伪造")
                {
                    Summary = "Cross-SiteRequestForgery：防御的核心在于除了用户的验证cookie以外，" +
                    "还要生成一个token，以确保链接/表单确实为服务器端生成。如何生成token？生成一个" +
                    "随机数从用户密码中生成……实现：操作类尽量使用Post（仅查询类使用Get）前台，Layout中传入，" +
                    "使用JavaScript附加后台，使用Filter进行封装。和钓鱼网站的区别MVC内置反欺骗（仅用于form表单）" +
                    "在form表单中添加：@@Html.AntiForgeryToken()生成一个hiden input，记录了一",
                    Id = 1,
                    Body = "1111111111111111111111111111",
                    Author = new User("yezifei","abcabc")
                    {
                        NickName = "自由飞",
                        Id = 1
                    },
                    Keywords = new List<Keyword>
                    {
                       new Keyword{Name ="CSRF"},
                       new Keyword{Name ="跨站点请求伪造"}
                    }
                },
                new Article("CSS：选择器")
                {
                    Summary = "Cross-SiteRequestForgery：防御的核心在于除了用户的验证cookie以外，还要生成一个token" +
                    "，以确保链接/表单确实为服务器端生成。如何生成token？生成一个随机数从用户密码中生成……实现：操作类" +
                    "尽量使用Post（仅查询类使用Get）前台，Layout中传入，使用JavaScript附加后台，使用Filter进行封装。" +
                    "和钓鱼网站的区别MVC内置反欺骗（仅用于form表单）在form表单中添加：@@Html.AntiForgeryToken()生成一" +
                    "个hiden input，记录了一 ",
                    Id = 2,
                    Body = "222222222222222",
                    Author = wpz,
                    Keywords = new List<Keyword>
                    {
                       new Keyword{Name ="前端"},
                       new Keyword{Name ="CSS"},
                       new Keyword{Name ="选择器"}
                    }
                },
                new Article("CSS：盒子模型、浮动和定位")
                {
                    Summary = "CSS 盒子模型适用样式：width/height流元素的高度和居中overflowborder：" +
                    "粗细/样式/颜色top/right/bottom/left为什么使用transparent？margin/padding：是否占用宽度？" +
                    "block和padding的不同margin合并为了避免浏览器兼容问题，通常都首先定义：margin:0;padding:0;display:block：" +
                    "默认宽度100%（占一行）inline：宽度随文本，不会占一行，margin有效，padding不会“撑起”父元素，hei ",
                    Id = 3,
                    Body = "33333333333333333333",
                    Author = wpz,
                    Keywords = new List<Keyword>
                    {
                       new Keyword{Name ="CSS"},
                       new Keyword{Name ="盒子模型"},
                       new Keyword{Name ="浮动"},
                       new Keyword{Name ="定位"}
                    }
                },
                new Article("源栈培训：ASP.NET MVC：分层架构 - CurrentUser")
                {
                    Summary = "1、很多时候我们需要当前用户2、当前用户a）需要从cookie中获取b）还需要数据库支持（验证）3、" +
                    "发布一个求助需要当前用户作为作者所以：方案（一）public interface IProblemService{int Publish(NewModel model, " +
                    "int authorId);}NewModel：存Title、Body等数据authorId：-- 不能只取cookie中的userId，还得有token结论：麻烦方案" +
                    "（二）当前用户信息直接由SRV获取既然SRV能够获取cookie =》 ",
                    Id = 4,
                    Body = "44444444444444444441",
                    Author = wpz,
                    Keywords = new List<Keyword>
                    {
                       new Keyword{Name ="ASP.NET"},
                       new Keyword{Name ="MVC"},
                       new Keyword{Name ="当前用户"}
                    }
                },
                new Article("周三晚7点：弄明白你究竟花时间学到的是什么")
                {
                    Summary = "周三晚7点：弄明白你究竟花时间学到的是什么最快找到工作，就学这个编程语言！OK，承认了，标题党" +
                    "，^_^哪有什么最快？想一想，找工作，为什么有讨人嫌的要求：两年工作经验听说过么？10000小时理论？这些都说" +
                    "明一个什么问题？有些东西，要用时间堆！人总是想走捷径，但有些东西，没有捷径。恰恰相反，有时候录，最近的路" +
                    "就是最远的路。举例：学英语。（各种学习方法，直到碰到我老婆……）我愿证明：心地单纯，是一种福祉。IT培训，也" +
                    "是一种能力锻炼两个小时你都没有做出这道题，这两个小时被你浪费掉了么？",
                    Id = 5,
                    Body = "455555555555555555555551",
                    Author = wpz,
                    Keywords = new List<Keyword>
                    {
                       new Keyword{Name ="学编程"},
                       new Keyword{Name ="时间"},
                       new Keyword{Name ="效率"}
                    }
                },
                new Article("周三晚7点：弄明白你究竟花时间学到的是什么")
                {
                    Summary = "周三晚7点：弄明白你究竟花时间学到的是什么最快找到工作，就学这个编程语言！OK，承认了，标题党" +
                    "，^_^哪有什么最快？想一想，找工作，为什么有讨人嫌的要求：两年工作经验听说过么？10000小时理论？这些都说" +
                    "明一个什么问题？有些东西，要用时间堆！人总是想走捷径，但有些东西，没有捷径。恰恰相反，有时候录，最近的路" +
                    "就是最远的路。举例：学英语。（各种学习方法，直到碰到我老婆……）我愿证明：心地单纯，是一种福祉。IT培训，也" +
                    "是一种能力锻炼两个小时你都没有做出这道题，这两个小时被你浪费掉了么？",
                    Id = 6,
                    Body = "666666666666666666666",
                    Author = wpz,
                    Keywords = new List<Keyword>
                    {
                       new Keyword{Name ="学编程"},
                       new Keyword{Name ="时间"},
                       new Keyword{Name ="效率"}
                    }
                },

            };
        }

        #region For Save Keyword
        /// <summary>
        /// Get keywordId from database
        /// </summary>
        /// <param name="keywordsName">keyword name</param>
        /// <returns></returns>
        public int GetKeywordsId(string keywordsName)
        {
            int keywordId = GetKeywordIdBy(keywordsName);

            if (keywordId != 0)
            {
                return keywordId;
            }//else nothing.
            return NewKeyword(keywordsName);
        }

        /// <summary>
        /// Save this keyword into database and return this keywordId
        /// </summary>
        /// <param name="keywordsName">Keyword name</param>
        public int NewKeyword(string keywordsName)
        {
            using (DbConnection connection = _support.Connection)
            {
                connection.Open();
                DbCommand addNewKeyword = new SqlCommand("Insert Keyword(Name,Used) Values(@Keyword,0) Set @NewId = @@Identity ", (SqlConnection)connection);
                addNewKeyword.Parameters.Add(new SqlParameter("@Keyword", keywordsName));

                SqlParameter pId = new SqlParameter("@NewId", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                addNewKeyword.ExecuteNonQuery();

                return Convert.ToInt32(pId);
            }
        }

        /// <summary>
        /// Check keyword is exist or not in database
        /// </summary>
        /// <param name="keywordsName">Need keyword name</param>
        /// <returns></returns>
        public int GetKeywordIdBy(string keywordsName)
        {
            using (DbConnection connection = _support.Connection)
            {
                connection.Open();

                DbCommand checkKeywordsExist = new SqlCommand("Select Id From Keyword where Name = @Keyword", (SqlConnection)connection);
                checkKeywordsExist.Parameters.Add(new SqlParameter("@Keyword", keywordsName));

                object reader = checkKeywordsExist.ExecuteScalar();
                if (reader == DBNull.Value)
                {
                    return 0;
                }//else nothing.
                if (string.IsNullOrEmpty(reader.ToString()))
                {
                    return 0;
                }//else nothing.
                return Convert.ToInt32(reader);
            }
        }

        /// <summary>
        /// Plus Used Keyword
        /// </summary>
        /// <param name="id">Need one keyword id</param>
        public void PlusUsedKeyword(int id)
        {
            using (DbConnection connection = _support.Connection)
            {
                connection.Open();

                //Plus keyword use.
                DbCommand plusUsed = new SqlCommand(
                $"Update Keyword Set Used += 1 Where Id = (Select Id From Keywordwhere Name = {id}) ", (SqlConnection)connection);
                plusUsed.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Save to n:n relation Table
        /// </summary>
        /// <param name="articleId">Need articleId</param>
        /// <param name="keywordsId">Need keywordId</param>
        public void AttachKeyword(int articleId, int keywordId)
        {
            using (DbConnection connection = _support.Connection)
            {
                connection.Open();
                DbCommand command = new SqlCommand($"Insert KeywordToArticle(ArticleNameId,KeywordId) Values({articleId},{keywordId})", (SqlConnection)connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        /// <summary>
        /// Return Article Id
        /// </summary>
        /// <param name="title">Need article title name</param>
        /// <returns></returns>
        public int GetArticleId(string title)
        {
            using (DbConnection connection = _support.Connection)
            {
                connection.Open();
                DbCommand command = new SqlCommand("Select Id From Article Where Title = @KTitle", (SqlConnection)connection);
                command.Parameters.Add(new SqlParameter("@KTitle", title));
                object reader = command.ExecuteScalar();
                return Convert.ToInt32(reader);
            }
        }


        internal IList<Article> GetByAuthor(int authorId)
        {
            return _article.Where(a => a.Author.Id == authorId).ToList();
        }

        private int _latestId { set; get; }

        public void Save(Article editPublish)
        {
            _latestId++;
            editPublish.Id = _latestId;
            _article.Add(editPublish);
        }

        public static Article GetId(int pageId)
        {
            return _article.Where(a => a.Id == pageId).SingleOrDefault();
        }

        public IList<Article> GetPaged(int pageSize, int pageIndex)
        {
            return _article.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获得总数
        /// </summary>
        /// <returns></returns>
        public int GetSum()
        {
            return _article.Count;
        }
        public IList<Article> Get()
        {
            return _article;
        }
        public void Add(Article value)
        {
            _article.Add(value);
        }

    }
}
