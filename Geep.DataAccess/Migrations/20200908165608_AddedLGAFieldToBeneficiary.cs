using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class AddedLGAFieldToBeneficiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LGAId",
                table: "Beneficiaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "9278c3bb-a408-429c-8b10-1a6dd2631a91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "8006763b-7eab-41bb-a23e-15a469197655");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "927b40e5-0518-4da8-96dc-08bda142529c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ab35c79b-b69d-4e9d-b36f-d0995ff3b48b", "AQAAAAEAACcQAAAAEEb3Aj4ekFJn/ULZkuHdzEZyKY/B2eAGZ1m0joz7lAEHu99B6OhGwFt6xZQkf/N4IA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "906a5422-48be-4609-90ed-6ec59ff2aaa6", "AQAAAAEAACcQAAAAELgH6YkGlfy63Ql2CNYHFpNZxdiglMXshJpYEz5uY7+YHgZjqx2sGJcdQxjlt1mNFw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LGAId",
                table: "Beneficiaries");

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
    }
}
