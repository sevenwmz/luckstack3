using Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Repository
{
    public class SeriesRepository
    {
        private DBHelper _helper;
        public SeriesRepository()
        {
            _helper = new DBHelper();
        }

        public IList<Series> Get()
        {
            using (DbConnection connection = _helper.Connection)
            {
                IList<Series> result = new List<Series> { };
                using (DbCommand cmd = new SqlCommand("Select Name,Id From Series", (SqlConnection)connection))
                {
                    connection.Open();
                    SqlDataReader reader = (SqlDataReader)cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        return result;
                    }
                    while (reader.Read())
                    {
                        result.Add(new Series { SeriesName = reader["Name"].ToString(), Id = Convert.ToInt32(reader["Id"]) });
                    }
                    return result;
                }
            }
        }

    }
}
