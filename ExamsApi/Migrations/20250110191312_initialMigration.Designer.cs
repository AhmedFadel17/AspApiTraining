﻿// <auto-generated />
using ExamsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamsApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250110191312_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExamsApi.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<double>("TotalMarks")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ExamsApi.Models.ExamModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamModels");
                });

            modelBuilder.Entity("ExamsApi.Models.HeadingQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<int>("ExamModelId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalMarks")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ExamModelId");

                    b.ToTable("HeadingQuestions");
                });

            modelBuilder.Entity("ExamsApi.Models.MainQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<int>("HeadingQuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalMarks")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HeadingQuestionId");

                    b.ToTable("MainQuestions");
                });

            modelBuilder.Entity("ExamsApi.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<int>("MainQuestionId")
                        .HasColumnType("int");

                    b.Property<double>("Marks")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MainQuestionId");

                    b.ToTable("Questions");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ExamsApi.Models.Questions.Paragraph", b =>
                {
                    b.HasBaseType("ExamsApi.Models.Question");

                    b.Property<string>("GuidingWords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinWords")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Paragraphs", (string)null);
                });

            modelBuilder.Entity("ExamsApi.Models.Questions.SingleChoice", b =>
                {
                    b.HasBaseType("ExamsApi.Models.Question");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Choice1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Choice2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Choice3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Choice4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SingleChoices", (string)null);
                });

            modelBuilder.Entity("ExamsApi.Models.ExamModel", b =>
                {
                    b.HasOne("ExamsApi.Models.Exam", "Exam")
                        .WithMany("ExamModels")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ExamsApi.Models.HeadingQuestion", b =>
                {
                    b.HasOne("ExamsApi.Models.ExamModel", "ExamModel")
                        .WithMany("HeadingQuestions")
                        .HasForeignKey("ExamModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExamModel");
                });

            modelBuilder.Entity("ExamsApi.Models.MainQuestion", b =>
                {
                    b.HasOne("ExamsApi.Models.HeadingQuestion", "HeadingQuestion")
                        .WithMany("MainQuestions")
                        .HasForeignKey("HeadingQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HeadingQuestion");
                });

            modelBuilder.Entity("ExamsApi.Models.Question", b =>
                {
                    b.HasOne("ExamsApi.Models.MainQuestion", "MainQuestion")
                        .WithMany("Questions")
                        .HasForeignKey("MainQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainQuestion");
                });

            modelBuilder.Entity("ExamsApi.Models.Questions.Paragraph", b =>
                {
                    b.HasOne("ExamsApi.Models.Question", null)
                        .WithOne()
                        .HasForeignKey("ExamsApi.Models.Questions.Paragraph", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExamsApi.Models.Questions.SingleChoice", b =>
                {
                    b.HasOne("ExamsApi.Models.Question", null)
                        .WithOne()
                        .HasForeignKey("ExamsApi.Models.Questions.SingleChoice", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExamsApi.Models.Exam", b =>
                {
                    b.Navigation("ExamModels");
                });

            modelBuilder.Entity("ExamsApi.Models.ExamModel", b =>
                {
                    b.Navigation("HeadingQuestions");
                });

            modelBuilder.Entity("ExamsApi.Models.HeadingQuestion", b =>
                {
                    b.Navigation("MainQuestions");
                });

            modelBuilder.Entity("ExamsApi.Models.MainQuestion", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
