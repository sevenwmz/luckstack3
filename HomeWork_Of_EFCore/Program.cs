using Microsoft.EntityFrameworkCore;
using System;

namespace HomeWork_Of_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            #region Frist day /将User类映射到数据库：  http://17bang.ren/Article/554
            //作业 http://17bang.ren/Article/554
            //将User类映射到数据库： 
            //1.使用EF的API直接建库建表删库
            new Repository_Of_EFCore().Database.EnsureCreated();
            new Repository_Of_EFCore().Database.EnsureDeleted();
            //2.使用Migration工具建库建表
            {
                //Add-Migration AddDatabase_and_User
                //Update-Database
            }
            //Migration之后，在User类上添加一列：int FailedTry（尝试登陆失败次数），使用Migration工具： 
            {
                //Add-Migration Add_User_FailedTry
            }
            //1.将改动同步到数据库
            {
                //Update-Database
            }
            //2.回退数据库到FailedTry添加之前
            {
                //Update-Database 20200608131656_AddDatabase_and_User
            }
            #endregion







        }
    }
}
