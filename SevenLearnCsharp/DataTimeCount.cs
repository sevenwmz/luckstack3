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
        ///

        public static void GetDate(int year,int mouth,int day, int AddDays = 0,int Addmouth = 0, int Addyear =0)
        {//我会被回旋踢踢死。
            AddDays += day;
            Addmouth += mouth;
            Addyear += year;
            DateTime w = new DateTime(Addyear, Addmouth, AddDays);

            for (int i = 0; i < 52; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    Console.WriteLine($"第{i}周:{w} - {w.AddDays(7)}");
                }
            }
        }


    }

}
