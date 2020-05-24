using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPSBillPayment.Migrations.ScotiaCustomer
{
    public partial class ScotiaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ScotiaCustomer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    First = table.Column<string>(maxLength: 60, nullable: false),
                    Last = table.Column<string>(maxLength: 60, nullable: false),
                    Address = table.Column<string>(maxLength: 60, nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 60, nullable: false),
                    CardNumber = table.Column<string>(maxLength: 60, nullable: false),
                    AvaBalance = table.Column<decimal>(nullable: false),
                    AccountType = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScotiaCustomer", x => x.id);
                });
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
  

            migrationBuilder.DropTable(
                name: "ScotiaCustomer");

    
        }
    }
}
