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
        public CommoentsRepository()
        {
            _helper = new DBHelper();
        }

        public void SaveComments(string comment, int articleId)
        {
            _helper.ExcuteNonQuery("insert Comments Values(@comment,@DateTime,@ArticleId)",
                new SqlParameter[] {
                            new SqlParameter("@comment", comment) ,
                            new SqlParameter("@DateTime",DateTime.Now),
                            new SqlParameter("@ArticleId",articleId)
                        });
        }

        public IList<Comment> Get(int articleId)
        {
            using (DbConnection connection = _helper.Connection)
            {
                IList<Comment> result = new List<Comment> { };
                using (DbCommand cmd = new SqlCommand($"Select * From Comments where BelongArticle = {articleId}", (SqlConnection)connection))
                {
                    connection.Open();
                    SqlDataReader reader = (SqlDataReader)cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        return result;
                    }
                    while (reader.Read())
                    {
                        result.Add(new Comment 
                        { 
                            Id = Convert.ToInt32(reader["Id"]),
                            PublishTime = (DateTime)reader["PublishTime"],
                            Comments = reader["Comments"].ToString(),
                            
                        });
                    }
                    return result;
                }
            }
        }


    }
}
