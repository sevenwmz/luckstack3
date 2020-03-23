using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ContentService
    {
        #region Constructer
        public ContentService(string name,int YouOwnMoney)
        {
            _name = name;
            _helpMoney = YouOwnMoney;

        }

        #endregion

        #region Filed and propertise
        private string _name { set; get; }
        private int _helpMoney { set; get; }
        #endregion

        #region Function
        public void publish() 
        {
            ///添加一个新类ContentService，其中有一个发布（Publish()）方法：
            ///如果发布Article，需要消耗一个帮帮币
            ///如果发布Problem，需要消耗其设置悬赏数量的帮帮币
            ///如果发布Suggest，不需要消耗帮帮币
            ///

            ///What's homework...use if else???
            ///how connenct ohter class,inhiret alreay use,interface not work..Jesus..
            ///no ideal
            if (_name == "Article")
            {
                _helpMoney = _helpMoney - 1;
                Console.WriteLine("here is database");
                return;
            }
            else if (_name == "Problem")
            {
                _helpMoney = int.Parse(Console.ReadLine());
                Console.WriteLine("here is database");
                return;
            }
            else if (_name == "Suggest")
            {
                Console.WriteLine("here is database");
                return;
            }
            else
            {
                //I think maybe don't need else...cause it's 3 page,result is submit.
                //why i have to give suggest,you input some wrong???,but not sure.just try.
                Console.WriteLine("input wrong");
                return;
            }
        }
        #endregion
    }
}
