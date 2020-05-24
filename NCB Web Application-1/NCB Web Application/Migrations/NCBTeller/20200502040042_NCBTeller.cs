using Microsoft.EntityFrameworkCore.Migrations;

namespace NCB_Web_Application.Migrations.NCBTeller
{
    public partial class NCBTeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tellers",
                columns: table => new
                {
                    TellId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tellName = table.Column<string>(type: "varchar(40)", nullable: true),
                    tellAddress = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tellers", x => x.TellId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tellers");
        }
    }
}
