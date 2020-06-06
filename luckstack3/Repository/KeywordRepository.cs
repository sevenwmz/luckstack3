using _17bang.Pages.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Repository
{
    public class KeywordRepository
    {
        private DBHelper _helper;

        public KeywordRepository()
        {
            _helper = new DBHelper();
        }

        private static IList<Keyword> _keywords;

        static KeywordRepository()
        {
            _keywords = new List<Keyword>
            {
                new Keyword
                {
                    Name = "编程开发语言",
                    Id = 1,
                    SecendKeyword = new List<SecendKeyword>
                    {
                        new SecendKeyword{Name = "C#",Id = 1 },
                        new SecendKeyword{Name = "Java",Id = 2},
                        new SecendKeyword{Name = "Javascript",Id = 3},
                        new SecendKeyword{Name = "Html",Id = 4 },
                        new SecendKeyword{Name = "SQL",Id = 5 },
                        new SecendKeyword{Name = "Python",Id = 6},
                        new SecendKeyword{Name = "CSS",Id = 7},
                        new SecendKeyword{Name = "PHP",Id = 8}
                    },
                    SelfDefined = new List<Keyword>{}
                },
                new Keyword
                {
                    Name = "工具软件",
                    Id = 2,
                    SecendKeyword = new List<SecendKeyword>
                    {
                        new SecendKeyword{Name = "VisualStudio",Id = 1 },
                        new SecendKeyword{Name = "eclipse",Id = 2},
                        new SecendKeyword{Name = "IDEA",Id = 3},
                        new SecendKeyword{Name = "Excel",Id = 4 },
                        new SecendKeyword{Name = "Word",Id = 5 },
                        new SecendKeyword{Name = "CAD",Id = 6},
                        new SecendKeyword{Name = "Photoshop",Id = 7},
                        new SecendKeyword{Name = "PowerPoint",Id = 8}
                    },
                    SelfDefined = new List<Keyword>{}
                },
                new Keyword
                {
                    Name = "顾问咨询",
                    Id = 3,
                    SecendKeyword = new List<SecendKeyword>
                    {
                        new SecendKeyword{Name = "职场",Id = 1 },
                        new SecendKeyword{Name = "法律",Id = 2},
                        new SecendKeyword{Name = "财务",Id = 3},
                        new SecendKeyword{Name = "心理",Id = 4 },
                        new SecendKeyword{Name = "亲子",Id = 5 },
                        new SecendKeyword{Name = "婚姻家庭",Id = 6}
                    },
                    SelfDefined = new List<Keyword>{}
                },
                new Keyword
                {
                    Name = "操作系统",
                    Id = 4,
                    SecendKeyword = new List<SecendKeyword>
                    {
                        new SecendKeyword{Name = "Linux",Id = 1 },
                        new SecendKeyword{Name = "Windows",Id = 2},
                        new SecendKeyword{Name = "Android",Id = 3},
                        new SecendKeyword{Name = "Unix",Id = 4 },
                    },
                    SelfDefined = new List<Keyword>{}
                }
            };
        }

        /// <summary>
        /// Update Keywords
        /// </summary>
        /// <param name="keyword">Need keyword string</param>
        /// <param name="ArticleId">Need article id</param>
        public void UpdateKeywords(string keyword,int ArticleId)
        {
            KeywordRepository temp = new KeywordRepository();
            temp.DeleteKeywordToArticle(ArticleId);

            IList<string> keywords = keyword.Trim().Split(" ");
            for (int i = 0; i < keywords.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(keywords[i]))
                {
                    continue;
                }
                int keywordsId = temp.GetKeywordsId(keywords[i]);
                temp.PlusUsedKeyword(keywordsId);
                temp.AttachKeyword(ArticleId, keywordsId);
            }
        }

        /// <summary>
        /// Delete n:n relation table
        /// </summary>
        /// <param name="getArticleId">Need Article Id</param>
        public void DeleteKeywordToArticle(int getArticleId)
        {
            using (DbConnection connection = _helper.Connection)
            {
                DbCommand cmd = new SqlCommand("Delete KeywordToArticle where ArticleNameId = @ArticleId", (SqlConnection)connection);
                cmd.Parameters.Add(new SqlParameter("@ArticleId", getArticleId));
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #region For Save Keyword
        /// <summary>
        /// Get keywordId from database
        /// </summary>
        /// <param name="keywordsName">keyword name</param>
        /// <returns></returns>
        public int GetKeywordsId(string keywordsName)
        {
            int keywordId = GetKeywordIdBy(keywordsName);

            if (keywordId != 0)
            {
                return keywordId;
            }//else nothing.
            return NewKeyword(keywordsName);
        }

        /// <summary>
        /// Save this keyword into database and return this keywordId
        /// </summary>
        /// <param name="keywordsName">Keyword name</param>
        public int NewKeyword(string keywordsName)
        {
            using (DbConnection connection = _helper.Connection)
            {
                connection.Open();
                DbCommand addNewKeyword = new SqlCommand("Insert Keyword(Name,Used) Values(@Keyword,0) Set @NewId = @@Identity ", (SqlConnection)connection);
                SqlParameter pId = new SqlParameter("@NewId", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                addNewKeyword.Parameters.AddRange(new SqlParameter[] {
                    new SqlParameter("@Keyword", keywordsName),
                    pId });

                addNewKeyword.ExecuteNonQuery();

                return Convert.ToInt32(pId.Value);
            }
        }

        /// <summary>
        /// Check keyword is exist or not in database
        /// </summary>
        /// <param name="keywordsName">Need keyword name</param>
        /// <returns></returns>
        public int GetKeywordIdBy(string keywordsName)
        {
            using (DbConnection connection = _helper.Connection)
            {
                connection.Open();

                DbCommand checkKeywordsExist = new SqlCommand("Select Id From Keyword where Name = @Keyword", (SqlConnection)connection);
                checkKeywordsExist.Parameters.Add(new SqlParameter("@Keyword", keywordsName));

                object reader = checkKeywordsExist.ExecuteScalar();
                if (reader == DBNull.Value)
                {
                    return 0;
                }//else nothing.
                if (reader == null)
                {
                    return 0;
                }//else nothing.
                return Convert.ToInt32(reader);
            }
        }

        /// <summary>
        /// Plus Used Keyword
        /// </summary>
        /// <param name="id">Need one keyword id</param>
        public void PlusUsedKeyword(int id)
        {
            using (DbConnection connection = _helper.Connection)
            {
                connection.Open();

                //Plus keyword use.
                DbCommand plusUsed = new SqlCommand(
                $"Update Keyword Set Used += 1 Where Id = (Select Id From Keyword where Id = {id}) ", (SqlConnection)connection);
                plusUsed.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Save to n:n relation Table
        /// </summary>
        /// <param name="articleId">Need articleId</param>
        /// <param name="keywordsId">Need keywordId</param>
        public void AttachKeyword(int articleId, int keywordId)
        {
            using (DbConnection connection = _helper.Connection)
            {
                connection.Open();
                DbCommand command = new SqlCommand($"Insert KeywordToArticle(ArticleNameId,KeywordId) Values({articleId},{keywordId})", (SqlConnection)connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion


        public IList<Keyword> Get()
        {
            IList<Keyword> _orderKeywords = new List<Keyword>();
            foreach (var FristKeywords in _keywords)
            {
                _orderKeywords.Add(FristKeywords);
                foreach (var SecendKeywords in FristKeywords.SecendKeyword)
                {
                    _orderKeywords.Add(SecendKeywords);
                }
            }
            return _orderKeywords;
        }

        public IList<Keyword> GetKeywords()
        {
            return _keywords.ToList();
        }

    }


}
