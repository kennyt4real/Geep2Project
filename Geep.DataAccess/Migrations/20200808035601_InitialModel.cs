using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geep.DataAccess.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    ReferenceId = table.Column<string>(maxLength: 9, nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    AgentId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    BVN = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    LocalGovtRefId = table.Column<int>(nullable: false),
                    HomeAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.ReferenceId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsGoogleAuthenticatorEnabled = table.Column<bool>(nullable: false),
                    GoogleAuthenticatorSecretKey = table.Column<string>(nullable: true),
                    IsLogin = table.Column<bool>(nullable: false),
                    PrimaryMail = table.Column<string>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: true),
                    LastLogOut = table.Column<DateTime>(nullable: true),
                    NumberOfLogins = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ReferenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClusterLocations",
                columns: table => new
                {
                    ClusterLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ReferenceId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true),
                    AgentReferenceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClusterLocations", x => x.ClusterLocationId);
                    table.ForeignKey(
                        name: "FK_ClusterLocations_Agents_AgentReferenceId",
                        column: x => x.AgentReferenceId,
                        principalTable: "Agents",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClusterLocations_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocalGovernmentAreas",
                columns: table => new
                {
                    LocalGovernmentAreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ReferenceId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalGovernmentAreas", x => x.LocalGovernmentAreaId);
                    table.ForeignKey(
                        name: "FK_LocalGovernmentAreas_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgentClusterLocations",
                columns: table => new
                {
                    AgentClusterLocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    AgentId = table.Column<int>(nullable: false),
                    ClusterLocationId = table.Column<int>(nullable: false),
                    AgentReferenceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentClusterLocations", x => x.AgentClusterLocationId);
                    table.ForeignKey(
                        name: "FK_AgentClusterLocations_Agents_AgentReferenceId",
                        column: x => x.AgentReferenceId,
                        principalTable: "Agents",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgentClusterLocations_ClusterLocations_ClusterLocationId",
                        column: x => x.ClusterLocationId,
                        principalTable: "ClusterLocations",
                        principalColumn: "ClusterLocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    AssociationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    AssociationRefId = table.Column<string>(maxLength: 12, nullable: true),
                    AssociationName = table.Column<string>(nullable: true),
                    AssiciationType = table.Column<string>(nullable: true),
                    LocalGovtId = table.Column<int>(nullable: false),
                    SuperAgent = table.Column<string>(nullable: true),
                    AccreditationStstud = table.Column<string>(nullable: true),
                    GroupPhoneNumber = table.Column<string>(nullable: true),
                    GroupEmail = table.Column<string>(nullable: true),
                    LocalGovernmentAreaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.AssociationId);
                    table.ForeignKey(
                        name: "FK_Associations_LocalGovernmentAreas_LocalGovernmentAreaId",
                        column: x => x.LocalGovernmentAreaId,
                        principalTable: "LocalGovernmentAreas",
                        principalColumn: "LocalGovernmentAreaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    BeneficiaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    ReferenceId = table.Column<int>(nullable: false),
                    ClusterLocationId = table.Column<int>(nullable: false),
                    TreadeTypeId = table.Column<int>(nullable: false),
                    TradeSubType = table.Column<int>(nullable: false),
                    AgentId = table.Column<int>(nullable: false),
                    CurrentProgramId = table.Column<int>(nullable: false),
                    AssociationId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: true),
                    BVN = table.Column<string>(nullable: true),
                    HomeAddress = table.Column<string>(nullable: true),
                    CurrendBankId = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    GPS = table.Column<string>(nullable: true),
                    FacialPicture = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    SmileIdZip = table.Column<string>(nullable: true),
                    Disability = table.Column<string>(nullable: true),
                    SmileReference = table.Column<string>(nullable: true),
                    DateEnumerated = table.Column<string>(nullable: true),
                    NextOfKinAddress = table.Column<string>(nullable: true),
                    NextOfKinPhone = table.Column<string>(nullable: true),
                    GuarantorFirstName = table.Column<string>(nullable: true),
                    GuarantoLastName = table.Column<string>(nullable: true),
                    GuarantorFirstPhone = table.Column<string>(nullable: true),
                    IdCardNumber = table.Column<string>(nullable: true),
                    NextOfKinName = table.Column<string>(nullable: true),
                    GeopoliticalId = table.Column<string>(nullable: true),
                    AgentReferenceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.BeneficiaryId);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Agents_AgentReferenceId",
                        column: x => x.AgentReferenceId,
                        principalTable: "Agents",
                        principalColumn: "ReferenceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Associations_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Associations",
                        principalColumn: "AssociationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_ClusterLocations_ClusterLocationId",
                        column: x => x.ClusterLocationId,
                        principalTable: "ClusterLocations",
                        principalColumn: "ClusterLocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssociationBeneficiaries",
                columns: table => new
                {
                    AssociationBeneficiaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    AssociationId = table.Column<int>(nullable: false),
                    BeneficiaryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationBeneficiaries", x => x.AssociationBeneficiaryId);
                    table.ForeignKey(
                        name: "FK_AssociationBeneficiaries_Associations_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Associations",
                        principalColumn: "AssociationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociationBeneficiaries_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "BeneficiaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e513", "d50bc737-ccfb-45e3-9df0-7aebfd4c1b17", "Admin", "Admin" },
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e613", "19c64472-2ffe-49a9-a9ef-df94af8e8f08", "SuperAdmin", "SUPERADMIN" },
                    { "a18be9c0-aak5-4af8-bd17-00bd934nfn13", "5654f631-c237-4c07-a573-8c82227e3303", "QualityControl", "QUALITYCONTROL" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "GoogleAuthenticatorSecretKey", "IsGoogleAuthenticatorEnabled", "IsLogin", "LastLogOut", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "NumberOfLogins", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PrimaryMail", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e513", 0, "0eed5c9a-66b8-4a13-8545-7a6687a37653", "Admin@geepproject.com", true, null, null, false, false, null, null, null, false, null, "ADMIN@GEEPPROJECT.COM", "ADMIN@GEEPPROJECT.COM", 0, "AQAAAAEAACcQAAAAEIYZigY3t9sGKVr8Xt+MJGkcrLanv7dG+eR6KH8A1g86klf7b4hfaDyrduNvL3/4pg==", null, false, null, "", false, "Admin@geepproject.com" },
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e613", 0, "57e1cce6-bdd8-480d-ad30-1fa2503d862d", "SuperAdmin@geepproject.com", true, null, null, false, false, null, null, null, false, null, "SUPERADMIN@GEEPPROJECT.COM", "SUPERADMIN@GEEPPROJECT.COM", 0, "AQAAAAEAACcQAAAAEHPKty5GDkBA1rufybUUpWuZqFkOaU0S7C11Csfwz9VaraCX8N7TGRBfLGXmpvDV/w==", null, false, null, "", false, "SuperAdmin@geepproject.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e513", "a18be9c0-aa65-4af8-bd17-00bd9344e513" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e613", "a18be9c0-aa65-4af8-bd17-00bd9344e613" });

            migrationBuilder.CreateIndex(
                name: "IX_AgentClusterLocations_AgentReferenceId",
                table: "AgentClusterLocations",
                column: "AgentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentClusterLocations_ClusterLocationId",
                table: "AgentClusterLocations",
                column: "ClusterLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationBeneficiaries_AssociationId",
                table: "AssociationBeneficiaries",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationBeneficiaries_BeneficiaryId",
                table: "AssociationBeneficiaries",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_AssociationRefId",
                table: "Associations",
                column: "AssociationRefId",
                unique: true,
                filter: "[AssociationRefId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_LocalGovernmentAreaId",
                table: "Associations",
                column: "LocalGovernmentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_AgentReferenceId",
                table: "Beneficiaries",
                column: "AgentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_AssociationId",
                table: "Beneficiaries",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_ClusterLocationId",
                table: "Beneficiaries",
                column: "ClusterLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PhoneNumber",
                table: "Beneficiaries",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterLocations_AgentReferenceId",
                table: "ClusterLocations",
                column: "AgentReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClusterLocations_ReferenceId",
                table: "ClusterLocations",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClusterLocations_StateId",
                table: "ClusterLocations",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalGovernmentAreas_ReferenceId",
                table: "LocalGovernmentAreas",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalGovernmentAreas_StateId",
                table: "LocalGovernmentAreas",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_ReferenceId",
                table: "States",
                column: "ReferenceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentClusterLocations");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssociationBeneficiaries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "Associations");

            migrationBuilder.DropTable(
                name: "ClusterLocations");

            migrationBuilder.DropTable(
                name: "LocalGovernmentAreas");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
