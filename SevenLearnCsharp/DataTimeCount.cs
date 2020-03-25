using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork
{
    class DataTimeCount
    {
        ///栈的学费是按周计费的，所以请实现这两个功能：
        ///1.函数GetDate()，能计算一个日期若干（日/周/月）后的日期
        ///2.给定任意一个年份，就能按周排列显示每周的起始日期，如下图所示：

        //1.函数GetDate()，能计算一个日期若干（日/周/月）后的日期
        public static void GetDate
            (int year,int mouth, int day,int AddYear = 0,int AddMouth = 0,int AddDay = 0)
        {//我预感到了飞起来的一脚,,因为这个东西本身就不用这样做，不知道题目为啥这样。。。。估计又是我没读懂
            DateTime date = new DateTime(year,mouth,day);
            date =  date.AddDays(AddDay);
            date = date.AddMonths(AddMouth);
            date = date.AddYears(AddYear);
            Console.WriteLine(date);
        }

        ///2.给定任意一个年份，就能按周排列显示每周的起始日期：
        public static void GetWeek(int year)
        {
            ///首先需要计算一年有多少周的东西
            ///其次需要一个这一年的第一周是在几号的东西。
            ///然后从这一周开始打印这是第一周，输入当前日期
            ///然后输入这一天的后7天日期。
            ///目前掌握的知识结构只够我完成 （输入这一天的后7天日期。）adddays(7)
            ///又了解到了dayofweek这个好东西。

            //这个地方借鉴了LJP大佬的作业，我比较认同这个地方，其他地方我不太想借鉴，不符合我的思路
            DateTime dateTime = new DateTime(year, 1, 1);

            for (int i = 0; i < 7; i++)
            {//先循环找到了这一年第一周的第一天
                if (dateTime.DayOfWeek != DayOfWeek.Monday)
                {
                    dateTime.AddDays(1);
                }
                else
                {
                    return;
                }//虽说不想借鉴，但是确认ljp的比我的要简洁一些。。。
            }
        }
    }

}
