using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class AddedStateIdFieldToClusterLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClusterLocations_States_StateId",
                table: "ClusterLocations");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "ClusterLocations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_ClusterLocations_States_StateId",
                table: "ClusterLocations",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClusterLocations_States_StateId",
                table: "ClusterLocations");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "ClusterLocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "d50bc737-ccfb-45e3-9df0-7aebfd4c1b17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "19c64472-2ffe-49a9-a9ef-df94af8e8f08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "5654f631-c237-4c07-a573-8c82227e3303");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0eed5c9a-66b8-4a13-8545-7a6687a37653", "AQAAAAEAACcQAAAAEIYZigY3t9sGKVr8Xt+MJGkcrLanv7dG+eR6KH8A1g86klf7b4hfaDyrduNvL3/4pg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "57e1cce6-bdd8-480d-ad30-1fa2503d862d", "AQAAAAEAACcQAAAAEHPKty5GDkBA1rufybUUpWuZqFkOaU0S7C11Csfwz9VaraCX8N7TGRBfLGXmpvDV/w==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClusterLocations_States_StateId",
                table: "ClusterLocations",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
