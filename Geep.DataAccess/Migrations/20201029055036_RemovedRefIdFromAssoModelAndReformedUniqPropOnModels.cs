using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class RemovedRefIdFromAssoModelAndReformedUniqPropOnModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Associations_AssociationRefId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "AssociationRefId",
                table: "Associations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "e2bb5eac-ccfa-4f76-b639-4969029b0cdc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "7f1da16f-730b-4c41-9e0c-7886efa84abb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "bd1cef9e-4459-41c3-8731-192d82675356");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dade2833-0770-4d36-89d4-d2a53f1f4de6", "AQAAAAEAACcQAAAAEFGj2SPFdVGnpHdJXhOuIHSWxgO7b3wwy0+dFrciKT8F4XVlHmW1sEpyYC1KPZY1+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "df491b8b-1910-4ebd-84a6-f16fac0528b4", "AQAAAAEAACcQAAAAEFB/Jf2w7I+5wDFM4WNiBC6C6RSjpg43qE9IW+KYigav7fL7B+GPOT77uYvSBtd4dw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Associations_ReferenceId",
                table: "Associations",
                column: "ReferenceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Associations_ReferenceId",
                table: "Associations");

            migrationBuilder.AddColumn<string>(
                name: "AssociationRefId",
                table: "Associations",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "edbc1727-4ce1-4f75-8af8-fa976caed61c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "645477ef-3f58-4b15-9c5a-2029fd6f8479");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "7fe45d70-33cc-4102-a63d-e9847a38e4b5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0550781-2d54-42fd-87ab-3ff59b40b331", "AQAAAAEAACcQAAAAELpyvp/dnjDCvAXao0ByjLjcwPN7wf1NGnlr1s+0i7eLQuZrRvAXX+ZP0RGnU2qv+Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f6b46d4a-7f0e-4542-8de0-59de400e64b2", "AQAAAAEAACcQAAAAEAgwuoK5VjM6Tl5rduoqjEBLpasYys1YCA8svt+nJ+hTS30Rn7M3DZB2hcB/zq/yng==" });

            migrationBuilder.CreateIndex(
                name: "IX_Associations_AssociationRefId",
                table: "Associations",
                column: "AssociationRefId",
                unique: true,
                filter: "[AssociationRefId] IS NOT NULL");
        }
    }
}
