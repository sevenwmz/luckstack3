using EntityMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC
{
    public class SqlContext : DbContext
    {
        public DbSet<User> Users { set; get; }
        public DbSet<BMoney> BMoneys { set; get; }
        public DbSet<Article> Articles { set; get; }
        public DbSet<Keywords> Keywords { set; get; }
        public DbSet<KeywordsAndArticle> KeywordsAndArticle { set; get; }

        public SqlContext() : base("MvcRepository")
        {
#if DEBUG
            Database.Log = s => File.AppendAllText("C:\\EF.log", s);
#endif
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(256);
            modelBuilder.Entity<KeywordsAndArticle>().HasKey(ka => new {ka.ArticleId,ka.KeywordId })
                ;
             
        }



    }
}
