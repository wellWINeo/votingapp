﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VotingApp.Web.Infrastructure;

#nullable disable

namespace VotingApp.Web.Migrations
{
    [DbContext(typeof(VotingAppContext))]
    [Migration("20230516214549_UpdateComments")]
    partial class UpdateComments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VoteQuestionResultVoteValue", b =>
                {
                    b.Property<Guid>("ValuesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VoteQuestionResultId")
                        .HasColumnType("uuid");

                    b.HasKey("ValuesId", "VoteQuestionResultId");

                    b.HasIndex("VoteQuestionResultId");

                    b.ToTable("VoteQuestionResultVoteValue");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("VoteForm");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteFormComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("05/16/2023 21:45:49");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("VoteFormComment");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCustomAllowed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMultipleAllowed")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.ToTable("VoteQuestion");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteQuestionResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ResultId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("ResultId");

                    b.ToTable("VoteQuestionResult");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("FormId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("FormId");

                    b.ToTable("VoteResult");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("VoteValue");
                });

            modelBuilder.Entity("VoteQuestionResultVoteValue", b =>
                {
                    b.HasOne("VotingApp.Web.Models.Entities.VoteValue", null)
                        .WithMany()
                        .HasForeignKey("ValuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VotingApp.Web.Models.Entities.VoteQuestionResult", null)
                        .WithMany()
                        .HasForeignKey("VoteQuestionResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteFormComment", b =>
                {
                    b.HasOne("VotingApp.Web.Models.Entities.VoteForm", "Form")
                        .WithMany("Comments")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteQuestion", b =>
                {
                    b.HasOne("VotingApp.Web.Models.Entities.VoteForm", "Form")
                        .WithMany("Questions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteQuestionResult", b =>
                {
                    b.HasOne("VotingApp.Web.Models.Entities.VoteQuestion", "Question")
                        .WithMany("QuestionResults")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VotingApp.Web.Models.Entities.VoteResult", "Result")
                        .WithMany("QuestionResults")
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Result");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteResult", b =>
                {
                    b.HasOne("VotingApp.Web.Models.Entities.VoteForm", "Form")
                        .WithMany("Results")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteValue", b =>
                {
                    b.HasOne("VotingApp.Web.Models.Entities.VoteQuestion", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteForm", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Questions");

                    b.Navigation("Results");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteQuestion", b =>
                {
                    b.Navigation("Options");

                    b.Navigation("QuestionResults");
                });

            modelBuilder.Entity("VotingApp.Web.Models.Entities.VoteResult", b =>
                {
                    b.Navigation("QuestionResults");
                });
#pragma warning restore 612, 618
        }
    }
}
