﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokifa.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ajksdasjklhd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AppUserAndPromocodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AppUserAndPromocodes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AppUserAndPromocodes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppUserAndPromocodes");
        }
    }
}
