using System;
using Entity;
using HomeWork;
using DontWatch;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace SevenLearnCsharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region 值的值传递和引用  之前作业完结

            //int a = 18;

            //HomeWork person = new HomeWork();//值的值传递
            //person.ValuePass(a);
            //Console.WriteLine(a);
            //Console.WriteLine("------------------------");

            //HomeWork otherPerson = new HomeWork();//值的引用传递
            //otherPerson.ReferencePass(ref a);
            //Console.WriteLine(a);
            //Console.WriteLine("--------------------------");

            //HomeWork name = new HomeWork { _name = "王月半子" };//引用类型的值传递
            //ChangeName(name);
            //Console.WriteLine(name._name);
            //Console.WriteLine("--------------------------");

            //HomeWork newName = new HomeWork { _name = "王月半子" };//引用类型的引用传递
            //ChangeingName(ref newName);
            //Console.WriteLine(newName._name);



            #endregion

            #region 第一天作业 观察“一起帮”的： 功能作业https://zhuanlan.zhihu.com/p/92362781
            //User of class method. 
            //Entity.User User = new Entity.User();
            //User.Register();
            //User.Login();

            ////problem of class method ( inside null)
            //Entity.Problem Problem = new Entity.Problem();
            //Problem.Publish();

            ////HeloMoney of call method (inside null)

            //Entity.HelpMoney Helomoney = new Entity.HelpMoney();
            //Helomoney.BodyShow();

            #endregion

            #region Secend Day Homework. https://zhuanlan.zhihu.com/p/92470130
            //1.user.Password在类的外部只能改不能读
            //Entity.User Password = new Entity.User();
            //Password.Password = "123456";

            //2.如果user.Name为“admin”，输入时修改为“系统管理员”
            //Entity.User user = new Entity.User();
            //user.UserName = "admin";

            //3.problem.Reward不能为负数
            //Entity.Problem problem = new Entity.Problem();
            //problem.Reward = -1;


            //调用这些类的有参/无参构造函数，生成这些类的对象，调用他们的方法

            //3. 一起帮的求助可以有多个（最多10个）关键字，请为其设置索引器，以便于我们通过其整数下标进行读写
            //Entity.Problem problem = new Entity.Problem();
            //Console.WriteLine(problem[52]);

            //设计一种方式，保证：每一个Problem对象一定有Body赋值每一个User对象一定有Name和Password赋值
            //Go to (Problem Page) OR (User Page )watch.

            #endregion

            #region Third Day Homework.  https://zhuanlan.zhihu.com/p/95261748 
            //1.Publish()：发布一篇求助，并将其保存到数据库
            //Entity.Problem problem = new Entity.Problem();
            //problem.HelpMe();

            ///3.设计一个类FactoryContext，保证整个程序运行过程中，
            ///无论如何，外部只能获得它的唯一的一个实例化对象。（提示：设计模式之单例）
            ///
            //new Entity.FactoryContext().Show(); // probably is private function make this red line...


            ///4.想一想，为什么Publish()方法不是放置在User类中呢？
            ///用户（user）发布（Publish）一篇文章（article）
            ///，不正好是user.Publish(article) 么？
            ///
            ///这里也有发布的啊，如果那里有需要发布，继承一个就好了，或者直接引用这里的方法就可以。
            ///如果这么说对的话，我还可以继续说，如果说的不对那就当我没说。




            ///5.自己实现一个模拟栈（MimicStack）类，入栈出栈数据均为int类型，包含如下功能：
            ///5.1出栈Pop()，弹出栈顶数据
            ///5.2入栈Push()，可以一次性压入多个数据
            ///5.3 出 / 入栈检查，
            ///5.4如果压入的数据已超过栈的深度（最大容量），提示“栈溢出”如果已弹出所有数据，提示“栈已空”
            //MimicStack stack = new MimicStack();
            //stack.push(223573);
            //stack.pop();
            //stack.pop();
            //stack.push(123);
            //stack.push(22743);
            //stack.push(233);
            //stack.push(22213);
            //stack.pop();
            //stack.push(32213);
            //stack.push(52213);
            //stack.push(2213);
            //stack.pop();
            //stack.push(22813);
            //stack.push(22313);
            //stack.push(224213);
            //stack.push(92212463);
            //stack.push(1);
            //stack.push(1);
            //stack.push(1);
            //stack.push(1);
            //stack.pop();
            //stack.pop();
            //stack.pop();
            //stack.pop();
            //stack.pop();
            //stack.pop();
            //stack.pop();
            //stack.pop();
            //stack.pop();
            //stack.pop();
            //stack.pop();
            //stack.pop();


            //3.实例化文章和意见建议，调用他们：继承自父类的属性和方法自己的属性和方法
            // it's for parents 
            //Entity.Content content = new Article();//here is for article page.
            //content.Release();
            //content = new Problem();//here is for problem page.
            //content.Release();
            //content = new Suggest();//here is for suggest page.
            //content.Release();
            //Article article = new Article();
            //4.再为之前所有类（含User、HelpMoney等）抽象一个基类：Entity，
            //包含一个只读的Id属性。试一试，Suggest能有Id属性么？

            ///只是把任务要求造出来了，具体啥意思也不知道。suggest ID指的是啥？？？
            ///这个作业后补。
            #endregion

            #region Fourth Day Homework "多态"  https://zhuanlan.zhihu.com/p/93053223
            ///1.添加一个新类ContentService，其中有一个发布（Publish()）方法：
            /// 如果发布Article，需要消耗一个帮帮币
            /// 如果发布Problem，需要消耗其设置悬赏数量的帮帮币
            /// 如果发布Suggest，不需要消耗帮帮币
            ///最后将内容存到数据库中，三个类存数据库的方法是完全一样的，
            ///现在用Console.WriteLine()代替。根据我们学习的继承和多态知识，实现上述功能。
            ///
            /// 
            ///maybe i made big mistake.homework write not like this.---T_T||... 
            //ContentService contentService = new ContentService("Article",20);
            //contentService.publish();

            #endregion

            #region Fifth Day  思考之前的Content类，该将其抽象成抽象类还是接口？https://zhuanlan.zhihu.com/p/93224519
            ///1.思考之前的Content类，该将其抽象成抽象类还是接口？为什么？并按你的想法实现。
            /// 
            //思考应该用interface接口，但是一改Errors爆满，无从下手改。。。。

            ///2.一起帮里的求助总结、文章和意见建议，以及他们的评论，
            ///都有一个点赞（Agree）/踩（Disagree）的功能，赞和踩都会增减作者及评价者的帮帮点。
            ///能不能对其进行抽象？如何实现？
            ///

            #endregion

            #region Six Day 1.用代码证明struct定义的类型是值类型 栈的学费是按周计费的，所以请实现这两个功能：
            //1.用代码证明struct定义的类型是值类型     (MyClass and MyStruct at this page.)
            //MyClass myClass = new MyClass();
            /*myClass._test = 23;*///这里的23是赋值到一个地址里面去。
                                   //MyStruct myStruct = new MyStruct();
            /*myStruct._test = 23;*///这里是值类型。

            ///	1.函数GetDate()，能计算一个日期若干（日/周/月）后的日期
            ///2.给定任意一个年份，就能按周排列显示每周的起始日期，如下图所示：
            //DataTimeCount.GetWeek(2000);

            #endregion

            #region Seven Day homework   about Token
            //TokenManager tokenManager = new TokenManager();
            //tokenManager.Add(Token.Admin);
            //tokenManager.Add(Token.Blogger);
            //tokenManager.Add(Token.Registered);
            //tokenManager.Remove(Token.Blogger);
            //tokenManager.Has(Token.Admin);
            #endregion

            #region https://zhuanlan.zhihu.com/p/93458057C#-面向对象-万物皆对象：Object和装箱拆箱

            ///1.思考dynamic和var的区别，并用代码予以演示
            ///
            //请忽略命名，命名采用var的第一个字母，和一个随便的i,dynamic也是一样
            //var Vi = "88";
            //dynamic Di = "88";

            //区别在于，var是推倒类型，在使用中因为vi被推导为string类型所以无法完成表达式
            //无法通过编译，所以直接报错。
            //Console.WriteLine(Vi - 8);
            //dynamic是动态类型，在编译时默认跳过，所以不会有报错的发生，但如果运行时候会报运行错误
            //结果是一样的。
            //Console.WriteLine(Di-8);


            //2.构造一个能装任何数据的数组，并完成数据的读写
            //我不知道还有什么类型了，字符串，数字，元组，bool,小数，数组，应该差不多了。
            //object[] AnyArray = { "王胖子很帅", 26, (23, "17cm"), new Student() ,true ,888.8,new int [17,18,19,20,22]};
            //for (int i = 0; i < AnyArray.Length-1; i++)
            //{//想不到我现在竟然可以随手就写一个完美的循环出来。
            //    Console.WriteLine(AnyArray[i]);
            //}
            //Console.WriteLine(AnyArray);

            //3.使用object改造数据结构栈（Stack），并在出栈时获得出栈元素
            //都已经如此完美了，还怎么优化。。。

            ///
            #endregion

            #region https://zhuanlan.zhihu.com/p/93440022C#-面向对象-反射和特性 
            //2.在Content之外封装一个方法，可以修改Content的CreateTime和PublishTime
            FixTime.FixContentTime(2019, 10, 19);

            ///3.自定义一个特性HelpMoneyChanged（帮帮币变化）：
            ///1.该特性只能用于方法
            ///2.有一个构造函数，可以接受一个int类型的参数amount，表示帮帮币变化的数量
            ///3.有一个string类型的Message属性，记录帮帮币变化的原因
            ///
            //作业在User页面

            ///5.用反射获取Publish()上的特性实例，输出其中包含的信息
            ///
            //这个地方有BUG，把自己写迷糊了。歇会儿换个思路，如果换不出来就等飞哥来换。
            //思路是这样的，我要使用GetHM这个函数，必须有一个参数，参数需要找Publish这个方法要
            //要找publish方法首先我需要有一个contentservice这个对象，有了这个对象，还得给publish传参...我的天
            //ContentService service = new ContentService();
            //service = service.Publish(Article article);
            //GetPublish.GetHM(service);
            #endregion

            #region https://zhuanlan.zhihu.com/p/93747718 C#-面向对象：string还是StringBuilder？
            ///确保文章（Article）的标题不能为null值，也不能为一个或多个空字符组成的字符串，
            ///而且如果标题前后有空格，也予以删除
            ///
            //Article wpz1 = new Article(string.Empty);
            //Article wpz2 = new Article("    ");
            //Article wpz3 = new Article(null);
            //Article wpz4 = new Article("");
            //Article wpz5 = new Article(" ");
            //Article wpz = new Article("   王胖子比飞哥帅的多   ");


            //设计一个适用的机制，能确保用户（User）的昵称（Name）不能含有admin、17bang、管理员等敏感词。
            //User wpz4 = new User("qqadminw", "~qweqwe");
            //User wpz5 = new User("wwadminw", "!qweqwe");
            //User wpz6 = new User("adminee", "@qwe123");
            //User wpz7 = new User("adminee", "@qwe123");
            //User wpz8 = new User("qq17bang", "@qwe123");
            //User wpz9 = new User("qq17bangww", "@qwe123");


            ///确保用户（User）的密码（Password）：长度不低于6
            ///必须由大小写英语单词、数字和特殊符号（~!@#$%^&*()_+）组成
            ///
            //这个密码应该还差点东西没写对
            //User user = new User("", "abcabc");
            //User user1 = new User("", "==abcabc");

            //User wpz = new User("admin", "~!@#  $%^&*()_+");
            //User wpz1 = new User("admin", "~qw---eqwe");
            //User wpz2 = new User("admin", "!qweqwe");
            //User wpz3 = new User("admin", "@qwe123");




            #endregion

            #region Practies area.. Here is not homeword,just selftry.


            //Self wang = new Self();
            //Type typeinfo = typeof(Self);
            //FieldInfo wangpz = typeinfo.GetField("_try", BindingFlags.NonPublic | BindingFlags.Instance);
            //object Try = wangpz.GetValue(wang);
            //Console.WriteLine(Try);

            //Self yb = new Self();
            //Type diyibu = typeof(Self);
            //FieldInfo dierbu = diyibu.GetField("_iTry", BindingFlags.NonPublic |BindingFlags.Instance| BindingFlags.GetProperty);
            //object disubu = dierbu.GetValue(yb);
            //Console.WriteLine(disubu);
            //disubu = 222;
            //Console.WriteLine(disubu);
            //Self self = new Self();
            //Console.WriteLine(self);


            //object tlzz = new Student();
            //NowTry.Praise(tlzz);
            //object wpz = new Teacher();
            //NowTry.Praise(wpz);

            //string name = string.Empty;
            //if (student ==null)
            //{
            //    name = "无姓名";
            //}
            //else
            //{
            //    name = student.name;
            //} 

            //string name = student == null ? "无姓名" : student.name;
            //student student =null;

            //Console.WriteLine(student?.IsMale);
            //bool? gender = student?.IsMale;
            //gender = false;

            //int[] vs = new int[] { 16, 23, 25, 22 };
            //List<int> ages = new List<int> {16,23,25,22 };

            //IEnumerator<int> enumerator = ages.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}


            //LinkedList


            #endregion

            Teacher fg = new Teacher { Name = "大飞哥" };
            Teacher fish = new Teacher { Name = "小鱼" };
            Teacher waiting = new Teacher { Name = "诚聘", Age = 0 };
            IEnumerable<Teacher> teachers = new List<Teacher> { fg, fish, waiting };

            Major csharp = new Major { Name = "C#", Teacher = fg };
            Major SQL = new Major { Name = "SQL", Teacher = fg };
            Major Javascript = new Major { Name = "Javascript", Teacher = fg };
            Major UI = new Major { Name = "UI", Teacher = fish };
            IEnumerable<Major> majors = new List<Major> { csharp, SQL, Javascript, UI };

            IList<Student> students = new List<Student>
            {
                new Student{Score = 98, Name = "屿", Majors=new List<Major>{csharp,SQL } },
                new Student{Score = 86, Name = "行人", Majors=new List<Major>{Javascript, csharp, SQL} },
                new Student{Score = 78, Name = "王平", Majors=new List<Major>{csharp}},
                new Student{Score = 89, Name = "王枫", Majors=new List<Major>{Javascript, csharp, SQL,UI}},
                new Student{Score = 98, Name = "蒋宜蒙", Majors=new List<Major>{Javascript, csharp}},
            };

            var x = from s in majors
                    group s by s.Teacher into gm
                    select new
                    {
                        major = gm.Key.Name,
                        count = gm.Count()
                    };
            foreach (var item in students)
            {
                Console.WriteLine(item.Name);
            }

        }


    }

}
