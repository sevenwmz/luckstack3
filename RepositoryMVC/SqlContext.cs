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
        #region DbSet
        //public DbSet<AD> ADs { set; get; }
        //public DbSet<User> Users { set; get; }
        //public DbSet<Series> Series { set; get; }
        //public DbSet<BMoney> BMoneys { set; get; }
        //public DbSet<Article> Articles { set; get; }
        //public DbSet<Keywords> Keywords { set; get; }
        //public DbSet<KeywordsAndArticle> KeywordsAndArticle { set; get; }

        #endregion

        public SqlContext() : base("MvcRepository")
        {
#if DEBUG
            //Database.Log = s => File.AppendAllText("C:\\EF.log", s);
#endif
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AD>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Series>();
            modelBuilder.Entity<BMoney>();
            modelBuilder.Entity<Article>();
            modelBuilder.Entity<Keywords>();
            modelBuilder.Entity<Problem>();
            modelBuilder.Entity<KeywordsAndProblem>();
            modelBuilder.Entity<KeywordsAndArticle>();


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(256);
            modelBuilder.Entity<KeywordsAndArticle>().HasKey(ka => new { ka.ArticleId, ka.KeywordId });
            modelBuilder.Entity<KeywordsAndArticle>().Ignore(ka => ka.Id);
            modelBuilder.Entity<KeywordsAndProblem>().HasKey(kp => new { kp.ProblemId, kp.KeywordId });
            modelBuilder.Entity<KeywordsAndProblem>().Ignore(kp => kp.Id);

        }



    }
}
