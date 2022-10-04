using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Project.Backend.Infra.Migrations
{
    public partial class NewUpdate20221004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Addresses_AdressId",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "Suppliers",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_AdressId",
                table: "Suppliers",
                newName: "IX_Suppliers_AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Suppliers",
                type: "char(12)",
                unicode: false,
                fixedLength: true,
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(11)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "char(12)",
                unicode: false,
                fixedLength: true,
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(11)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 11);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Addresses_AddressId",
                table: "Suppliers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Addresses_AddressId",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Suppliers",
                newName: "AdressId");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_AddressId",
                table: "Suppliers",
                newName: "IX_Suppliers_AdressId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Suppliers",
                type: "char(11)",
                unicode: false,
                fixedLength: true,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(12)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "char(11)",
                unicode: false,
                fixedLength: true,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(12)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 12);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Addresses_AdressId",
                table: "Suppliers",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
