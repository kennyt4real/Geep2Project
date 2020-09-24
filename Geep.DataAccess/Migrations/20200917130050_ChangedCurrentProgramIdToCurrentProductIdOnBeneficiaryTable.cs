using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class ChangedCurrentProgramIdToCurrentProductIdOnBeneficiaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentProgramId",
                table: "Beneficiaries");

            migrationBuilder.AddColumn<int>(
                name: "CurrentProductId",
                table: "Beneficiaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "4aa72256-9f8e-442e-83a6-c44612466d7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "7cfd1cc0-af67-4568-a838-b2a544b7eb2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "59e91b3a-62cf-4514-a4f3-3235c7c68ef0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "872157eb-3f56-4c3f-8753-63edd09dac49", "AQAAAAEAACcQAAAAEBMICRQ9zDoEZ1Mf7Vfvd7qGNwQbd/W6hpNRo/B8NpjK4BYvS2rwK9LZ7zG67Afftg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e347e3c9-8104-4c9e-88ce-81c360db083e", "AQAAAAEAACcQAAAAEGtCq322BgiBSAPDh50MmwE7lw+zVFmFv3waXeOk07pG8Wg7oyyoqjDPSqdgdItNQA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentProductId",
                table: "Beneficiaries");

            migrationBuilder.AddColumn<int>(
                name: "CurrentProgramId",
                table: "Beneficiaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "9278c3bb-a408-429c-8b10-1a6dd2631a91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "8006763b-7eab-41bb-a23e-15a469197655");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "927b40e5-0518-4da8-96dc-08bda142529c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ab35c79b-b69d-4e9d-b36f-d0995ff3b48b", "AQAAAAEAACcQAAAAEEb3Aj4ekFJn/ULZkuHdzEZyKY/B2eAGZ1m0joz7lAEHu99B6OhGwFt6xZQkf/N4IA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "906a5422-48be-4609-90ed-6ec59ff2aaa6", "AQAAAAEAACcQAAAAELgH6YkGlfy63Ql2CNYHFpNZxdiglMXshJpYEz5uY7+YHgZjqx2sGJcdQxjlt1mNFw==" });
        }
    }
}
