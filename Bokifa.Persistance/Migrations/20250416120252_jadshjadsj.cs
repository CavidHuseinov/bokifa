using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokifa.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class jadshjadsj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "ContactAddresses",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmedAt",
                table: "ContactAddresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "ContactAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmedAt",
                table: "ContactAddresses");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "ContactAddresses");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ContactAddresses",
                newName: "Phone");
        }
    }
}
