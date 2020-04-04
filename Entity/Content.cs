using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Entity
{
    public class Content : Entity<int>
    {

        #region Constructor

        public Content() : base(32)
        {
            _createTime = DateTime.Now;
        }
        // 2.确保每个Content对象都有kind的非空值

        public Content(string name) : this()
        {
            kind = name;
        }

        #endregion

        #region Filed and Properties
        //3.21Homework 
        //1.Content中有一个字段：kind，记录内容的种类（problem/article/suggest等），只能被子类使用
        protected string kind;

        //3.Content中的createTime，不能被子类使用，但只读属性PublishTime使用它为外部提供内容的发布时间
        private DateTime _createTime { get; }
        public DateTime PublishTime
        {
            get { return _createTime; }
        }


        //Author
        public User Author { set; get; }

        internal string[] Comments { set; get; }
        public int HelpMoney { set; get; }


        //keywords
        internal string[] KeyWords { set; get; }

        //article name
        internal string Name { set; get; }

        //Summary
        internal string Summary { set; get; }
        #endregion

        #region function 
        //Release function
        public virtual void Publish()
        {

        }
        ////here is "Agree"  
        internal virtual int Agree(User voter)
        {
            return 0;
        }


        ////here is "Disagree"
        internal virtual int DisAgree(User voter)
        {
            return 0;
        }


        #endregion
    }

    public class FixTime
    {
        /// <summary>
        /// 通过反射来修改ContentTime
        /// </summary>
        /// <param name="year">输入起始年</param>
        /// <param name="mouth">输入起始月</param>
        /// <param name="day">输入起始日</param>
        public static void FixContentTime(int year, int mouth, int day)
        {
            //我把content类设置为abstract类了，没办法有改回来了，抽象的不能反射
            Content content = new Content();
            Type Frist = typeof(Content);
            //FieldInfo Secend = Frist.GetField("_createTime", BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo Secend = Frist.GetProperty("_createTime", BindingFlags.NonPublic | BindingFlags.Instance);
            object Third = Secend.GetValue(content);
            Third = new DateTime(year, mouth, day);
            Console.WriteLine(Third);
        }

    }

}
