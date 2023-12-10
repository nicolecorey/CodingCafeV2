using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingCafeV2.Migrations
{
    public partial class MenuMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "MenuId", "Description", "Item" },
                values: new object[,]
                {
                    { 1, "A dark, robust blend.", "JavaScript Java" },
                    { 2, "A delicious brew, minus the jitters!", ".NET Decaf" },
                    { 3, "Traditional hot chocolate, with whip!", "HTML Hot Cocoa" },
                    { 4, "A tasty latte made with caramel and vanilla.", "LINQ Latte" }
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                column: "MenuId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                column: "MenuId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 3,
                column: "MenuId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 4,
                column: "MenuId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MenuId",
                table: "Customers",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Menu_MenuId",
                table: "Customers",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Menu_MenuId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MenuId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Customers");
        }
    }
}
