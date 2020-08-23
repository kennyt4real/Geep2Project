using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class AddedApiFeedbackTrackingPropertiesOnBeneficiaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApprovedByWhiteList",
                table: "Beneficiaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdatedOnPortal",
                table: "Beneficiaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PushedToWhiteList",
                table: "Beneficiaries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "Beneficiaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "Beneficiaries",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "0b985797-5e31-4652-b85b-1d8f16d6f4a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "ab638a4d-4050-455a-b711-1ecfcf5b1fdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "444b9763-03f2-4295-b1c4-77ba12ba2abd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4c830e1b-ae6d-4970-8351-76ded90f0190", "AQAAAAEAACcQAAAAEMmAxsMlnnkHhssxnPgtRTFb1L7mNrtEFSIep4UXjdo8KFsP3Lx+x+OTbPH6VZ2yjA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c5e31f1-5d7c-45aa-823d-cd2a90d5c20d", "AQAAAAEAACcQAAAAEC7K1IC0JXPC2xUGHs5ftdO+W4A16/kwEOM/CY+Zo/JjaDnF4XukkV2NJP99+ZlnEg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApprovedByWhiteList",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "IsUpdatedOnPortal",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "PushedToWhiteList",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "Beneficiaries");

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
    }
}
