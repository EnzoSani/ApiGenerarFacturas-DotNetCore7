using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppGenerarFacturas.Migrations
{
    /// <inheritdoc />
    public partial class invoiseLineFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiseLines_Bills_BillId",
                table: "InvoiseLines");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "InvoiseLines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiseLines_Bills_BillId",
                table: "InvoiseLines",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiseLines_Bills_BillId",
                table: "InvoiseLines");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "InvoiseLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiseLines_Bills_BillId",
                table: "InvoiseLines",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");
        }
    }
}
