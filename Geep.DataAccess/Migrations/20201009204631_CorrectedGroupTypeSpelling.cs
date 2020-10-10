using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class CorrectedGroupTypeSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssiciationType",
                table: "Associations");

            migrationBuilder.AddColumn<string>(
                name: "AssociationType",
                table: "Associations",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssociationType",
                table: "Associations");

            migrationBuilder.AddColumn<string>(
                name: "AssiciationType",
                table: "Associations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "dd9d166d-072a-477c-8a74-004c5a035f67");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "d78c005f-b026-4ca7-81a3-99d04bbd4059");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "905aaecd-5482-400b-b6cd-9938fb992dbf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa4edd86-f66b-47c4-be03-1ed29a82e8ea", "AQAAAAEAACcQAAAAEBmqQeMZixF5OoXMLKJBbAGvSpTuf+8FfFOkytrxzClQUecrmXVe72Sr+Ovh1jipkQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c53ba508-25d5-459b-9a50-cb364cc0bca4", "AQAAAAEAACcQAAAAEO9egC/aKvrOfsH0HixXGxN72OKLOttNnk+Ft+4U3XJAohXaYqJAtEmw+cUZsvl3Gw==" });
        }
    }
}
