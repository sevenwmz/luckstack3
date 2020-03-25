using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public abstract class Content
    {

        #region Constructor

        public Content()
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
        private DateTime _createTime;
        public DateTime PublishTime 
        {
            get { return _createTime; }
        }
        public int HelpMoney { set; get; }


        //keywords
        internal string[] KeyWords { set; get; }

        //article name
        internal string Name { set; get; }

        //Summary
        internal string Summary { set; get; }

        //Author
        public User Author { set; get; }

        internal string[] Comments { set; get; }
        #endregion

        #region function 
        //Release function
        public virtual void Publish()
        {

        }
        //here is "Agree"  
        internal int Agree(User voter)
        {
            Author.HelpBean++;
            voter.HelpBean--;
            return Author.HelpBean;
        }

        //here is "Disagree"
        internal int Disagree(User voter)
        {
            Author.HelpBean--;
            voter.HelpBean++;
            return Author.HelpBean;
        }

        #endregion
    }
}
