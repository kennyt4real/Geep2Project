using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class AddedNoOfEmplyeesAndValueOfBusinessToBeneficiaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfEmployees",
                table: "Beneficiaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValueOfCurrentBusiness",
                table: "Beneficiaries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "671821a3-43e7-4732-83c6-5cd60389329a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "b308790e-7869-4bc7-b546-49e2f414e308");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "fa703b53-4b81-415a-860d-49138fa3551d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a34a5929-5254-4274-8088-6aa9a56611aa", "AQAAAAEAACcQAAAAEKGC0MTZNeDt6PjtG/rjsZ4uwKwQ96tGoI8OLB7Evwj05ooTDxlOFIaSyy2v71iUnQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3be2b258-557a-402f-9ed9-947bafe42d63", "AQAAAAEAACcQAAAAEER6APKwXQlr8S5wP534fr1kebWvx4bE8w0QWFQeFnX9QMLcMmEcUcp9MQzvMfaG4Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfEmployees",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "TotalValueOfCurrentBusiness",
                table: "Beneficiaries");

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
    }
}
