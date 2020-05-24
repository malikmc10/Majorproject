using Microsoft.EntityFrameworkCore.Migrations;

namespace NCB_Web_Application.Migrations
{
    public partial class NCB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    custId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(40)", nullable: true),
                    Address = table.Column<string>(type: "varchar(250)", nullable: true),
                    Balance = table.Column<float>(nullable: false),
                    AccNum = table.Column<string>(nullable: false),
                    CardNum = table.Column<string>(maxLength: 60, nullable: false),
                    AccType = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.custId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
