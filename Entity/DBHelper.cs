using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;

namespace Entity
{
    public class DBHelper
    {
        private const string ConnectionToDatabase = "Data Source=-20191126PKLSWP;Initial Catalog=17bang;Integrated Security=True";



        /// <summary>
        /// Get keywordId from database
        /// </summary>
        /// <param name="keywordsName">keyword name</param>
        /// <returns></returns>
        public static int GetKeywordsId(string keywordsName)
        {
            int keywordId = GetKeywordIdBy(keywordsName);

            if (keywordId == 0)
            {
                keywordId =  NewKeyword(keywordsName);
            }//else nothing.
            return keywordId;
        }

        /// <summary>
        /// Save this keyword into database and return this keywordId
        /// </summary>
        /// <param name="keywordsName">Keyword name</param>
        public static int NewKeyword(string keywordsName)
        {
            int keywordId = 0;
            using (DbConnection connection = new SqlConnection(ConnectionToDatabase))
            {
                connection.Open();
                using (DbCommand addNewKeyword = new SqlCommand("Insert Keyword(Name,Used) Values(@Keyword,1) ", (SqlConnection)connection))
                {
                    addNewKeyword.Parameters.Add(new SqlParameter("@Keyword", keywordsName));
                    addNewKeyword.ExecuteNonQuery();

                    DbCommand getKeywordId = new SqlCommand("Select Id  From Keyword where Name = @Keyword ", (SqlConnection)connection);
                    getKeywordId.Parameters.Add(new SqlParameter("@Keyword", keywordsName));

                    DbDataReader reader = getKeywordId.ExecuteReader();
                    reader.Read();
                    keywordId = Convert.ToInt32(reader["Id"]);
                }
            }
            return keywordId;
        }

        /// <summary>
        /// Check keyword is exist or not in database
        /// </summary>
        /// <param name="keywordsName">Need keyword name</param>
        /// <returns></returns>
        public static int GetKeywordIdBy(string keywordsName)
        {
            using (DbConnection connection = new SqlConnection(ConnectionToDatabase))
            {
                int KeywordId = 0;

                connection.Open();

                DbCommand checkKeywordsExist = new SqlCommand("Select Id From Keywordwhere Name = @Keyword", (SqlConnection)connection);
                DbDataReader reader = checkKeywordsExist.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    checkKeywordsExist.Parameters.Add(new SqlParameter("@Keyword", keywordsName));

                    //Plus keyword use.
                    DbCommand plusUsed = new SqlCommand(
                        @"Update Keyword Set Used += 1 Where Id = (Select Id From Keywordwhere Name = @Keyword)", (SqlConnection)connection);
                    plusUsed.ExecuteNonQuery();

                    return KeywordId = Convert.ToInt32(reader["Id"]);
                }//else nothing.

                return KeywordId;

            }

        }

        /// <summary>
        /// Return Article Id
        /// </summary>
        /// <param name="title">Need article title name</param>
        /// <returns></returns>
        public static int GetArticleId(string title)
        {
            int articleid = 0;
            using (DbConnection connection = new SqlConnection(ConnectionToDatabase))
            {
                connection.Open();
                DbCommand command = new SqlCommand("Select Id From Article Where Title = @KTitle", (SqlConnection)connection );
                command.Parameters.Add(new SqlParameter("@KTitle",title));
                DbDataReader reader = command.ExecuteReader();
                reader.Read();
                articleid = Convert.ToInt32(reader["Id"]);
            }
            return articleid;
        }

        /// <summary>
        /// Save to n:n relation Table
        /// </summary>
        /// <param name="articleId">Need articleId</param>
        /// <param name="keywordsId">Need keywordId</param>
        public static void AttachKeyword(int articleId, int keywordId)
        {
            using (DbConnection connection = new SqlConnection(ConnectionToDatabase))
            {
                connection.Open();
                DbCommand command = new SqlCommand($"Insert KeywordToArticle(ArticleNameId,KeywordId) Values({articleId},{keywordId})", (SqlConnection)connection);
                command.ExecuteNonQuery();
            }
        }


        public void ExcuteNonQuery(string cmdText)
        {

        }


    }
}
