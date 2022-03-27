using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderApiMicroservice.Data.Migrations
{
    public partial class InitMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    OrderState = table.Column<int>(type: "integer", nullable: false),
                    CustomerGuid = table.Column<string>(type: "text", nullable: true),
                    CustomerFullName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
