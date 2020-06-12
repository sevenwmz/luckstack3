using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_Of_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            #region Frist day /将User类映射到数据库：  http://17bang.ren/Article/554
            //作业 http://17bang.ren/Article/554
            //将User类映射到数据库： 
            //1.使用EF的API直接建库建表删库
            {
                //new Repository_Of_EFCore().Database.EnsureCreated();
                //new Repository_Of_EFCore().Database.EnsureDeleted();
            }
            //2.使用Migration工具建库建表
            {
                //Add-Migration AddDatabase_and_User
                //Update-Database
            }
            //Migration之后，在User类上添加一列：int FailedTry（尝试登陆失败次数），使用Migration工具： 
            {
                //Add-Migration Add_User_FailedTry
            }
            //1.将改动同步到数据库
            {
                //Update-Database
            }
            //2.回退数据库到FailedTry添加之前
            {
                //Update-Database 20200608131656_AddDatabase_and_User
            }
            #endregion

            #region Scend Day 在EF6上完成上一课作业  http://17bang.ren/Article/626
            //作业： http://17bang.ren/Article/626
            //在EF6上完成上一课作业
            {
                //将User类映射到数据库： 
                //1.使用EF的API直接建库建表删库
                {
                    //new Repository_Of_EF6().Database.CreateIfNotExists();
                }
                //2.使用Migration工具建库建表
                {
                    //EntityFramework6\Update-Database
                    //EntityFramework6\Add-Migration Init
                    //EntityFramework6\Update-Database
                }
                //Migration之后，在User类上添加一列：int FailedTry（尝试登陆失败次数），使用Migration工具： 
                {
                    //EntityFramework6\Add-Migration Add_User_FailedTry
                }
                //1.将改动同步到数据库
                {
                    //EntityFramework6\Update-Database
                }
                //2.回退数据库到FailedTry添加之前
                {
                    //EntityFramework6\Update-Database -TargetMigration:Init
                }
            }
            #endregion

            #region Day Three  EF and EFCore Config Logger http://17bang.ren/Article/673
            //            作业 http://17bang.ren/Article/673
            //1.能够在EF core上配置成功Logger到Debug窗口
            ////仅在调试状态使用

            {
                //#if DEBUG
                //.EnableSensitiveDataLogging(true)
                //#endif
            }

            //2.能够在EF6上配置成功Logger到控制台
            {
                //new Repository_Of_EF6().Database.Log = Console.Write;
            }
            #endregion

            #region Day fourth .利用EF，插入3个User对象   http://17bang.ren/Article/674
            //            作业 http://17bang.ren/Article/674
            //1.利用EF，插入3个User对象
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //repository.AddRange(
                //    new User{Name = "Seven"}, 
                //    new User { Name = "Thin_Man" },
                //    new User { Name = "Funny_Guy" });
                //repository.SaveChanges();
            }
            //2.通过Id找到其中一个User对象
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //User findUser_1 = repository.Find<User>(1);
                //Console.WriteLine(findUser_1.Name);
            }
            //3.修改该User对象的Name属性，将其同步到数据库
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //User findUser_1 = repository.Find<User>(1);
                //findUser_1.Name = "HandSome Seven";
                //repository.SaveChanges();
                //Console.WriteLine(findUser_1.Name);
            }
            //4.不加载User对象，仅凭其Id用一句Update SQL语句完成上题
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //User user = new User { Id = 1 };
                //repository.Attach<User>(user);
                //user.Name = "HandSome nice Seven";
                //repository.SaveChanges();
            }
            //5.删除该Id用户
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //User u2 = repository.Find<User>(2);
                //repository.Remove<User>(u2);
                //repository.SaveChanges();
            }
            #endregion

            #region Use Linq to EntityFramework   http://17bang.ren/Article/556
            //            作业 http://17bang.ren/Article/556
            //利用Linq to EntityFramework，实现方法：GetBy(IList < ProblemStatus > exclude, bool hasReward, bool descByPublishTime)，该方法可以根据输入参数： 
            //IList<ProblemStatus> exclude：不显示（排除）某些状态的求助
            //bool hasReward：只显示已有酬谢的求助（如果传入值为true的话） 
            //bool descByPublishTime：按发布时间正序还是倒序
            //参考：求助列表（不显示 / 只显示）和文章列表（正序 / 倒序）
            {
                //new ProblemRepository().GetBy(new List<ProblemStatus> { new ProblemStatus { } }, false, false);
            }
            #endregion

            #region OnModelCreating()和Data Annotations     http://17bang.ren/Article/558
            //            作业 http://17bang.ren/Article/558
            //分别使用OnModelCreating()和Data Annotations，完成以下配置：    In [Repository_Of_EFCore]
            //将之前的User类名改为Register，但仍然能对应表User
            //将之前的User属性Name改成UserName，但仍然能对应表User的列Name
            //将Name的长度限制为256
            //Password不能为空
            //将User表的主键设置在Name列上
            //User类中的属性FailedTry不用存储到数据库中
            //给CreateTime属性添加一个非聚集唯一索引
            #endregion

            #region 课间作业：Email和User有一对一的关系 	http://17bang.ren/Article/675
            //            课间作业： 	http://17bang.ren/Article/675
            //Email和User有一对一的关系，参照课堂演示，在数据库上建立User外键引用Email的映射
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();

                //User wpz = new User { Name = "Seven-2", Password = "1234" };
                //Email email = new Email { EmailLocation = "123456@qq.com" };
                //wpz.SendTo = email;
                //email.FromWho = wpz;

                //repository.Add<User>(wpz);
                //repository.Add<Email>(email);
                //repository.SaveChanges();
            }
            #endregion

            #region 发布文章和求助时包含关键字   http://17bang.ren/Article/560
            //            作业： http://17bang.ren/Article/560
            //发布文章和求助时包含关键字
            {
                //Add-Migration Add_Article_and_Problem_To_Keywords
                //Update-Database
            }
            //可以按关键字筛选求助
            {
                #region Insert Data
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();

                //Keywords keywords_1 = new Keywords { Name = "Keywords-1" };
                //Keywords keywords_2 = new Keywords { Name = "Keywords-2" };

                ////----------------------------------------------------------------------------------------------

                //Article article_1 = new Article { Title = "Insert Article Title -1", Body = "Insert Article Body -1", Summary = "None" };
                //Article article_2 = new Article { Title = "Insert Article Title -2", Body = "Insert Article Body -2", Summary = "None" };

                //article_1.ArticleHave = new List<Keywords_Of_Article>();
                //article_1.ArticleHave.Add(new Keywords_Of_Article { Article = article_1, Keyword = keywords_1 });
                //article_1.ArticleHave.Add(new Keywords_Of_Article { Article = article_1, Keyword = keywords_2 });

                //article_2.ArticleHave = new List<Keywords_Of_Article>();
                //article_2.ArticleHave.Add(new Keywords_Of_Article { Article = article_2, Keyword = keywords_1 });
                //article_2.ArticleHave.Add(new Keywords_Of_Article { Article = article_2, Keyword = keywords_2 });

                //repository.Articles.AddRange(new Article[] { article_1 , article_2 });
                ////----------------------------------------------------------------------------------------------

                //Problem problem_1 = new Problem { Title = "Insert problem Title -1", Body = "Insert problem Body -1", Reward = 5 };
                //Problem problem_2 = new Problem { Title = "Insert problem Title -2", Body = "Insert problem Body -2", Reward = 5 };
                //Problem problem_3 = new Problem { Title = "Insert problem Title -3", Body = "Insert problem Body -3", Reward = 5 };

                //problem_1.ProblemHave = new List<Keywords_Of_Problem>();
                //problem_1.ProblemHave.Add(new Keywords_Of_Problem { Problem = problem_1, Keyword = keywords_1 });
                //problem_1.ProblemHave.Add(new Keywords_Of_Problem { Problem = problem_1, Keyword = keywords_2 });

                //problem_2.ProblemHave = new List<Keywords_Of_Problem>();
                //problem_2.ProblemHave.Add(new Keywords_Of_Problem { Problem = problem_2, Keyword = keywords_1 });
                //problem_2.ProblemHave.Add(new Keywords_Of_Problem { Problem = problem_2, Keyword = keywords_2 });

                //problem_3.ProblemHave = new List<Keywords_Of_Problem>();
                //problem_3.ProblemHave.Add(new Keywords_Of_Problem { Problem = problem_3, Keyword = keywords_1 });
                //repository.Problem.AddRange(new Problem[] { problem_1, problem_2, problem_3 });
 
                ////----------------------------------------------------------------------------------------------

                //repository.SaveChanges();
                #endregion
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //Keywords haveProblem = repository.Keywords.Include(k => k.Of_ThisProblem).ThenInclude(k => k.Problem).First(k => k.Name == "Keywords-1");

                //haveProblem.Of_ThisProblem = haveProblem.Of_ThisProblem ?? new List<Keywords_Of_Problem>();
                //haveProblem.Of_ThisProblem.Where(p=>p.Keyword == haveProblem);

                //foreach (var item in haveProblem.Of_ThisProblem)
                //{
                //    Console.WriteLine(item.Problem.Title);
                //}
            }
            //能够按作者 / 分类显示文章列表
            {
                //Add-Migration AddUserAndProblem_ForeginKey
                {
                    ////Insert data fail,I can't did it.
                    //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                    //Kind kind1 = new Kind { Name = "Status-1" };
                    //Kind kind2 = new Kind { Name = "Status-2" };
                    //Kind kind3 = new Kind { Name = "Status-3" };
                    //repository.Kinds.AddRange(new Kind[] { kind1, kind2, kind3 });

                    //User seven = repository.Users.Where(u => u.Name == "Seven").FirstOrDefault();
                    //User seven_1 = repository.Users.Where(u => u.Name == "Seven-1").FirstOrDefault();


                    //Kind kind_1 = repository.Kinds.Where(k => k.Name == "Status-1").FirstOrDefault();
                    //Kind kind_2 = repository.Kinds.Where(k => k.Name == "Status-2").FirstOrDefault();
                    //Kind kind_3 = repository.Kinds.Where(k => k.Name == "Status-3").FirstOrDefault();
                    //Problem problem = new Problem
                    //{
                    //    Title = "Problem Title",
                    //    Body = "nothing",
                    //    Summary = "nothing",
                    //    PublishTime = DateTime.Now.AddDays(-12),
                    //    Author = seven,
                    //    HaveKind = kind_1,
                    //    Reward = 10,
                    //    Statu = ProblemStatus.inprocess
                    //};
                    //Problem problem1 = new Problem
                    //{
                    //    Title = "Problem Title-1",
                    //    Body = "nothing",
                    //    Summary = "nothing",
                    //    PublishTime = DateTime.Now.AddDays(-13),
                    //    Author = seven,
                    //    HaveKind = kind_2,
                    //    Reward = 10,
                    //    Statu = ProblemStatus.inprocess
                    //};
                    //Problem problem2 = new Problem
                    //{
                    //    Title = "Problem Title-2",
                    //    Body = "nothing",
                    //    Summary = "nothing",
                    //    PublishTime = DateTime.Now.AddDays(-143),
                    //    Author = seven_1,
                    //    HaveKind = kind_2,
                    //    Reward = 10,
                    //    Statu = ProblemStatus.Rewarded
                    //};
                    //Problem problem3 = new Problem
                    //{
                    //    Title = "Problem Title-3",
                    //    Body = "nothing",
                    //    Summary = "nothing",
                    //    PublishTime = DateTime.Now.AddDays(-143),
                    //    Author = seven_1,
                    //    HaveKind = kind_3,
                    //    Reward = 10,
                    //    Statu = ProblemStatus.Rewarded
                    //};
                    //IList<Problem> tempProblems = new List<Problem> { problem, problem1, problem2, problem3 };
                    //repository.Problem.AddRange(new Problem[] { problem, problem1, problem2, problem3 });

                    //repository.SaveChanges();
                }
                {
                    //// It's of count problem of Author
                    //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                    //User userHaveThisProblem = repository.Users.Include(u => u.Problems).FirstOrDefault(u => u.Name == "Seven");

                    //userHaveThisProblem.Problems = userHaveThisProblem.Problems ?? new List<Problem>();
                    //userHaveThisProblem.Problems.Where(p => p.Author == userHaveThisProblem);
                    //foreach (var item in userHaveThisProblem.Problems)
                    //{
                    //    Console.WriteLine(item.Title);
                    //}
                }
                //Add-Migration AddKindAndProblem_ForeginKey
                {
                    //// It's of count problem of Kind
                    //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                    //Kind haveThisKindProblem = repository.Kinds.Include(k => k.ThisProblem).FirstOrDefault(k=>k.Name == "代协助");

                    //haveThisKindProblem.ThisProblem = haveThisKindProblem.ThisProblem ?? new List<Problem>();
                    //haveThisKindProblem.ThisProblem.Where(k=>k.HaveKind == haveThisKindProblem);
                    //foreach (var item in haveThisKindProblem.ThisProblem)
                    //{
                    //    Console.WriteLine(item.Title);
                    //}
                }
            }
            //能够选择文章列表的排序方向（按发布时间顺序倒序）和每页显示格式（50篇标题 / 10篇标题 + 摘要） 
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //IList<Problem> tempProblems = new List<Problem>();
                //bool show_50_Title = true;
                //bool publishTimeDesc = true;
                //int takeProblem = 0;
                //if (show_50_Title)
                //{
                //    if (publishTimeDesc)
                //    {
                //        tempProblems = repository.Problem.OrderByDescending(p => p.PublishTime).Skip(takeProblem).Take(50).ToList();
                //    }
                //    tempProblems = repository.Problem.OrderBy(p => p.PublishTime).Skip(takeProblem).Take(50).ToList();
                //    takeProblem += 50;
                //}
                //else
                //{
                //    if (publishTimeDesc)
                //    {
                //        tempProblems = repository.Problem.OrderByDescending(p => p.PublishTime).Skip(takeProblem).Take(10).ToList();
                //    }
                //    tempProblems = repository.Problem.OrderBy(p => p.PublishTime).Skip(takeProblem).Take(10).ToList();
                //    takeProblem += 10;
                //}
                //foreach (var item in tempProblems)
                //{
                //    Console.WriteLine(item.Title, item.Summary);
                //}

            }
            //发布文章会：扣掉作者1枚帮帮币、增加10个帮帮点
            {
                //Add-Migration Add_Bmoney_and_user_FK
                {
                    ////Insert data Of BMoney
                    //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                    //User user = repository.Users.Where(u => u.Name == "Seven").FirstOrDefault();
                    //BMoney money_1  = new BMoney { Owner = user, LeftBMoney = 10, LeftBPoint = 100,LatesTime = DateTime.Today.AddDays(-10), Detail = "Register Succses Award"};
                    //repository.BMoneys.Add(money_1);
                    //repository.SaveChanges();
                }
                {
                    //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                    //Article article = new Article { Title = "It's for minus author one bmoney" , Body="nothing", PublishTime = DateTime.Now, Summary ="nothing"};
                    //User user = repository.Users.Where(u => u.Name == "Seven").FirstOrDefault();
                    //user.articles = new List<Article>();
                    //user.articles.Add(article);
                    //repository.Articles.Add(article);

                    //BMoney money = repository.BMoneys.OrderByDescending(m => m.LatesTime).Where(u => u.OwnerName == "Seven").FirstOrDefault();
                    //BMoney bMoney = new BMoney { Owner = user, LeftBMoney = (money.LeftBMoney - 1), LeftBPoint = (money.LeftBPoint + 10),LatesTime = DateTime.Now, Detail = "Publish new article" };
                    //repository.BMoneys.Update(bMoney);
                    //repository.SaveChanges();
                }
            }
            //发布求助时可以设置悬赏帮帮币，发布后会被冻结，求助被解决时会划拨给好心人
            {
                ////Add-Migration Add_BMoney_FreezingMoney
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //User wpz = repository.Users.Where(u => u.Name == "Seven").FirstOrDefault();
                //Kind kind = repository.Kinds.Where(k => k.Name == "Status-1").FirstOrDefault();
                //Problem needHelp = new Problem
                //{
                //    Author = wpz,
                //    Title = "For freezing BMoney",
                //    Body = "nothing",
                //    Summary = "nothing",
                //    HaveKind = kind,
                //    PublishTime = DateTime.Now.AddDays(-25),
                //    Reward = 5,
                //    Statu = ProblemStatus.assist
                //};
                //repository.Problem.Add(needHelp);
                //BMoney getThisUserLeftBmoney = repository.BMoneys.OrderByDescending(b => b.LatesTime).Where(b => b.Owner == wpz).FirstOrDefault();
                //BMoney moneyChange = new BMoney
                //{
                //    Owner = wpz,
                //    Detail = "Publish new problem,use 5 BMoney",
                //    FreezingMoney = 5,
                //    LatesTime = DateTime.Now.AddDays(-25),
                //    LeftBMoney = getThisUserLeftBmoney.LeftBMoney - 5,
                //    LeftBPoint = getThisUserLeftBmoney.LeftBPoint
                //};
                //repository.BMoneys.Add(moneyChange);
                //repository.SaveChanges();
                ////------------------------------here is after solution problem---------------------------------
                //User wpz_1 = repository.Users.Where(u => u.Name == "Seven-1").FirstOrDefault();
                //BMoney AddThisUserLeftBmoney = repository.BMoneys.OrderByDescending(b => b.LatesTime).Where(b => b.Owner == wpz_1).FirstOrDefault();
                ////Just take any status use for finish funtion, if real at company,i will get problem id from Url
                //needHelp.Statu = ProblemStatus.Rewarded;
                //if (needHelp.Statu == ProblemStatus.Rewarded)
                //{
                //    BMoney payFor = repository.BMoneys.Where(b => b.Id == moneyChange.Id).SingleOrDefault();
                //    BMoney getPay = repository.BMoneys.Where(b => b.Id == wpz_1.Id).SingleOrDefault();
                //    payFor.FreezingMoney = 0;
                //    BMoney insertNewRow = new BMoney
                //    {
                //        Owner = wpz_1,
                //        Detail = $@"Answer question get award,adopt problem name '{needHelp.Title}',and get reward income is '{needHelp.Reward}' ",
                //        LatesTime = DateTime.Now,
                //        LeftBMoney = AddThisUserLeftBmoney.LeftBMoney + needHelp.Reward,
                //        LeftBPoint = AddThisUserLeftBmoney.LeftBPoint,
                //        FreezingMoney = 0
                //    };
                //    repository.BMoneys.Update(payFor);
                //    repository.BMoneys.Add(insertNewRow);
                //    repository.SaveChanges();
                //}
            }
            //帮帮点和帮帮币的每一次变更都会被记录并可以显示
            {
                ////Finish on this homework
                //发布文章会：扣掉作者1枚帮帮币、增加10个帮帮点
            }
            //消息列表按未读 / 已读排序
            {
                {
                    ////Insert data to database
                    //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                    //User user = repository.Users.Where(u => u.Name == "Seven").SingleOrDefault();
                    //Message message_1 = new Message
                    //{
                    //    Owner = user,
                    //    Content = "Just show to meself-1",
                    //    MessageStatus = MessageStatus.SomeOnePickUp,
                    //    PublishTime = DateTime.Now.AddDays(-10),
                    //    HasCheck = true,
                    //    HasRead = true
                    //};
                    //Message message_2 = new Message
                    //{
                    //    Owner = user,
                    //    Content = "Just show to meself-2",
                    //    MessageStatus = MessageStatus.SomeOnePickUp,
                    //    PublishTime = DateTime.Now.AddDays(-15),
                    //    HasCheck = false,
                    //    HasRead = false
                    //};
                    //Message message_3 = new Message
                    //{
                    //    Owner = user,
                    //    Content = "Just show to meself-3",
                    //    MessageStatus = MessageStatus.SomeOnePickUp,
                    //    PublishTime = DateTime.Now.AddDays(-1),
                    //    HasCheck = true,
                    //    HasRead = true
                    //};
                    //Message message_4 = new Message
                    //{
                    //    Owner = user,
                    //    Content = "Just show to meself-4",
                    //    MessageStatus = MessageStatus.SomeOnePickUp,
                    //    PublishTime = DateTime.Now,
                    //    HasCheck = false,
                    //    HasRead = false
                    //};

                    //message_1.Owner = user;
                    //message_2.Owner = user;
                    //message_3.Owner = user;
                    //message_4.Owner = user;

                    //repository.Messages.AddRange(message_1, message_2, message_3, message_4);
                    //repository.SaveChanges();
                }
                {
                    //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                    //IList<Message> message = new List<Message>();
                    //message = repository.Messages.OrderByDescending(m => m.HasRead == false).Where(m => m.OwnerName == "Seven").Take(10).ToList();
                    ////User myMessage = repository.Users.Include(u=>u.HaveMessages).

                    //foreach (var item in message)
                    //{
                    //    Console.WriteLine($"{item.Content}++{item.HasRead.ToString()}");
                    //}
                }
            }
            #endregion
        }
    }
}
