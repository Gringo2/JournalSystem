﻿// <auto-generated />
using System;
using JournalSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JournalSystem.Migrations.DataDb
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20220524221906_modified_tables")]
    partial class modified_tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryPaper", b =>
                {
                    b.Property<Guid>("CategoriesCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PapersPaperId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesCategoryId", "PapersPaperId");

                    b.HasIndex("PapersPaperId");

                    b.ToTable("CategoryPaper");
                });

            modelBuilder.Entity("CategoryTopic", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TopicsTopicId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId", "TopicsTopicId");

                    b.HasIndex("TopicsTopicId");

                    b.ToTable("CategoryTopic");
                });

            modelBuilder.Entity("JournalSystem.Entities.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstitutionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AuthorId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("JournalSystem.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("JournalSystem.Entities.Comments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CommentIntendedfor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PaperId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PaperId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("JournalSystem.Entities.Editor", b =>
                {
                    b.Property<Guid>("EditorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstitutionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EditorId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Editors");
                });

            modelBuilder.Entity("JournalSystem.Entities.Institution", b =>
                {
                    b.Property<Guid>("InstitutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Institutiion_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institution_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institution_Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institution_website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstitutionId");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("JournalSystem.Entities.Paper", b =>
                {
                    b.Property<Guid>("PaperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abstract")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Article_File_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EditorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("File_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Hop_count")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Page_size")
                        .HasColumnType("int");

                    b.Property<string>("ReviewerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("PaperId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("EditorId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("TopicId");

                    b.ToTable("Papers");
                });

            modelBuilder.Entity("JournalSystem.Entities.Reviewer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid>("InstitutionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid>("ReviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("JournalSystem.Entities.Topic", b =>
                {
                    b.Property<Guid>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PaperId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Topic_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("CategoryPaper", b =>
                {
                    b.HasOne("JournalSystem.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JournalSystem.Entities.Paper", null)
                        .WithMany()
                        .HasForeignKey("PapersPaperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryTopic", b =>
                {
                    b.HasOne("JournalSystem.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JournalSystem.Entities.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicsTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JournalSystem.Entities.Author", b =>
                {
                    b.HasOne("JournalSystem.Entities.Institution", "Institution")
                        .WithMany("Authors")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("JournalSystem.Entities.Comments", b =>
                {
                    b.HasOne("JournalSystem.Entities.Paper", "Paper")
                        .WithMany()
                        .HasForeignKey("PaperId");

                    b.Navigation("Paper");
                });

            modelBuilder.Entity("JournalSystem.Entities.Editor", b =>
                {
                    b.HasOne("JournalSystem.Entities.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("JournalSystem.Entities.Paper", b =>
                {
                    b.HasOne("JournalSystem.Entities.Author", null)
                        .WithMany("Papers")
                        .HasForeignKey("AuthorId");

                    b.HasOne("JournalSystem.Entities.Editor", null)
                        .WithMany("Papers")
                        .HasForeignKey("EditorId");

                    b.HasOne("JournalSystem.Entities.Reviewer", null)
                        .WithMany("Papers")
                        .HasForeignKey("ReviewerId");

                    b.HasOne("JournalSystem.Entities.Topic", null)
                        .WithMany("Papers")
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("JournalSystem.Entities.Reviewer", b =>
                {
                    b.HasOne("JournalSystem.Entities.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("JournalSystem.Entities.Author", b =>
                {
                    b.Navigation("Papers");
                });

            modelBuilder.Entity("JournalSystem.Entities.Editor", b =>
                {
                    b.Navigation("Papers");
                });

            modelBuilder.Entity("JournalSystem.Entities.Institution", b =>
                {
                    b.Navigation("Authors");
                });

            modelBuilder.Entity("JournalSystem.Entities.Reviewer", b =>
                {
                    b.Navigation("Papers");
                });

            modelBuilder.Entity("JournalSystem.Entities.Topic", b =>
                {
                    b.Navigation("Papers");
                });
#pragma warning restore 612, 618
        }
    }
}
