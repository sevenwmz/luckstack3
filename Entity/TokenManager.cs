using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class TokenManager
    {


        ///1.声明一个令牌（Token）枚举，包含值：SuperAdmin、Admin、Blogger、Newbie、Registered。
        ///2.声明一个令牌管理（TokenManager）类：
        ///1.使用私有的Token枚举_tokens存储所具有的权限
        ///2.暴露Add(Token)、Remove(Token)和Has(Token)方法，可以添加、删除和查看其权限 
        ///3.将TokenManager作为User类的属性

        private Token _tokens { set; get; }//1.使用私有的Token枚举_tokens存储所具有的权限

        
        ///2.暴露Add(Token)、Remove(Token)和Has(Token)方法，可以添加、删除和查看其权限 
        public void Add(Token Role)
        {
            _tokens = Role | _tokens;
        }

        public void Remove(Token Role)
        {
            _tokens = Role ^ _tokens;
        }
        public void Has(Token Role)
        {
            _tokens = Role & _tokens;
        }
        
    }
    enum Token
    {//1.声明一个令牌（Token）枚举，包含值：SuperAdmin、Admin、Blogger、Newbie、Registered。
        SuperAdmin = 1,
        Admin  = 2,
        Blogger = 4,
        Newbie = 8,
        Registered = 12
    }
}
