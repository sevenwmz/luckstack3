﻿// <auto-generated />
using System;
using HomeWork_Of_EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeWork_Of_EFCore.Migrations
{
    [DbContext(typeof(Repository_Of_EFCore))]
    [Migration("20200612042324_Add_Message_With_User_FK")]
    partial class Add_Message_With_User_FK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeWork_Of_EFCore.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.BMoney", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LatesTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeftBMoney")
                        .HasColumnType("int");

                    b.Property<int>("LeftBPoint")
                        .HasColumnType("int");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerName");

                    b.ToTable("BMoneys");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Keywords", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Keywords_Of_Article", b =>
                {
                    b.Property<int>("KeywordId")
                        .HasColumnType("int");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.HasKey("KeywordId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("Keywords_Of_Article");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Keywords_Of_Problem", b =>
                {
                    b.Property<int>("KeywordId")
                        .HasColumnType("int");

                    b.Property<int>("ProblemId")
                        .HasColumnType("int");

                    b.HasKey("KeywordId", "ProblemId");

                    b.HasIndex("ProblemId");

                    b.ToTable("Keywords_Of_Problem");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Kind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kinds");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasCheck")
                        .HasColumnType("bit");

                    b.Property<bool>("HasRead")
                        .HasColumnType("bit");

                    b.Property<int>("MessageStatus")
                        .HasColumnType("int");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerName");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Problem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HaveKindId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Reward")
                        .HasColumnType("int");

                    b.Property<int>("Statu")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("HaveKindId");

                    b.ToTable("Problem");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.User", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnName("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SendToId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("CreateTime")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("Name");

                    b.HasIndex("SendToId")
                        .IsUnique()
                        .HasFilter("[SendToId] IS NOT NULL");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Article", b =>
                {
                    b.HasOne("HomeWork_Of_EFCore.User", "Author")
                        .WithMany("articles")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.BMoney", b =>
                {
                    b.HasOne("HomeWork_Of_EFCore.User", "Owner")
                        .WithMany("Wallet")
                        .HasForeignKey("OwnerName");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Keywords_Of_Article", b =>
                {
                    b.HasOne("HomeWork_Of_EFCore.Article", "Article")
                        .WithMany("ArticleHave")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeWork_Of_EFCore.Keywords", "Keyword")
                        .WithMany("Of_ThisArticle")
                        .HasForeignKey("KeywordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Keywords_Of_Problem", b =>
                {
                    b.HasOne("HomeWork_Of_EFCore.Keywords", "Keyword")
                        .WithMany("Of_ThisProblem")
                        .HasForeignKey("KeywordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeWork_Of_EFCore.Problem", "Problem")
                        .WithMany("ProblemHave")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Message", b =>
                {
                    b.HasOne("HomeWork_Of_EFCore.User", "Owner")
                        .WithMany("HaveMessages")
                        .HasForeignKey("OwnerName");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.Problem", b =>
                {
                    b.HasOne("HomeWork_Of_EFCore.User", "Author")
                        .WithMany("Problems")
                        .HasForeignKey("AuthorId");

                    b.HasOne("HomeWork_Of_EFCore.Kind", "HaveKind")
                        .WithMany("ThisProblem")
                        .HasForeignKey("HaveKindId");
                });

            modelBuilder.Entity("HomeWork_Of_EFCore.User", b =>
                {
                    b.HasOne("HomeWork_Of_EFCore.Email", "SendTo")
                        .WithOne("FromWho")
                        .HasForeignKey("HomeWork_Of_EFCore.User", "SendToId");
                });
#pragma warning restore 612, 618
        }
    }
}