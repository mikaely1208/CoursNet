﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231205134900_SecondCreate")]
    partial class SecondCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("webapi.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("ntext");

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<string>("Genre")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Remarks")
                        .HasColumnType("ntext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Christian Nagel",
                            Description = "A true masterclass in C# and .NET programming",
                            Genre = "Software",
                            Price = 50m,
                            PublishDate = new DateTime(2016, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Professional C# 6 and .NET Core 1.0"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Christian Nagel",
                            Description = "A true masterclass in C# and .NET programming",
                            Genre = "Software",
                            Price = 50m,
                            PublishDate = new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Professional C# 7 and .NET Core 2.0"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Christian Nagel",
                            Description = "A true masterclass in C# and .NET programming",
                            Genre = "Software",
                            Price = 50m,
                            PublishDate = new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Professional C# 8 and .NET Core 3.0"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Christian Nagel",
                            Description = "A true masterclass in C# and .NET programming",
                            Genre = "Software",
                            Price = 50m,
                            PublishDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Professional C# 9 and .NET 5"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Perkins, Reid, and Hammer",
                            Description = "The perfect guide to Visual C#",
                            Genre = "Software",
                            Price = 45m,
                            PublishDate = new DateTime(2020, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Beginning Visual C# 2019"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Andrew Troelsen",
                            Description = "The ultimate C# resource",
                            Genre = "Software",
                            Price = 50m,
                            PublishDate = new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pro C# 7"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
