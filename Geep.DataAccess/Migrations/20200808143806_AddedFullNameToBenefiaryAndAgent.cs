using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class AddedFullNameToBenefiaryAndAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "a1f608e2-1bca-4f43-9468-5d32516b737d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "7032c745-b567-435a-9ea1-b62d630ee76e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "a5ef3495-c936-41be-bf14-a337fb92a82a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e32275d3-5024-4281-887a-cd3a26bd971c", "AQAAAAEAACcQAAAAECZb4d891SJuWCtajGaV2cPWKvwtZ5TdKohychS440nozaqBdS9TsehKY53iVNttaw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81583c71-a5d8-430e-85e7-83874ea5b68c", "AQAAAAEAACcQAAAAENnr0Zc2Ddy6OAshlfRNBG96gSezvhz4ekrHzBWiAiDTX3nOI6wH147UvFCyrW4KBQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "a0ec78a3-03c3-40b9-bdc6-d67306d8c613");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "98ad6213-861a-4b5c-bca7-11228a873a9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "c1f4b50c-9118-4254-8524-783d8c890221");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e4400ab-9f23-4d4d-bedf-f7fc0f7ca968", "AQAAAAEAACcQAAAAEFt1hSlJ0lrlau66DKNnhikelFrL/x5qgdGc0kTHmG0ciI/fjPhYBwClcTPpfcZ4IQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "602c416c-ee4d-47cc-9d27-12d149824496", "AQAAAAEAACcQAAAAEG4i5X2cN8hQmosZXEno7yhrSgUYPOaqVX6GdcjQL95/SQonCnk3IoboOcdPAotwUw==" });
        }
    }
}
