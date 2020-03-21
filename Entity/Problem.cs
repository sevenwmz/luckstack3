using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Problem /*:Content*/  // after inherit have some problem ... i check that ,but useless .
    {
        #region Constructer method

        public Problem()
        {

        }

        //public Problem(string parameter)
        //{
        //    Title = parameter;
        //}
        #region (Secend Day)设计一种方式，保证：每一个Problem对象一定有Body赋值

        public Problem(string body)
        {
            this.Body = body;
        }
        #endregion

        #endregion


        #region Filed and properties
        ///求助版块，定义一个类Problem，包含字段：标题（Title）、
        ///正文（Body）、悬赏（Reward）、发布时间（PublishDateTime）
        ///和作者（Author），和方法Publish()

        //Title filed;
        internal string Title { get; set; }

        //Body filed.
        internal string Body { get; set; }

        //Reward filed
        //internal int Reward { get; set; }
        #region 3.problem.Reward不能为负数(Secend Day Homework )

        private int _reward;
        public int Reward
        {
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("悬赏不能为负数");
                    return;
                }
                _reward = value;
            }
            get => _reward;
        }

        #endregion

        //PublishDataTime filed.
        internal string PublishDataTime { get; set; }

        //Author filed..
        internal string Author { get; set; }
        internal string TargetedHelp { get; set; }//for third day homework
        #endregion


        #region Function

        #region 第一天作业 设置一个problem方法

        //Publish method
        //public void Publish()
        //{
        //    return;
        //}

        #endregion

        #region (Secend Day)一起帮的求助可以有多个（最多10个）关键字，请为其设置索引器，以便于我们通过其整数下标进行读写。

        private string[] _keyWords = new string[10];


        public string this[int index]
        {
            get { return _keyWords[index]; }
            set { _keyWords[index] = value; }
        }

        #endregion

        #region （Third day）考虑求助（Problem）的以下方法/属性，哪些适合实例，哪些适合静态，然后添加到类中：
        //1.Publish()：发布一篇求助，并将其保存到数据库
        //public string HelpMe(string[] keyword)
        //{
        //    //Now use (console.readline) recevie user input. after get new knowledge change function.
        //    // probably interface？
        //    Title = Console.ReadLine();//Get title. 

        //    Body = Console.ReadLine();//Get body .same at title.

        //    _keyWords = keyword;//Get keyword

        //    TargetedHelp = Console.ReadLine();// get targetedHelp people name

        //    Reward = int.Parse(Console.ReadLine());// get Reward

        //    //保存到数据库应该是在return里面，但是怎么保存到数据库里面？？？？
        //    return "";
        //}

        //2.Load(int Id)：根据Id从数据库获取一条求助
        public static int Load(int Id)
        {//假设这里有个所谓的数据库
            if (Id == int.Parse(Console.ReadLine()))//数据库写不了,cr代替
            {
                return 0;//这里是瞎写的，飞哥说不用实现
            }
            else
            {
                Console.WriteLine("Id不存在");
            }
            return Id;
        }


        //3.Delete(int Id)：根据Id删除某个求助
        public static int Delete(int Id)
        {// I don't know where is database....

            if (Id == int.Parse(Console.ReadLine()))//数据库写不了,cr代替
            {
                return 0;//这里是瞎写的，飞哥说不用实现
            }
            else
            {
                Console.WriteLine("Id不存在");
            }
            return Id;
        }

        //4.repoistory：可用于在底层实现上述方法和数据库的连接操作等

        // How?




        

        #endregion

        #endregion


    }
}
