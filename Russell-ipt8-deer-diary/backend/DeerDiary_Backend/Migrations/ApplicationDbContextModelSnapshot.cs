﻿// <auto-generated />
using System;
using DeerDiary_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeerDiary_Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DeerDiary_Backend.Models.JournalEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("JournalId")
                        .HasAnnotation("Relational:JsonPropertyName", "JournalId");

                    b.Property<string>("JournalDate")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("JournalDate");

                    b.Property<string>("JournalText")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("JournalText");

                    b.Property<string>("JournalTitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("JournalTitle");

                    b.Property<int?>("_RandomQuestionId")
                        .HasColumnType("int")
                        .HasColumnName("fk_RandomQuestionId")
                        .HasAnnotation("Relational:JsonPropertyName", "fk_RandomQuestionId");

                    b.Property<int>("_userid")
                        .HasColumnType("int")
                        .HasColumnName("fk_UserId")
                        .HasAnnotation("Relational:JsonPropertyName", "fk_UserId");

                    b.HasKey("Id");

                    b.HasIndex("_RandomQuestionId");

                    b.HasIndex("_userid");

                    b.ToTable("JournalEntries");
                });

            modelBuilder.Entity("DeerDiary_Backend.Models.RandomQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RandomQuestionId");

                    b.Property<string>("RandomQuestionText")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("RandomQuestionText");

                    b.HasKey("Id");

                    b.ToTable("RandomQuestions");
                });

            modelBuilder.Entity("DeerDiary_Backend.Models.Reply", b =>
                {
                    b.Property<int>("ReplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReplyId");

                    b.Property<string>("ReplyGeneratedQuestion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ReplyGeneratedQuestion");

                    b.Property<string>("ReplyText")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ReplyText");

                    b.Property<int>("_JournalEntryId")
                        .HasColumnType("int")
                        .HasColumnName("fk_JournalEntryId");

                    b.HasKey("ReplyId");

                    b.HasIndex("_JournalEntryId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("DeerDiary_Backend.Models.TokenBlacklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TokenId");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Token");

                    b.Property<DateTime>("TokenExpiry")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("TokenExpiry");

                    b.HasKey("Id");

                    b.ToTable("TokenBlacklists");
                });

            modelBuilder.Entity("DeerDiary_Backend.Models.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PasswordSalt");

                    b.Property<string>("UserMail")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("UserMail");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("UserName");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("UserPassword");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DeerDiary_Backend.Models.JournalEntry", b =>
                {
                    b.HasOne("DeerDiary_Backend.Models.RandomQuestion", "_randomquestion")
                        .WithMany()
                        .HasForeignKey("_RandomQuestionId");

                    b.HasOne("DeerDiary_Backend.Models.User", "_user")
                        .WithMany()
                        .HasForeignKey("_userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_randomquestion");

                    b.Navigation("_user");
                });

            modelBuilder.Entity("DeerDiary_Backend.Models.Reply", b =>
                {
                    b.HasOne("DeerDiary_Backend.Models.JournalEntry", "_journalentry")
                        .WithMany()
                        .HasForeignKey("_JournalEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_journalentry");
                });
#pragma warning restore 612, 618
        }
    }
}
