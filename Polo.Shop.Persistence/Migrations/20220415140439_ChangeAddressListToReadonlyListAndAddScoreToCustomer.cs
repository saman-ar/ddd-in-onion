using Microsoft.EntityFrameworkCore.Migrations;

namespace Polo.Shop.Persistence.Migrations
{
    public partial class ChangeAddressListToReadonlyListAndAddScoreToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                schema: "CustomerContext",
                table: "Customer",
                type: "Int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                schema: "CustomerContext",
                table: "Customer");
        }
    }
}
