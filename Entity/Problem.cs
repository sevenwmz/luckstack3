using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity
{
    public class Problem : Content
    {
        #region Constructer method

        public Problem() : base("Problem")
        {

        }

        public Problem(string body) : this()
        {
            Body = body;
        }
        #endregion

        #region Filed and properties
        ///求助版块，定义一个类Problem，包含字段：标题（Title）、
        ///正文（Body）、悬赏（Reward）、发布时间（PublishDateTime）
        ///和作者（Author），和方法Publish()
        //Title filed;

        //Body filed.

        public ProblemStatus Status { set; get; }
        #region 3.problem.Reward不能为负数(Secend Day Homework )

        private int _reward;
        public int Reward
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("不能输入负数的悬赏");
                }
                _reward = value;
            }
            get => _reward;
        }
        #endregion

        //PublishDataTime filed.
        internal string PublishDataTime { get; set; }


        internal string TargetedHelp { get; set; }//for third day homework

        public static Problem ChangeProblemContent(Problem content)
        {
            Problem temp = new Problem();
            temp.Title = content.Title;
            temp.Summary = content.Summary;
            return temp;
        }
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


        //2.Load(int Id)：根据Id从数据库获取一条求助
        public static int Load(int Id)
        {
            Console.WriteLine("take some...");
            return Id;
        }

        //3.Delete(int Id)：根据Id删除某个求助
        public static int Delete(int Id)
        {
            Console.WriteLine("Remove some ...");
            return Id;
        }

        //4.repoistory：可用于在底层实现上述方法和数据库的连接操作等
        // How?


        #region 实例化文章和意见建议，调用他们：继承自父类的属性和方法自己的属性和方法

        public override void Publish()
        {
            base.Publish();
            Author.HelpMoney -= Reward;
            Console.WriteLine("database");
        }
        #endregion



        #endregion

        #region Fifth Day   Agree And DisAgree
        //一起帮里的求助总结、文章和意见建议，以及他们的评论，都有一个点赞（Agree）/
        internal override int DisAgree(User voter)
        {
            Author.HelpBean--;
            voter.HelpBean++;
            return Author.HelpBean;
        }

        internal override int Agree(User voter)
        {
            Author.HelpBean++;
            voter.HelpBean--;
            return Author.HelpBean;
        }

        #endregion
        #endregion


    }

    public enum ProblemStatus
    {
        [Description("已撤销")]
        cancelled,
        [Description("已酬谢")]
        Rewarded,
        [Description("协助中")]
        inprocess,
        [Description("待协助")]
        assist
    }
}
