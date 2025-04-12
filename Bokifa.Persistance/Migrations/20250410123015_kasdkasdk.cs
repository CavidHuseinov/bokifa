using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokifa.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class kasdkasdk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TTag_Tags_TagId",
                table: "TTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TTag",
                table: "TTag");

            migrationBuilder.RenameTable(
                name: "TTag",
                newName: "TTags");

            migrationBuilder.RenameIndex(
                name: "IX_TTag_TagId",
                table: "TTags",
                newName: "IX_TTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TTags",
                table: "TTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TTags_Tags_TagId",
                table: "TTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TTags_Tags_TagId",
                table: "TTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TTags",
                table: "TTags");

            migrationBuilder.RenameTable(
                name: "TTags",
                newName: "TTag");

            migrationBuilder.RenameIndex(
                name: "IX_TTags_TagId",
                table: "TTag",
                newName: "IX_TTag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TTag",
                table: "TTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TTag_Tags_TagId",
                table: "TTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
