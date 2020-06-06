﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Entity
{
    public class Content : Entity<int>
    {
        public Content():base(32)
        {

        }
        public Content(string name) : this()
        {
            kind = name;
            PublishTime = DateTime.Now;
        }

        protected string kind;
        
        public DateTime PublishTime { get; set; }

        public int Id { set; get; }

        public User Author { set; get; }

        public int HelpMoney { set; get; }

        public Problem Reward { set; get; }

        [Required(ErrorMessage ="内容不能为空")]
        public string Body { set; get; }


        public string Summary { set; get; }

        [Required(ErrorMessage = "标题不能为空")]
        public string Title { set; get; }


        #region function 
        //Release function
        public virtual void Publish()
        {//2.内容（Content）发布（Publish）的时候检查其作者（Author）是否为空，如果为空抛出“参数为空”异常 
            if (Author == null)
            {
                throw new ArgumentNullException("参数为空,请输入author");
            }//else nothing...
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


        public Appraise appraise { set; get; }

        public IList<Comment> Comments { set; get; }

        public IList<Keyword> Keywords { set; get; }
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
