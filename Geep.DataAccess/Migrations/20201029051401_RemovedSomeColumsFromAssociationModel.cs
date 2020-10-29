using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class RemovedSomeColumsFromAssociationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Documents_DocumentId1",
                table: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_Associations_DocumentId1",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "CACDoc",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "DocumentId1",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "GroupEmail",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "GroupPhoneNumber",
                table: "Associations");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "Associations",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Documents_AssociationId",
                table: "Documents",
                column: "AssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Associations_AssociationId",
                table: "Documents",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "AssociationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Associations_AssociationId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AssociationId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Associations");

            migrationBuilder.AddColumn<string>(
                name: "CACDoc",
                table: "Associations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Associations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentId1",
                table: "Associations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupEmail",
                table: "Associations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupPhoneNumber",
                table: "Associations",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Associations_DocumentId1",
                table: "Associations",
                column: "DocumentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Documents_DocumentId1",
                table: "Associations",
                column: "DocumentId1",
                principalTable: "Documents",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
