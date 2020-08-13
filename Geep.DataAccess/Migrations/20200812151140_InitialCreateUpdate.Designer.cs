﻿// <auto-generated />
using System;
using Geep.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Geep.DataAccess.Migrations
{
    [DbContext(typeof(GeepDbContext))]
    [Migration("20200812151140_InitialCreateUpdate")]
    partial class InitialCreateUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Geep.DataAccess.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleAuthenticatorSecretKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGoogleAuthenticatorEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLogin")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLogOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("NumberOfLogins")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PrimaryMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "81511d05-0f2b-4a79-891a-22256cc6dfd5",
                            Email = "Admin@geepproject.com",
                            EmailConfirmed = true,
                            IsGoogleAuthenticatorEnabled = false,
                            IsLogin = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GEEPPROJECT.COM",
                            NormalizedUserName = "ADMIN@GEEPPROJECT.COM",
                            NumberOfLogins = 0,
                            PasswordHash = "AQAAAAEAACcQAAAAELqrOL8pgrUdd+UogswCTgcHkS351MYP+9A9bgw1RmNjJb7cIfZZushFEbCpXNwt/w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Admin@geepproject.com"
                        },
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a66b023-5aa4-4d82-a8a6-626d97f92112",
                            Email = "SuperAdmin@geepproject.com",
                            EmailConfirmed = true,
                            IsGoogleAuthenticatorEnabled = false,
                            IsLogin = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GEEPPROJECT.COM",
                            NormalizedUserName = "SUPERADMIN@GEEPPROJECT.COM",
                            NumberOfLogins = 0,
                            PasswordHash = "AQAAAAEAACcQAAAAEAvHWt22xIVFzpcGzTVs7TaQXkOTyH5EPY5T9PNdN/2tbUnp54pfihayNBRj/7F6Hg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "SuperAdmin@geepproject.com"
                        });
                });

            modelBuilder.Entity("Geep.Models.Core.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BVN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocalGovtRefId")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("Geep.Models.Core.AgentClusterLocation", b =>
                {
                    b.Property<int>("AgentClusterLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<int>("ClusterLocationId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentClusterLocationId");

                    b.HasIndex("AgentId");

                    b.HasIndex("ClusterLocationId");

                    b.ToTable("AgentClusterLocations");
                });

            modelBuilder.Entity("Geep.Models.Core.Association", b =>
                {
                    b.Property<int>("AssociationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccreditationStstud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssiciationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssociationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssociationRefId")
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocalGovernmentAreaId")
                        .HasColumnType("int");

                    b.Property<string>("SuperAgent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssociationId");

                    b.HasIndex("AssociationRefId")
                        .IsUnique()
                        .HasFilter("[AssociationRefId] IS NOT NULL");

                    b.HasIndex("LocalGovernmentAreaId");

                    b.ToTable("Associations");
                });

            modelBuilder.Entity("Geep.Models.Core.AssociationBeneficiary", b =>
                {
                    b.Property<int>("AssociationBeneficiaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssociationId")
                        .HasColumnType("int");

                    b.Property<int?>("BeneficiaryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssociationBeneficiaryId");

                    b.HasIndex("AssociationId");

                    b.HasIndex("BeneficiaryId");

                    b.ToTable("AssociationBeneficiaries");
                });

            modelBuilder.Entity("Geep.Models.Core.Beneficiary", b =>
                {
                    b.Property<int>("BeneficiaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<int?>("AssociationId")
                        .HasColumnType("int");

                    b.Property<string>("BVN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClusterLocationId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrendBankId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentProgramId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateEnumerated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Disability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacialPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeopoliticalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuarantoLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuarantorFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuarantorFirstPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextOfKinAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextOfKinName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextOfKinPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("int");

                    b.Property<string>("SmileIdZip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmileReference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TradeSubType")
                        .HasColumnType("int");

                    b.Property<int>("TreadeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BeneficiaryId");

                    b.HasIndex("AgentId");

                    b.HasIndex("AssociationId");

                    b.HasIndex("ClusterLocationId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.ToTable("Beneficiaries");
                });

            modelBuilder.Entity("Geep.Models.Core.ClusterLocation", b =>
                {
                    b.Property<int>("ClusterLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgentId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClusterLocationId");

                    b.HasIndex("AgentId");

                    b.HasIndex("ReferenceId")
                        .IsUnique();

                    b.HasIndex("StateId");

                    b.ToTable("ClusterLocations");
                });

            modelBuilder.Entity("Geep.Models.Core.LocalGovernmentArea", b =>
                {
                    b.Property<int>("LocalGovernmentAreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LgaName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocalGovernmentAreaId");

                    b.HasIndex("ReferenceId")
                        .IsUnique();

                    b.HasIndex("StateId");

                    b.ToTable("LocalGovernmentAreas");
                });

            modelBuilder.Entity("Geep.Models.Core.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.HasIndex("ReferenceId")
                        .IsUnique();

                    b.ToTable("States");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                            ConcurrencyStamp = "740a54aa-8462-4cd1-af13-bc7a2485f64c",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                            ConcurrencyStamp = "2ec5eb09-9d6b-485f-bc04-91d5d1ed1006",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = "a18be9c0-aak5-4af8-bd17-00bd934nfn13",
                            ConcurrencyStamp = "ad4255e4-7da5-460e-b1d5-aa504c566517",
                            Name = "QualityControl",
                            NormalizedName = "QUALITYCONTROL"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e513",
                            RoleId = "a18be9c0-aa65-4af8-bd17-00bd9344e513"
                        },
                        new
                        {
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e613",
                            RoleId = "a18be9c0-aa65-4af8-bd17-00bd9344e613"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Geep.Models.Core.AgentClusterLocation", b =>
                {
                    b.HasOne("Geep.Models.Core.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geep.Models.Core.ClusterLocation", "ClusterLocation")
                        .WithMany()
                        .HasForeignKey("ClusterLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Geep.Models.Core.Association", b =>
                {
                    b.HasOne("Geep.Models.Core.LocalGovernmentArea", "LocalGovernmentArea")
                        .WithMany()
                        .HasForeignKey("LocalGovernmentAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Geep.Models.Core.AssociationBeneficiary", b =>
                {
                    b.HasOne("Geep.Models.Core.Association", "Association")
                        .WithMany()
                        .HasForeignKey("AssociationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geep.Models.Core.Beneficiary", "Beneficiary")
                        .WithMany()
                        .HasForeignKey("BeneficiaryId");
                });

            modelBuilder.Entity("Geep.Models.Core.Beneficiary", b =>
                {
                    b.HasOne("Geep.Models.Core.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geep.Models.Core.Association", "Association")
                        .WithMany()
                        .HasForeignKey("AssociationId");

                    b.HasOne("Geep.Models.Core.ClusterLocation", "ClusterLocation")
                        .WithMany()
                        .HasForeignKey("ClusterLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Geep.Models.Core.ClusterLocation", b =>
                {
                    b.HasOne("Geep.Models.Core.Agent", null)
                        .WithMany("ClusterLocations")
                        .HasForeignKey("AgentId");

                    b.HasOne("Geep.Models.Core.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Geep.Models.Core.LocalGovernmentArea", b =>
                {
                    b.HasOne("Geep.Models.Core.State", "State")
                        .WithMany("LocalGovernmentAreas")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Geep.DataAccess.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Geep.DataAccess.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geep.DataAccess.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Geep.DataAccess.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}