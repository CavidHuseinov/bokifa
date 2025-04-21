using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokifa.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class aksldadkadslkalkdsasdadsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Variants",
                newName: "Variants",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "TVariants",
                newName: "TVariants",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "TTags",
                newName: "TTags",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "THeadBanners",
                newName: "THeadBanners",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "TCategory",
                newName: "TCategory",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "TBooks",
                newName: "TBooks",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "TBlogs",
                newName: "TBlogs",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "TBanners",
                newName: "TBanners",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tags",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "ShippingInfos",
                newName: "ShippingInfos",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Reviews",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Promocodes",
                newName: "Promocodes",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "NotificationModels",
                newName: "NotificationModels",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "HeadBanners",
                newName: "HeadBanners",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Favorites",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currencies",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "ContactAddresses",
                newName: "ContactAddresses",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItems",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Books",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "BookAndVariants",
                newName: "BookAndVariants",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "BookAndTags",
                newName: "BookAndTags",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "BookAndCategories",
                newName: "BookAndCategories",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blogs",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "BlogAndTags",
                newName: "BlogAndTags",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Banners",
                newName: "Banners",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Authors",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "bokifaT");

            migrationBuilder.RenameTable(
                name: "AppUserAndPromocodes",
                newName: "AppUserAndPromocodes",
                newSchema: "bokifaT");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                schema: "bokifaT",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Variants",
                schema: "bokifaT",
                newName: "Variants");

            migrationBuilder.RenameTable(
                name: "TVariants",
                schema: "bokifaT",
                newName: "TVariants");

            migrationBuilder.RenameTable(
                name: "TTags",
                schema: "bokifaT",
                newName: "TTags");

            migrationBuilder.RenameTable(
                name: "THeadBanners",
                schema: "bokifaT",
                newName: "THeadBanners");

            migrationBuilder.RenameTable(
                name: "TCategory",
                schema: "bokifaT",
                newName: "TCategory");

            migrationBuilder.RenameTable(
                name: "TBooks",
                schema: "bokifaT",
                newName: "TBooks");

            migrationBuilder.RenameTable(
                name: "TBlogs",
                schema: "bokifaT",
                newName: "TBlogs");

            migrationBuilder.RenameTable(
                name: "TBanners",
                schema: "bokifaT",
                newName: "TBanners");

            migrationBuilder.RenameTable(
                name: "Tags",
                schema: "bokifaT",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "ShippingInfos",
                schema: "bokifaT",
                newName: "ShippingInfos");

            migrationBuilder.RenameTable(
                name: "Reviews",
                schema: "bokifaT",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Promocodes",
                schema: "bokifaT",
                newName: "Promocodes");

            migrationBuilder.RenameTable(
                name: "NotificationModels",
                schema: "bokifaT",
                newName: "NotificationModels");

            migrationBuilder.RenameTable(
                name: "HeadBanners",
                schema: "bokifaT",
                newName: "HeadBanners");

            migrationBuilder.RenameTable(
                name: "Favorites",
                schema: "bokifaT",
                newName: "Favorites");

            migrationBuilder.RenameTable(
                name: "Currencies",
                schema: "bokifaT",
                newName: "Currencies");

            migrationBuilder.RenameTable(
                name: "ContactAddresses",
                schema: "bokifaT",
                newName: "ContactAddresses");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "bokifaT",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "CartItems",
                schema: "bokifaT",
                newName: "CartItems");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "bokifaT",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "BookAndVariants",
                schema: "bokifaT",
                newName: "BookAndVariants");

            migrationBuilder.RenameTable(
                name: "BookAndTags",
                schema: "bokifaT",
                newName: "BookAndTags");

            migrationBuilder.RenameTable(
                name: "BookAndCategories",
                schema: "bokifaT",
                newName: "BookAndCategories");

            migrationBuilder.RenameTable(
                name: "Blogs",
                schema: "bokifaT",
                newName: "Blogs");

            migrationBuilder.RenameTable(
                name: "BlogAndTags",
                schema: "bokifaT",
                newName: "BlogAndTags");

            migrationBuilder.RenameTable(
                name: "Banners",
                schema: "bokifaT",
                newName: "Banners");

            migrationBuilder.RenameTable(
                name: "Authors",
                schema: "bokifaT",
                newName: "Authors");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "bokifaT",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "bokifaT",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "bokifaT",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "bokifaT",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "bokifaT",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "bokifaT",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "bokifaT",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AppUserAndPromocodes",
                schema: "bokifaT",
                newName: "AppUserAndPromocodes");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
