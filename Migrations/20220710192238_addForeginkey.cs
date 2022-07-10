using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class addForeginkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "Fees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fees_ExpenseId",
                table: "Fees",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Expenses_ExpenseId",
                table: "Fees",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_Expenses_ExpenseId",
                table: "Fees");

            migrationBuilder.DropIndex(
                name: "IX_Fees_ExpenseId",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Fees");
        }
    }
}
