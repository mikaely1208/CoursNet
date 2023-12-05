﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "ntext", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    Remarks = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Price", "PublishDate", "Remarks", "Title" },
                values: new object[,]
                {
                    { 1, "Christian Nagel", "A true masterclass in C# and .NET programming", "Software", 50m, new DateTime(2016, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional C# 6 and .NET Core 1.0" },
                    { 2, "Christian Nagel", "A true masterclass in C# and .NET programming", "Software", 50m, new DateTime(2018, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional C# 7 and .NET Core 2.0" },
                    { 3, "Christian Nagel", "A true masterclass in C# and .NET programming", "Software", 50m, new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional C# 8 and .NET Core 3.0" },
                    { 4, "Christian Nagel", "A true masterclass in C# and .NET programming", "Software", 50m, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Professional C# 9 and .NET 5" },
                    { 5, "Perkins, Reid, and Hammer", "The perfect guide to Visual C#", "Software", 45m, new DateTime(2020, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beginning Visual C# 2019" },
                    { 6, "Andrew Troelsen", "The ultimate C# resource", "Software", 50m, new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pro C# 7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
