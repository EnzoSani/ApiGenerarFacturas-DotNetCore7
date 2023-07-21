using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppGenerarFacturas.Migrations
{
    /// <inheritdoc />
    public partial class FixModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Companies_CompanyId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiseLines_Bills_BillId",
                table: "InvoiseLines");

            migrationBuilder.DropIndex(
                name: "IX_Companies_UserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Companies");

            migrationBuilder.AddColumn<bool>(
                name: "EsAdministrador",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "InvoiseLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Bills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BillNumber",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AdminId",
                table: "Companies",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Companies_CompanyId",
                table: "Bills",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_AdminId",
                table: "Companies",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiseLines_Bills_BillId",
                table: "InvoiseLines",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Companies_CompanyId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_AdminId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiseLines_Bills_BillId",
                table: "InvoiseLines");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AdminId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "EsAdministrador",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "BillNumber",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "BillId",
                table: "InvoiseLines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserId",
                table: "Companies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Companies_CompanyId",
                table: "Bills",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UserId",
                table: "Companies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiseLines_Bills_BillId",
                table: "InvoiseLines",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
