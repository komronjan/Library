﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.Context;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230621041941_Update")]
    partial class Update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Ssn")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("WebApi.Entities.Book", b =>
                {
                    b.Property<string>("Isbn")
                        .HasColumnType("text");

                    b.Property<decimal>("Advance")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PublisherId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("YtdSales")
                        .HasColumnType("numeric");

                    b.HasKey("Isbn");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("WebApi.Entities.BookAuthor", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Isbn")
                        .HasColumnType("text");

                    b.Property<int>("AuthorOrder")
                        .HasColumnType("integer");

                    b.Property<decimal>("RoyaltyShare")
                        .HasColumnType("numeric");

                    b.HasKey("AuthorId", "Isbn");

                    b.HasIndex("Isbn");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("WebApi.Entities.BookEditor", b =>
                {
                    b.Property<string>("Isbn")
                        .HasColumnType("text");

                    b.Property<int>("EditorId")
                        .HasColumnType("integer");

                    b.HasKey("Isbn", "EditorId");

                    b.HasIndex("EditorId");

                    b.ToTable("BookEditors");
                });

            modelBuilder.Entity("WebApi.Entities.Editor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EditorPosition")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.Property<string>("Ssn")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Editors");
                });

            modelBuilder.Entity("WebApi.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("WebApi.Entities.Book", b =>
                {
                    b.HasOne("WebApi.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("WebApi.Entities.BookAuthor", b =>
                {
                    b.HasOne("WebApi.Entities.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Entities.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("Isbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("WebApi.Entities.BookEditor", b =>
                {
                    b.HasOne("WebApi.Entities.Editor", "Editor")
                        .WithMany("BookEditors")
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Entities.Book", "Book")
                        .WithMany("BookEditors")
                        .HasForeignKey("Isbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Editor");
                });

            modelBuilder.Entity("WebApi.Entities.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("WebApi.Entities.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookEditors");
                });

            modelBuilder.Entity("WebApi.Entities.Editor", b =>
                {
                    b.Navigation("BookEditors");
                });

            modelBuilder.Entity("WebApi.Entities.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
