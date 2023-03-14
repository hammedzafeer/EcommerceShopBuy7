using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopBuy7.Data.Migrations
{
    public partial class ControllerUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "SWallet");

            migrationBuilder.AddColumn<double>(
                name: "EWallet",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EWallet",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubCategories");

            migrationBuilder.RenameColumn(
                name: "SWallet",
                table: "Transactions",
                newName: "Amount");
        }
    }
}
