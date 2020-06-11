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
    [Migration("20200609115920_ChangeTo_1And1+1")]
    partial class ChangeTo_1And11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeWork_Of_EFCore.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FromWhoId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Email");
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
