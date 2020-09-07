using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class AddedEmailToAgentFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Agents",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "fab46e4e-9cdc-473f-83e2-240a7455f1a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "fbef82c1-c77c-439f-9ef9-294a4906b40a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "aa7696f4-347b-4c38-be76-2b355ae0c4f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c48771cb-b5c9-48cd-b5a2-c97664a9ef5b", "AQAAAAEAACcQAAAAEACM3NkmvD/GoFc6ho14fL6wKVQVB+i1unBPM/gOnMFIeLdA9QXBGHJGdIWSiZRwgw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1cc70f30-e546-42b7-a549-37c13dbcc9ae", "AQAAAAEAACcQAAAAEGeoYb/jud28Gvlhiun4afxvUtt3biCI0MmRU3tPlv8ud9vd0bOOFWe1gZ6P2f66zw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Agents");

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
        }
    }
}
