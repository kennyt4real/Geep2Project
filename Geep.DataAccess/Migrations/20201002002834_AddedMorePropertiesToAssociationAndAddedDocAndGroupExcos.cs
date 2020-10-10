using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class AddedMorePropertiesToAssociationAndAddedDocAndGroupExcos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccreditationStstud",
                table: "Associations");

            migrationBuilder.AddColumn<string>(
                name: "AccreditationStatus",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryCount",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CACDoc",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Channel",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Associations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentId1",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnumeratorId",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeaderName",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeaderPhoneNumber",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MOUStatus",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MembersCount",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TradeSubType",
                table: "Associations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TradeType",
                table: "Associations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssociationId = table.Column<int>(nullable: false),
                    FileType = table.Column<string>(nullable: true),
                    File = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "GroupExcos",
                columns: table => new
                {
                    GroupExcoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    BVN = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    LocalGovernmentAreaId = table.Column<int>(nullable: true),
                    AssociationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupExcos", x => x.GroupExcoId);
                    table.ForeignKey(
                        name: "FK_GroupExcos_Associations_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Associations",
                        principalColumn: "AssociationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupExcos_LocalGovernmentAreas_LocalGovernmentAreaId",
                        column: x => x.LocalGovernmentAreaId,
                        principalTable: "LocalGovernmentAreas",
                        principalColumn: "LocalGovernmentAreaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "8517bc57-51db-461a-8110-c0f62e01fc7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "461c918c-cbff-4c8e-8787-08d7a57c531f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "11743a37-7177-459b-b7fa-5fa51f1b8194");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b2871e30-95a7-4ff2-8ab0-7b0b7603de7c", "AQAAAAEAACcQAAAAEL+iuWwdvaaOBT/8kqRi8i7kGfjZk9X3lYwgpBFmcGsvO8ALw4V4Ayvq4kXg0y9s2w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "031f90a7-c59c-4fcb-9aa7-5c98085ad134", "AQAAAAEAACcQAAAAEA0xeI4p40IB2Vgapla+Awwragcq9cz3ZhpII7fQ1IrqEXYVUQLPu1iJJGcED7cGDw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Associations_DocumentId1",
                table: "Associations",
                column: "DocumentId1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupExcos_AssociationId",
                table: "GroupExcos",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupExcos_LocalGovernmentAreaId",
                table: "GroupExcos",
                column: "LocalGovernmentAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Documents_DocumentId1",
                table: "Associations",
                column: "DocumentId1",
                principalTable: "Documents",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Documents_DocumentId1",
                table: "Associations");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "GroupExcos");

            migrationBuilder.DropIndex(
                name: "IX_Associations_DocumentId1",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "AccreditationStatus",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "BeneficiaryCount",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "CACDoc",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "Channel",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "DocumentId1",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "EnumeratorId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "LeaderName",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "LeaderPhoneNumber",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "MOUStatus",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "MembersCount",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "TradeSubType",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "TradeType",
                table: "Associations");

            migrationBuilder.AddColumn<string>(
                name: "AccreditationStstud",
                table: "Associations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                column: "ConcurrencyStamp",
                value: "4aa72256-9f8e-442e-83a6-c44612466d7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                column: "ConcurrencyStamp",
                value: "7cfd1cc0-af67-4568-a838-b2a544b7eb2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                column: "ConcurrencyStamp",
                value: "59e91b3a-62cf-4514-a4f3-3235c7c68ef0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "872157eb-3f56-4c3f-8753-63edd09dac49", "AQAAAAEAACcQAAAAEBMICRQ9zDoEZ1Mf7Vfvd7qGNwQbd/W6hpNRo/B8NpjK4BYvS2rwK9LZ7zG67Afftg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e347e3c9-8104-4c9e-88ce-81c360db083e", "AQAAAAEAACcQAAAAEGtCq322BgiBSAPDh50MmwE7lw+zVFmFv3waXeOk07pG8Wg7oyyoqjDPSqdgdItNQA==" });
        }
    }
}
