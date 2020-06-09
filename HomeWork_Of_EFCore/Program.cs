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
            {
                //new Repository_Of_EFCore().Database.EnsureCreated();
                //new Repository_Of_EFCore().Database.EnsureDeleted();
            }
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

            #region Scend Day 在EF6上完成上一课作业  http://17bang.ren/Article/626
            //作业： http://17bang.ren/Article/626
            //在EF6上完成上一课作业
            {
                //将User类映射到数据库： 
                //1.使用EF的API直接建库建表删库
                {
                    //new Repository_Of_EF6().Database.CreateIfNotExists();
                }
                //2.使用Migration工具建库建表
                {
                    //EntityFramework6\Update-Database
                    //EntityFramework6\Add-Migration Init
                    //EntityFramework6\Update-Database
                }
                //Migration之后，在User类上添加一列：int FailedTry（尝试登陆失败次数），使用Migration工具： 
                {
                    //EntityFramework6\Add-Migration Add_User_FailedTry
                }
                //1.将改动同步到数据库
                {
                    //EntityFramework6\Update-Database
                }
                //2.回退数据库到FailedTry添加之前
                {
                    //EntityFramework6\Update-Database -TargetMigration:Init
                }
            }
            #endregion

            #region Day Three  EF and EFCore Config Logger http://17bang.ren/Article/673
            //            作业 http://17bang.ren/Article/673
            //1.能够在EF core上配置成功Logger到Debug窗口
            ////仅在调试状态使用

            {
                //#if DEBUG
                //.EnableSensitiveDataLogging(true)
                //#endif
            }

            //2.能够在EF6上配置成功Logger到控制台
            {
                //new Repository_Of_EF6().Database.Log = Console.Write;
            }
            #endregion

            #region Day fourth .利用EF，插入3个User对象   http://17bang.ren/Article/674
            //            作业 http://17bang.ren/Article/674
            //1.利用EF，插入3个User对象
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //repository.AddRange(
                //    new User{Name = "Seven"}, 
                //    new User { Name = "Thin_Man" },
                //    new User { Name = "Funny_Guy" });
                //repository.SaveChanges();
            }
            //2.通过Id找到其中一个User对象
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //User findUser_1 = repository.Find<User>(1);
                //Console.WriteLine(findUser_1.Name);
            }
            //3.修改该User对象的Name属性，将其同步到数据库
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //User findUser_1 = repository.Find<User>(1);
                //findUser_1.Name = "HandSome Seven";
                //repository.SaveChanges();
                //Console.WriteLine(findUser_1.Name);
            }
            //4.不加载User对象，仅凭其Id用一句Update SQL语句完成上题
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //User user = new User { Id = 1 };
                //repository.Attach<User>(user);
                //user.Name = "HandSome nice Seven";
                //repository.SaveChanges();
            }
            //5.删除该Id用户
            {
                //Repository_Of_EFCore repository = new Repository_Of_EFCore();
                //User u2 = repository.Find<User>(2);
                //repository.Remove<User>(u2);
                //repository.SaveChanges();
            }
            #endregion

            #region Use Linq to EntityFramework   http://17bang.ren/Article/556
            //            作业 http://17bang.ren/Article/556
            //利用Linq to EntityFramework，实现方法：GetBy(IList < ProblemStatus > exclude, bool hasReward, bool descByPublishTime)，该方法可以根据输入参数： 
            //IList<ProblemStatus> exclude：不显示（排除）某些状态的求助
            //bool hasReward：只显示已有酬谢的求助（如果传入值为true的话） 
            //bool descByPublishTime：按发布时间正序还是倒序
            //参考：求助列表（不显示 / 只显示）和文章列表（正序 / 倒序）


            #endregion

            #region OnModelCreating()和Data Annotations     http://17bang.ren/Article/558
            //            作业 http://17bang.ren/Article/558
            //分别使用OnModelCreating()和Data Annotations，完成以下配置：    In [Repository_Of_EFCore]
            //将之前的User类名改为Register，但仍然能对应表User
            //将之前的User属性Name改成UserName，但仍然能对应表User的列Name
            //将Name的长度限制为256
            //Password不能为空
            //将User表的主键设置在Name列上
            //User类中的属性FailedTry不用存储到数据库中
            //给CreateTime属性添加一个非聚集唯一索引
            #endregion

            #region 课间作业：Email和User有一对一的关系 	http://17bang.ren/Article/675
            //            课间作业： 	http://17bang.ren/Article/675
            //Email和User有一对一的关系，参照课堂演示，在数据库上建立User外键引用Email的映射
            {
                Repository_Of_EFCore repository = new Repository_Of_EFCore();

                User wpz = new User { Name = "Seven-2", Password = "1234" };
                Email email = new Email { EmailLocation = "123456@qq.com" };
                wpz.SendTo = email;
                email.FromWho = wpz;

                repository.Add<User>(wpz);
                repository.Add<Email>(email);
                repository.SaveChanges();
            }
            #endregion
        }
    }
}
