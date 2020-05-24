using Microsoft.EntityFrameworkCore.Migrations;

namespace JPSBillPayment.Migrations.Payment
{
    public partial class PaymentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amountPaid = table.Column<decimal>(nullable: false),
                    customerId = table.Column<string>(nullable: false),
                    Fname = table.Column<string>(nullable: false),
                    premisesNum = table.Column<int>(nullable: false),
                    cardNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
