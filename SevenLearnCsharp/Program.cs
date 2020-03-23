using System;
using Entity;
using HomeWork;
using DontWatch;

namespace SevenLearnCsharp
{
    class Program
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

            

            #region practies area.. Here is not homeword,just selftry.
            Person person = new Student();
            person.Eat();
            person = new Teacher();
            person.Eat();
            #endregion

        }


    }
    



}

