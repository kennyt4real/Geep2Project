using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class ModifiedAssociationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TradeSubType",
                table: "Associations");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Beneficiaries",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApprovedByWhiteList",
                table: "Associations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUpdatedOnPortal",
                table: "Associations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PushedToWhiteList",
                table: "Associations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceKey",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "Associations",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "IsApprovedByWhiteList",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "IsUpdatedOnPortal",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "PushedToWhiteList",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "ReferenceKey",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "Associations");

            migrationBuilder.AddColumn<string>(
                name: "TradeSubType",
                table: "Associations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "95da62b1-43de-4cb6-a2cc-0db3616d2cff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "ef12eac3-ca40-4ce4-96b6-e1527f6c2eab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "777ac81d-d920-4f9e-a9a5-5fb55d3ecf4b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1af8dff-fab0-4fd4-b9a6-81295dcea4f5", "AQAAAAEAACcQAAAAEHCddShLleqigfRoeJRhgcvq1Rb5KQ2HyTKCRyTrivkZllAPfBCEBX/3+MU9YthnAQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce2aaa16-399a-46c8-9885-f6d0cfbb9a44", "AQAAAAEAACcQAAAAELBDOu5hSW0I8aZXtVM6wntwlCTtQQNWZ/H5dvbOqd2Oacu+FdYMa1vqvbWf4Ab1OQ==" });
        }
    }
}
