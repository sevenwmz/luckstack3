using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_Of_EFCore
{
    class Repository_Of_EFCore :DbContext
    {
        public DbSet<User> users { set; get; }


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
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
