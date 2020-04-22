using System;
using Entity;
using HomeWork;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Mono.CSharp.Linq;


namespace HomeWork
{
    static class LinqMethod
    {
        public static Article csharpBasics, csharpHigh, htmlBasics, uiBasics, aboutYU, aboutFEI;
        private static IEnumerable<Article> articles;

        static User dfg = new User("飞哥", "123456");
        static User xiaoyu = new User("小鱼", "123456");

        static Keyword sql = new Keyword { Name = "SQL" };
        static Keyword csharp = new Keyword { Name = "C#" };
        static Keyword linq = new Keyword { Name = "linq" };
        static Keyword net = new Keyword { Name = "net" };
        static Keyword ui = new Keyword { Name = "ui" };
        static Keyword html = new Keyword { Name = "html" };

        static Comment better = new Comment() { Comments = "i can't say anything" };
        static Comment normal = new Comment() { Comments = "normal article" };
        static Comment soso = new Comment() { Comments = "just so so" };
        static Comment cool = new Comment() { Comments = "especial article" };
        static Comment nice = new Comment() { Comments = "nice article" };
        static Comment great = new Comment() { Comments = "great article" };
        static Comment super = new Comment() { Comments = "super nice article" };



        public static IEnumerable<Problem> problems;
        public static Problem aboutCSharp, aboutLinq, aboutSQL, aboutUI;
        //static LinqMethod()
        //{
        //    csharpBasics = new Article("C#基础介绍")
        //    {
        //        Author = dfg,
        //        Body = "基础简介",
        //        PublishTime = new DateTime(2019, 10, 3),
        //        Title = "C#基础介绍",
        //        Keywords = new List<Keyword> { sql, csharp, net },
        //        Comments = new List<Comment> { better, super, great, nice },
        //    };
        //    csharpHigh = new Article("C#高阶")
        //    {
        //        Author = dfg,
        //        Body = "something",
        //        PublishTime = new DateTime(2019, 11, 10),
        //        Title = "C#高阶",
        //        Keywords = new List<Keyword> { linq, net },
        //        Comments = new List<Comment> { better, super, great }
        //    };
        //    htmlBasics = new Article("html基础介绍")
        //    {
        //        Author = xiaoyu,
        //        Body = "html简介",
        //        PublishTime = new DateTime(2018, 12, 21),
        //        Title = "html基础介绍",
        //        Keywords = new List<Keyword> { html },
        //        Comments = new List<Comment> { soso, cool }
        //    };
        //    uiBasics = new Article("UI介绍")
        //    {
        //        Author = xiaoyu,
        //        Body = "UI简介",
        //        PublishTime = new DateTime(2019, 5, 23),
        //        Title = "UI介绍",
        //        Keywords = new List<Keyword> { ui },
        //        Comments = new List<Comment> { cool }
        //    };
        //    aboutYU = new Article("小鱼老师简介")
        //    {
        //        Author = xiaoyu,
        //        Body = "小鱼老师简介",
        //        PublishTime = new DateTime(2019, 1, 3),
        //        Title = "小鱼老师简介",
        //        Keywords = new List<Keyword> { html, ui },
        //        Comments = new List<Comment> { nice }
        //    };
        //    aboutFEI = new Article("飞哥简介")
        //    {
        //        Author = dfg,
        //        Body = "自由飞简介",
        //        PublishTime = new DateTime(2019, 1, 3),
        //        Title = "飞哥简介",
        //        Keywords = new List<Keyword> { csharp, linq, sql, net },
        //        Comments = new List<Comment> { better, super, great, nice, cool }
        //    };
        //    articles = new List<Article>
        //    { csharpBasics, csharpHigh, htmlBasics, uiBasics,aboutYU,aboutFEI };


        //    //aboutCSharp = new Problem
        //    //{
        //    //    Title = "C# Learning question",
        //    //    Author = xiaoyu,
        //    //    Reward = 4,
        //    //    PublishTime = new DateTime(2019, 5, 5)
        //    //};
        //    //aboutLinq = new Problem
        //    //{
        //    //    Title = "Linq Learning question",
        //    //    Author = xiaoyu,
        //    //    Reward = 7,
        //    //    PublishTime = new DateTime(2019, 4, 5)
        //    //};
        //    //aboutSQL = new Problem
        //    //{
        //    //    Title = "SQL Learning question",
        //    //    Author = xiaoyu,
        //    //    Reward = 0,
        //    //    PublishTime = new DateTime(2019, 5, 5)
        //    //};
        //    //aboutUI = new Problem
        //    //{
        //    //    Title = "UI Learning question",
        //    //    Author = dfg,
        //    //    Reward = 10,
        //    //    PublishTime = new DateTime(2019, 5, 5)
        //    //};
        //    //problems = new List<Problem> { aboutCSharp, aboutLinq, aboutSQL, aboutUI };
        //}
        /// <summary>
        /// 为求助（Problem）添加悬赏（Reward）属性，并找出每一篇求助的悬赏都大于5个帮帮币的文章作者
        /// </summary>
        public static void SearchReward()
        {
            var rewardGreaterThanFive = from s in problems
                                        where s.Reward > 5
                                        select s;
            foreach (var item in rewardGreaterThanFive)
            {
                Console.WriteLine(item.Author.UserName + "\t" + item.Title);
            }
            //var rewardGreaterThanFive1 = problems.Where(s => s.Reward > 5);
            //foreach (var item in rewardGreaterThanFive1)
            //{
            //    Console.WriteLine(item.Author.UserName + "\t" + item.Title);
            //}
        }

        /// <summary>
        /// 找出每个作者最近发布的一篇文章
        /// </summary>
        public static void find_AuthorRecentlyArticle()
        {
            var find_AuthorRecentlyArticle = from s in articles
                                             orderby s.PublishTime descending
                                             group s by s.Author into gm
                                             select new
                                             {
                                                 author = gm.Key,
                                                 title = gm.First()
                                             };
            foreach (var item in find_AuthorRecentlyArticle)
            {
                Console.WriteLine(item.author.UserName + "\t" + item.title.PublishTime);
            }
        }

        /// <summary>
        /// 1.找出“飞哥”发布的文章
        /// </summary>
        public static void Find_DFG_Article()
        {
            var find_DFG = from s in articles
                           where s.Author == dfg
                           select s;

            Console.WriteLine("\t ------------saparete line--------------\t");
            foreach (var item in find_DFG)
            {
                Console.WriteLine(item.Body);
            }
            //var find_DFG = articles.Where(s => s.Author == dfg);
        }

        /// <summary>
        /// 2.找出小鱼老师2019年后的文章
        /// </summary>
        public static void Find_YU_Article()
        {
            var find_YU = from s in articles
                          where s.Author == xiaoyu && s.PublishTime > new DateTime(2019, 1, 1)
                          select s;
            Console.WriteLine("\t ------------saparete line--------------\t");
            foreach (var item in find_YU)
            {
                Console.WriteLine(item.Body);
            }

            //var find_YU = articles.Where(s => s.Author == xiaoyu && s.PublishTime > new DateTime(2019, 1, 1));
        }

        /// <summary>
        /// //3.按发布时间升序 / 降序排列显示文章
        /// </summary>
        public static void AscendingAndDescendingArticle()
        {
            var ascendingArticle = from s in articles
                                   orderby s.PublishTime
                                   select s;

            Console.WriteLine("\t ------------saparete line--------------\t");
            foreach (var item in ascendingArticle)
            {
                Console.WriteLine(item.Title + "发布时间" + item.Author + item.PublishTime);
            }

            var descendingArticle = from s in articles
                                    orderby s.PublishTime descending
                                    select s;


            Console.WriteLine("\t ------------saparete line--------------\t");
            foreach (var item in descendingArticle)
            {
                Console.WriteLine(item.Title + "发布时间" + item.Author + item.PublishTime);
            }
            //var ascendingArticle = articles.OrderBy(s => s.PublishTime);
            //var descendingArticle = articles.OrderByDescending(s => s.PublishTime);
        }

        /// <summary>
        /// 4.统计每个用户各发布了多少篇文章
        /// </summary>
        public static void CountArticle()
        {
            var user_Article = from s in articles
                               group s by s.Author;

            Console.WriteLine("\t ------------saparete line--------------\t");
            foreach (var item in user_Article)
            {
                Console.WriteLine(item.Key.UserName);
                foreach (var i in item)
                {
                    Console.WriteLine(i.Title);
                }
            }
            //var user_Article = articles.GroupBy(s => s.Author);
        }

        /// <summary>
        /// 5.找出包含关键字“C#”或“.NET”的文章
        /// </summary>
        public static void FindSpecefiedKeyWord()
        {
            Console.WriteLine("\t ------------saparete line--------------\t");
            var csharp_Keywords = from s in articles
                                  where s.Keywords.Any(s => s.Name == "C#") ||
                                  s.Keywords.Any(s => s.Name == ".NET")
                                  select s;

            foreach (var item in csharp_Keywords)
            {
                Console.WriteLine(item.Title);
            }

            //var csharp_Keywords = articles.Where(s => s.Keywords.Any(s => s.Name == "C#") || s.Keywords.Any(s => s.Name == ".NET"));
        }

        /// <summary>
        /// 6.找出评论数量最多的文章
        /// </summary>
        public static void MaxCommentsOfArticle()
        {
            Console.WriteLine("\n ------------saparete line--------------\t");
            var articleComment = (from s in articles
                                  orderby s.Comments.Count() descending
                                  select s).First();

            Console.WriteLine(articleComment.Title);

            //var articleComment = articles.OrderByDescending(a => a.Comments.Count()).First();
        }

        /// <summary>
        /// 7.找出每个作者评论数最多的文章
        /// </summary>
        public static void MaxCommentsOfAuthor()
        {
            Console.WriteLine("\n ------------saparete line--------------\t");
            var CommentMax = from s in articles
                             orderby s.Comments.Count() descending
                             group s by s.Author into gm
                             select new
                             {
                                 Author = gm.Key,
                                 MaxComments = gm.First()
                             };
            foreach (var item in CommentMax)
            {
                Console.WriteLine(item.Author.UserName + "\t" + item.MaxComments.Title);
            }

            var CommentMax1 = articles.GroupBy(s => s.Author).Select(a => a.OrderByDescending(s => s.Comments.Count()).First());
            //foreach (var item in CommentMax1)
            //{
            //    Console.WriteLine(item.Author.UserName + "\t" + item.Title);
            //}


        }


    }
}




