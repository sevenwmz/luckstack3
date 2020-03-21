using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    //思考Respoitory应该是static类还是实例类更好
    public class Repoistory //能实例就不静态  
    {

        #region 3.21 定义一个仓库（Repoistory）类，用于存取对象，其中包含：
        ///一个int类型的常量version
        public const int Version = 1;
        ///一个静态只读的字符串connection，以后可用于连接数据库
        internal readonly static string connection;
        #endregion

    }
}
