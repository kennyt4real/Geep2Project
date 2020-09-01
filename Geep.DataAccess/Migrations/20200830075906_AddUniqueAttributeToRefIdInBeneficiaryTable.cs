using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class AddUniqueAttributeToRefIdInBeneficiaryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "7940db8f-48c5-4f98-bc77-9a032edc7dee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "e8b554f8-c69c-463c-9310-a0c72a373737");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "f46d9577-1ca4-4e55-bf1b-2082e8785771");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a7f89fb-f329-4f3b-827b-eecff86ce1aa", "AQAAAAEAACcQAAAAEIuFSee0KOD3rY8/UuFBcO1VZxKc/2I96HqPYmtGkWhSKsJZ7J9zVxN2N3rG+10/yg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92e82862-2cff-452f-9b0f-4175212a0917", "AQAAAAEAACcQAAAAEKTImefvHwBQKV36ZTsgDArZFUUK6iTHGxIBVEUgxYLOYkrgzU5z/TVTpAFBDZmVDA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_ReferenceId",
                table: "Beneficiaries",
                column: "ReferenceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_ReferenceId",
                table: "Beneficiaries");

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
    }
}
