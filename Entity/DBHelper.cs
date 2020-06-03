using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;

namespace Entity
{
    public class DBHelper
    {
        private const string _connectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";

        public DbConnection Connection
        {
            get => new SqlConnection(_connectionToDatabase);
        }



        public void ExcuteNonQuery(string cmdText)
        {

        }


    }
}
