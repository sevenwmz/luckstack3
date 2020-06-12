using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    class Repository_Of_EFCore :DbContext
    {
        #region DbSet Area
        public DbSet<User> Users { set; get; }
        public DbSet<Keywords> Keywords { set; get; }
        public DbSet<Article> Articles { set; get; }
        public DbSet<Problem> Problem { set; get; }
        public DbSet<Kind> Kinds { set; get; }
        public DbSet<BMoney> BMoneys { set; get; }
        public DbSet<Message> Messages { set; get; }
        //public DbSet<ProblemStatus> ProblemStatuses { set; get; }


        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=-20191126PKLSWP;Initial Catalog=EFCore;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString)
            #if DEBUG
                .EnableSensitiveDataLogging()
            #endif
                ;
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Register");
                u.Property(u => u.Name).HasColumnName("UserName");
                u.Property(u => u.Name).HasMaxLength(256);
                u.Property(u => u.Password).IsRequired();
                u.HasKey(u => u.Name);
                u.HasIndex(u => u.Name);
                u.HasIndex(u => u.CreateTime).IsClustered(false);
                u.Ignore(u => u.FailedTry);
                u.HasOne<Email>(u=>u.SendTo).WithOne(u => u.FromWho).HasForeignKey<User>(u=>u.SendToId);
            });
            modelBuilder.Entity<Keywords_Of_Problem>().HasKey(kp => new { kp.KeywordId, kp.ProblemId });
            modelBuilder.Entity<Keywords_Of_Article>().HasKey(ka => new { ka.KeywordId, ka.ArticleId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
