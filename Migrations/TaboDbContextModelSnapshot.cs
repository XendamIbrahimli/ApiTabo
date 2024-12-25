﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tabo.DAL;

#nullable disable

namespace Tabo.Migrations
{
    [DbContext(typeof(TaboDbContext))]
    partial class TaboDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tabo.Entities.BannedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("BannedWords");
                });

            modelBuilder.Entity("Tabo.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BannedWordCount")
                        .HasColumnType("int");

                    b.Property<int>("FailCount")
                        .HasColumnType("int");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("nchar(3)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.Property<int>("SkipCount")
                        .HasColumnType("int");

                    b.Property<int?>("SuccessAnswer")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int?>("WrongAnswer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageCode");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Tabo.Entities.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(3)
                        .HasColumnType("nchar(3)")
                        .IsFixedLength();

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Code");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Code = "az",
                            Icon = "https://cdn-icons-png.flaticon.com/512/330/330544.png",
                            Name = "Azerbaijan"
                        });
                });

            modelBuilder.Entity("Tabo.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("nchar(3)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageCode");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("Tabo.Entities.BannedWord", b =>
                {
                    b.HasOne("Tabo.Entities.Word", "Word")
                        .WithMany("BannedWords")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Tabo.Entities.Game", b =>
                {
                    b.HasOne("Tabo.Entities.Language", "Language")
                        .WithMany("Games")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Tabo.Entities.Word", b =>
                {
                    b.HasOne("Tabo.Entities.Language", "Language")
                        .WithMany("Words")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Tabo.Entities.Language", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Words");
                });

            modelBuilder.Entity("Tabo.Entities.Word", b =>
                {
                    b.Navigation("BannedWords");
                });
#pragma warning restore 612, 618
        }
    }
}
