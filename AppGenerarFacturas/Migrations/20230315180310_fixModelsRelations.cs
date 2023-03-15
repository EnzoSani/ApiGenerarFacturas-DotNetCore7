using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppGenerarFacturas.Migrations
{
    /// <inheritdoc />
    public partial class fixModelsRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Companies_CompaniesId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UsersId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiseLines_Bills_BillsId",
                table: "InvoiseLines");

            migrationBuilder.RenameColumn(
                name: "BillsId",
                table: "InvoiseLines",
                newName: "BillId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiseLines_BillsId",
                table: "InvoiseLines",
                newName: "IX_InvoiseLines_BillId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Companies",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_UsersId",
                table: "Companies",
                newName: "IX_Companies_UserId");

            migrationBuilder.RenameColumn(
                name: "CompaniesId",
                table: "Bills",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_CompaniesId",
                table: "Bills",
                newName: "IX_Bills_CompanyId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "BillId",
                table: "InvoiseLines",
                newName: "BillsId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiseLines_BillId",
                table: "InvoiseLines",
                newName: "IX_InvoiseLines_BillsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Companies",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_UserId",
                table: "Companies",
                newName: "IX_Companies_UsersId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Bills",
                newName: "CompaniesId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_CompanyId",
                table: "Bills",
                newName: "IX_Bills_CompaniesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Companies_CompaniesId",
                table: "Bills",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UsersId",
                table: "Companies",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiseLines_Bills_BillsId",
                table: "InvoiseLines",
                column: "BillsId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
