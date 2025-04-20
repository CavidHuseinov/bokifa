using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokifa.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ajksdhjlasdlhj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PromocodeId",
                table: "CartItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PromocodeId",
                table: "CartItems",
                column: "PromocodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Promocodes_PromocodeId",
                table: "CartItems",
                column: "PromocodeId",
                principalTable: "Promocodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Promocodes_PromocodeId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_PromocodeId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "PromocodeId",
                table: "CartItems");
        }
    }
}
