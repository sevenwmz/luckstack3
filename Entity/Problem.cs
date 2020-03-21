using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Problem
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

        #endregion


        #region Function

        //Publish method
        public void Publish()
        {
            return;
        }

        #region (Secend Day)一起帮的求助可以有多个（最多10个）关键字，请为其设置索引器，以便于我们通过其整数下标进行读写。

        private string[] _keyWords = new string[10];
        public string this[int index]
        {
            get { return _keyWords[index]; }
            set { _keyWords[index] = value; }
        }

        #endregion


        #endregion


    }
}
