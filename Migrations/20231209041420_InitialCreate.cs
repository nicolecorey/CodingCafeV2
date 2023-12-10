using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingCafeV2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Address", "City", "Email", "FirstName", "LastName", "Phone", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "100 Cafe Circle", "Traverse City", "jacksmith@gmail.com", "Jack", "Smith", "1234567890", "MI", "49684" },
                    { 2, "100 Cafe Circle", "Traverse City", "jillsmith@gmail.com", "Jill", "Smith", "1234567891", "MI", "49684" },
                    { 3, "123 Apple Way", "Detroit", "stevejobs@gmail.com", "Steve", "Jobs", "1234567892", "MI", "56476" },
                    { 4, "456 Microsoft Ln", "Grand Rapids", "billgates@gmail.com", "Bill", "Gates", "234567893", "MI", "44455" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
