using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class UnknownModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "4e7603c2-1db5-4049-b324-e598c7b7b375");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "091b6dde-fc54-4238-853a-2fcdb07adaa0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "047ba26b-428f-4905-9c29-2eee688089f2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fce7c53d-f8e4-430a-a31c-ff1e7351a1dc", "AQAAAAEAACcQAAAAEKKNUvJW3vROAIwQeB5PM+xgV7FINMfWWnWftgDOrOljMVzrClVrw1stLtDWI/X5FA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "364a06ff-ac1b-4358-9754-c9aa65ce8e46", "AQAAAAEAACcQAAAAEGykJFvQx+gfYGtcNnDLc66yZzcmorv6wJsp/IiPL/PKrBR/uUzxxQ6SFq1j9zjNyA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "b3cf3029-ed3b-43e1-9f00-fd85b42fb11c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "b254aead-1554-4c00-95ea-aafe9ef29d3d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "3830cb91-c9f2-4cb2-9ccd-6e008ec9f336");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cf9c2dba-f2a3-436b-9526-86b9b493bb6d", "AQAAAAEAACcQAAAAEBnFPkDrKCJUe9tuAzC7XJxLLAm03Fxd6e8ENKCnn87mfhBVxDrjd2GIR6qNbD05SQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "626c0014-5356-40fd-adb4-12eaa439de47", "AQAAAAEAACcQAAAAEGwaV728s25JQaxFDIERlkXURoqa80qdSNCqvSOeqf/7ucEkdbb4eKGTL57kjFdj8w==" });
        }
    }
}
