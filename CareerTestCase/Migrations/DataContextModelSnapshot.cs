﻿// <auto-generated />
using System;
using CareerTestCase.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CareerTestCase.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Apply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JopId")
                        .HasColumnName("Jop_id")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnName("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JopId");

                    b.HasIndex("UserId");

                    b.ToTable("Applies");
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Cv", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("User_Id")
                        .HasColumnType("int");

                    b.Property<string>("CvName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UserId")
                        .HasName("PK_Cvs_1");

                    b.ToTable("Cvs");
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StarDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserId")
                        .HasColumnName("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Experince", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConpanyName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserId")
                        .HasColumnName("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Experincies");
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnName("Company_Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Jops");
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Apply", b =>
                {
                    b.HasOne("CareerTestCase.DAL.Entities.Job", "Jop")
                        .WithMany("Applies")
                        .HasForeignKey("JopId")
                        .HasConstraintName("FK_Applies_Jop")
                        .IsRequired();

                    b.HasOne("CareerTestCase.DAL.Entities.User", "User")
                        .WithMany("Applies")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Applies_User")
                        .IsRequired();
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Cv", b =>
                {
                    b.HasOne("CareerTestCase.DAL.Entities.User", "User")
                        .WithOne("Cvs")
                        .HasForeignKey("CareerTestCase.DAL.Entities.Cv", "UserId")
                        .HasConstraintName("FK_Cvs_Users")
                        .IsRequired();
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Education", b =>
                {
                    b.HasOne("CareerTestCase.DAL.Entities.Cv", "Cvs")
                        .WithMany("Educations")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Educations_Cvs")
                        .IsRequired();
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Experince", b =>
                {
                    b.HasOne("CareerTestCase.DAL.Entities.Cv", "Cvs")
                        .WithMany("Experincies")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Experincies_CVs")
                        .IsRequired();
                });

            modelBuilder.Entity("CareerTestCase.DAL.Entities.Job", b =>
                {
                    b.HasOne("CareerTestCase.DAL.Entities.Company", "Company")
                        .WithMany("Jops")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_Jops_Company")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}