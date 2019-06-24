﻿// <auto-generated />
using System;
using GroupTooUniversity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GroupTooUniversity.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20190624075920_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupTooUniversity.Models.Course", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("Credits")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int?>("InstructorID");

                    b.Property<int?>("StudentID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("CourseID");

                    b.HasIndex("InstructorID");

                    b.HasIndex("StudentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("GroupTooUniversity.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("GroupTooUniversity.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PossibleAnswers");

                    b.Property<int>("SurveyId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("GroupTooUniversity.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("LastName");

                    b.Property<DateTime>("SurveyDate");

                    b.HasKey("ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("GroupTooUniversity.Models.Survey", b =>
                {
                    b.Property<int>("SurveyID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseID");

                    b.Property<int?>("InstructorID");

                    b.Property<int?>("OwnerID");

                    b.Property<bool>("Published");

                    b.Property<int>("StudentID");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("SurveyID");

                    b.HasIndex("CourseID");

                    b.HasIndex("InstructorID");

                    b.HasIndex("OwnerID");

                    b.HasIndex("StudentID");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("GroupTooUniversity.Models.Course", b =>
                {
                    b.HasOne("GroupTooUniversity.Models.Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorID");

                    b.HasOne("GroupTooUniversity.Models.Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentID");
                });

            modelBuilder.Entity("GroupTooUniversity.Models.Question", b =>
                {
                    b.HasOne("GroupTooUniversity.Models.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GroupTooUniversity.Models.Survey", b =>
                {
                    b.HasOne("GroupTooUniversity.Models.Course", "Course")
                        .WithMany("Surveys")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GroupTooUniversity.Models.Instructor")
                        .WithMany("Surveys")
                        .HasForeignKey("InstructorID");

                    b.HasOne("GroupTooUniversity.Models.Instructor", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GroupTooUniversity.Models.Student")
                        .WithMany("Surveys")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
