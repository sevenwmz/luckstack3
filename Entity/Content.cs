using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class Content
    {

        #region Constructer function


        // 2.确保每个Content对象都有kind的非空值
        //public Content(string parameter)
        //{
        //    kind = parameter;
        //}

        #endregion

        #region here is filed and properties.  
        //3.21Homework 
        //1.Content中有一个字段：kind，记录内容的种类（problem/article/suggest等），只能被子类使用
        protected string kind { set; get; }

        //3.Content中的createTime，不能被子类使用，但只读属性PublishTime使用它为外部提供内容的发布时间
        private string createTime 
        {
            set 
            { 
                createTime = DateTime.Now.ToString("F");
                PublishTime = createTime;
            }
            get 
            {
                return createTime;
            }
        }
        public string PublishTime { get;private set; }
        

        //keywords
        internal string KeyWords { set; get; }

        //article name
        internal string ArticleName { set; get; }

        //Summary
        internal string Summary { set; get; }

        //Author
        internal string Author { set; get; }

        //here is "upper"  cause diffrent page call the name diffrent."agree"or"anwser".
        internal int Upper { set; get; }

        //here is "lower" same Reason
        internal int Lower { set; get; }

        //here is comment, third page same name.
        internal int Comment { set; get; }
        #endregion

        #region function 
        // 尝试一下这个思路写方法。

        public void fabu()
        {
            Summary = Console.ReadLine();
        }
        #endregion
    }
}
