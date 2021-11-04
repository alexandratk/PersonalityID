﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalityIdentification.DataContext;

namespace PersonalitylID.Migrations
{
    [DbContext(typeof(MyDataContext))]
    [Migration("20211103124620_group")]
    partial class group
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalityIdentification.DataContext.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dateofbirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EducationalInstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.EducationalInstitution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationalInstitution");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dateofbirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EducationalInstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EducationalInstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dateofbirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EducationalInstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Administrator", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Administrators")
                        .HasForeignKey("EducationalInstitutionId");

                    b.Navigation("EducationalInstitution");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Employee", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Employees")
                        .HasForeignKey("EducationalInstitutionId");

                    b.Navigation("EducationalInstitution");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Group", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Groups")
                        .HasForeignKey("EducationalInstitutionId");

                    b.Navigation("EducationalInstitution");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Teacher", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Teachers")
                        .HasForeignKey("EducationalInstitutionId");

                    b.Navigation("EducationalInstitution");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.EducationalInstitution", b =>
                {
                    b.Navigation("Administrators");

                    b.Navigation("Employees");

                    b.Navigation("Groups");

                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
