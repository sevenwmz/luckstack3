using Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Repository
{
    public class CommoentsRepository
    {
        private DBHelper _helper;

      
        public IList<Ad> Get()
        {
            using (DbConnection connection = _helper.Connection)
            {
                IList<Ad> result = new List<Ad> { };
                using (DbCommand cmd = new SqlCommand("Select ContentOfAd,Id From AD", (SqlConnection)connection))
                {
                    connection.Open();
                    SqlDataReader reader = (SqlDataReader)cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        return result;
                    }
                    while (reader.Read())
                    {
                        result.Add(new Ad { AdName = reader["ContentOfAd"].ToString(), Id = Convert.ToInt32(reader["Id"]) });
                    }
                    return result;
                }
            }
        }


    }
}
