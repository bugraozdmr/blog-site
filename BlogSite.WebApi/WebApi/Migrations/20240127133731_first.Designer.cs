﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.EFCore;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240127133731_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("secondaryTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "grant",
                            Content = "dkwqdlwqdlqw",
                            CreatedAt = new DateTime(2024, 1, 27, 13, 37, 31, 289, DateTimeKind.Utc).AddTicks(5080),
                            Slug = "what-biden-did",
                            Title = "sdqdwq",
                            secondaryTitle = "what biden did"
                        },
                        new
                        {
                            Id = 2,
                            Author = "grant",
                            Content = "dkwqdlwqdlqw",
                            CreatedAt = new DateTime(2024, 1, 27, 13, 37, 31, 289, DateTimeKind.Utc).AddTicks(5080),
                            Slug = "what-biden-did",
                            Title = "wrfqwr",
                            secondaryTitle = "what biden did"
                        },
                        new
                        {
                            Id = 3,
                            Author = "grant",
                            Content = "dkwqdlwqdlqw",
                            CreatedAt = new DateTime(2024, 1, 27, 13, 37, 31, 289, DateTimeKind.Utc).AddTicks(5090),
                            Slug = "what-biden-did",
                            Title = "fewfwe",
                            secondaryTitle = "what biden did"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
