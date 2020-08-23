using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class DOBToStringOnBeneficiaryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "Beneficiaries",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "645672ea-5a18-46f0-80ee-69ae5a9e2b5a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "ea4544bf-28af-4a65-8207-1f3b9d54267e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "f1bfb2e0-9c4d-42c4-8f39-9097adcd2be4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "12da4b8a-5470-4cf9-afa8-cfbb062004f5", "AQAAAAEAACcQAAAAEEVfh7PK9+6243ZmGElsqtyXhQ8rFLfPf36PoU6gv580M//5eWR6/bqJRmhfdRzj+g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5196c12-c9bc-45eb-90d3-b495b808c27c", "AQAAAAEAACcQAAAAEHvtwwD2zJ77ovXS7uXlX/yBFjBwG7A8p2IlaP8bSj79Ub6+GjoOxLKVvhfhf75Svw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Beneficiaries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "631da3ed-1fc5-4f80-a681-5a60c17c700f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "15cebfa3-014f-4297-9c66-1c25dd36f903");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "dd70e4d8-09cc-43be-bb1f-d17055d3a265");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32d3c82f-a8c4-4ddf-8961-6de30bcc5ee2", "AQAAAAEAACcQAAAAEKveCrlnVsViuE2nN7HZfueVBCjk6nGldF9HsQ6v7qtuN6rlWmYS7fhLyLl5Qu5z0w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0e48136e-e533-4ce0-9b7b-37f303a7a702", "AQAAAAEAACcQAAAAEH8vs6YdyGBo3sTGeiCrpGWa5j7YCRSdwPh/A1lgdjPsc+YIcR28Nu9qChlo9+DidQ==" });
        }
    }
}
