using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class AddedStateIdFieldToLga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalGovernmentAreas_States_StateId",
                table: "LocalGovernmentAreas");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "States");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LocalGovernmentAreas");

            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "States",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "LocalGovernmentAreas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LgaName",
                table: "LocalGovernmentAreas",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGovernmentAreas_States_StateId",
                table: "LocalGovernmentAreas",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalGovernmentAreas_States_StateId",
                table: "LocalGovernmentAreas");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "States");

            migrationBuilder.DropColumn(
                name: "LgaName",
                table: "LocalGovernmentAreas");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "States",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "LocalGovernmentAreas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LocalGovernmentAreas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "8ac10d15-12bf-4b55-86ae-0abfb7f09b95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "2c2c389d-3ebb-46f4-b8e1-6affdc705661");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "6ea6f37a-a7e4-490e-ab02-fa45e67c72e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6a34159-e9a3-41e8-8fc6-aeb77f199af8", "AQAAAAEAACcQAAAAEErutLjpVy+OXIn+H13qwD/xMuQEWLTxijQn40oabgj+Ihg21gLtMQd+69QDRv4BXQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e973715-92fd-4179-a0b3-2c6cea2a7e0f", "AQAAAAEAACcQAAAAELKuXhfDeOvFP7F+ZkuWtovQY3ak/DfZAil9JCPDLfrmsL1rkxE4GKCjhu5xPBvQ3g==" });

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGovernmentAreas_States_StateId",
                table: "LocalGovernmentAreas",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
