using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class AddedUniqueToAgentRefId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReferenceId",
                table: "Agents",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ReferenceId",
                table: "Agents",
                column: "ReferenceId",
                unique: true,
                filter: "[ReferenceId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_ReferenceId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceId",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "740a54aa-8462-4cd1-af13-bc7a2485f64c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "2ec5eb09-9d6b-485f-bc04-91d5d1ed1006");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "ad4255e4-7da5-460e-b1d5-aa504c566517");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81511d05-0f2b-4a79-891a-22256cc6dfd5", "AQAAAAEAACcQAAAAELqrOL8pgrUdd+UogswCTgcHkS351MYP+9A9bgw1RmNjJb7cIfZZushFEbCpXNwt/w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a66b023-5aa4-4d82-a8a6-626d97f92112", "AQAAAAEAACcQAAAAEAvHWt22xIVFzpcGzTVs7TaQXkOTyH5EPY5T9PNdN/2tbUnp54pfihayNBRj/7F6Hg==" });
        }
    }
}
