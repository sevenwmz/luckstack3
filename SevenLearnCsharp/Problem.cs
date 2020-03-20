using System;
using System.Collections.Generic;
using System.Text;

namespace SevenLearnCsharp
{
    public class Problem
    {
        public Problem()
        {

        }

        public Problem(Problem name )
        {

        }
        private int _reward;//悬赏字段

        internal string Title { get; set; }//标题获得方法


        internal string Body//每一个problem必须有body，其他应该也要添加到这个方法里面，但是还没想好整理。
        {
            get => _body;
            set
            {
                if (_body == null)
                {
                    Console.WriteLine("请输入内容");
                    return;
                }//else nothing.
                _body = value;
            }
        }//正文获得方法

        internal int Reward
        {
            get => _reward;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Reward不能为负数");
                    return;
                }
                _reward = value;
            }
        }//悬赏获得方法

        private string[] _index = new string[10];
        private string _body;

        public string this[int index]
        {
            get { return _index[index]; }
            set { _index[index] = value; }
        }

        internal string PublishDataTime { get; set; }//发布时间获得方法

        internal string Author { get; set; }//作者字段获得方法


        internal void publish( )
        {
            new Problem
            {
                Title = "这里是系统传入",
                Body = "这里是系统传入",
                _reward = 0,
                Author = "这里是系统传入",
            };
            return;
        }

    }
}
