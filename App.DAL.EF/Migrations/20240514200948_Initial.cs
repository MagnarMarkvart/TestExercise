using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.DAL.EF.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AgreesToTerms = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SuperSectorId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sectors_Sectors_SuperSectorId",
                        column: x => x.SuperSectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefreshToken = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    ExpirationDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PreviousRefreshToken = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    PreviousExpirationDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInSectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SectorWithSuperSectorsName = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SectorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInSectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInSectors_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInSectors_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Description", "SuperSectorId" },
                values: new object[,]
                {
                    { new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6"), "Manufacturing", null },
                    { new Guid("a0b37c00-72bd-4522-a5d5-f0902a66d6a8"), "Service", null },
                    { new Guid("acee74c3-cdd4-4c18-93c8-2a485d61d52e"), "Other", null },
                    { new Guid("046157a9-a497-420c-b8f1-1234b4bea756"), "Food and Beverage", new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6") },
                    { new Guid("0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9"), "Wood", new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6") },
                    { new Guid("0d1709d0-3df8-4462-8770-1da6694a1bc9"), "Construction Materials", new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6") },
                    { new Guid("11c4d645-baeb-4033-a965-4d39915aea87"), "Plastic and Rubber", new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6") },
                    { new Guid("170355ac-0996-42cf-a1e5-d3992c187186"), "Metalworking", new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6") },
                    { new Guid("28caca3c-a99b-4bb9-b19b-11d6e3b07b70"), "Transport and Logistics", new Guid("a0b37c00-72bd-4522-a5d5-f0902a66d6a8") },
                    { new Guid("3b5a581a-399b-43e5-9cd3-113b9f394c06"), "Energy technology", new Guid("acee74c3-cdd4-4c18-93c8-2a485d61d52e") },
                    { new Guid("3d78fecc-e4bc-4110-a82c-d6309a818613"), "Electronics and Optics", new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6") },
                    { new Guid("3ee0c8fc-e5e9-412c-b83a-67de4101153e"), "Tourism", new Guid("a0b37c00-72bd-4522-a5d5-f0902a66d6a8") },
                    { new Guid("4783bc42-20f7-4218-a346-cb067668cdf5"), "Printing", new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6") },
                    { new Guid("4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3"), "Information Technology and Telecommunications", new Guid("a0b37c00-72bd-4522-a5d5-f0902a66d6a8") },
                    { new Guid("4ec419ae-9eeb-49d4-9b6d-383e561e95d0"), "Business services", new Guid("a0b37c00-72bd-4522-a5d5-f0902a66d6a8") },
                    { new Guid("564886b1-1c65-48fb-99da-bbd047e43e77"), "Translation services", new Guid("a0b37c00-72bd-4522-a5d5-f0902a66d6a8") },
                    { new Guid("646b7716-9852-45db-ad7c-da6e6772b3bb"), "Textile and Clothing", new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6") },
                    { new Guid("817dc386-beaf-4b3b-9bb2-4b98c6a32649"), "Environment", new Guid("acee74c3-cdd4-4c18-93c8-2a485d61d52e") },
                    { new Guid("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c"), "Furniture", new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6") },
                    { new Guid("99b24a88-e6f5-43ff-9e23-b5c0e54fc49a"), "Creative industries", new Guid("acee74c3-cdd4-4c18-93c8-2a485d61d52e") },
                    { new Guid("b6ff692e-c9f8-40b8-8cf6-85ae6991b387"), "Engineering", new Guid("a0b37c00-72bd-4522-a5d5-f0902a66d6a8") },
                    { new Guid("eae7965e-5ace-44d0-9b94-af116aa356eb"), "Machinery", new Guid("32fc0433-e12f-4017-9b23-927c910fb1f6") },
                    { new Guid("01f0db6b-5b72-49d9-97c7-101a25e8be27"), "Telecommunications", new Guid("4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3") },
                    { new Guid("08f64162-a545-4c92-a886-ec7df6713cb8"), "Machinery components", new Guid("eae7965e-5ace-44d0-9b94-af116aa356eb") },
                    { new Guid("08f9c602-4a72-4b9a-9123-d05dca9570c6"), "Maritime", new Guid("eae7965e-5ace-44d0-9b94-af116aa356eb") },
                    { new Guid("0c447d9b-3608-4494-86f4-496d74c95815"), "Rail", new Guid("28caca3c-a99b-4bb9-b19b-11d6e3b07b70") },
                    { new Guid("1246ce33-8daf-4a43-ba2f-267c8edbb743"), "Bedroom", new Guid("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c") },
                    { new Guid("13c56f1c-ccf7-40aa-9c22-67abfbf97b13"), "Meat &amp; meat products", new Guid("046157a9-a497-420c-b8f1-1234b4bea756") },
                    { new Guid("19b854ef-dd95-4bca-adef-b8da58d537ed"), "Plastic profiles", new Guid("11c4d645-baeb-4033-a965-4d39915aea87") },
                    { new Guid("19f2d59d-c083-40e1-a09c-6ac38fc42145"), "Labelling and packaging printing", new Guid("4783bc42-20f7-4218-a346-cb067668cdf5") },
                    { new Guid("1b4dcf27-e168-4ead-9e9c-17f71e8b33e9"), "Clothing", new Guid("646b7716-9852-45db-ad7c-da6e6772b3bb") },
                    { new Guid("1b5b36a4-214a-482c-b9f1-01f6c6152979"), "Metal works", new Guid("170355ac-0996-42cf-a1e5-d3992c187186") },
                    { new Guid("1dc14ced-651b-4944-a786-a52424e15a0d"), "Other", new Guid("eae7965e-5ace-44d0-9b94-af116aa356eb") },
                    { new Guid("2ded67d1-457c-4bd8-8ce8-0080511144c4"), "Wooden building materials", new Guid("0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9") },
                    { new Guid("3075fb1c-339f-4666-943c-c4d5f10812fb"), "Construction of metal structures", new Guid("170355ac-0996-42cf-a1e5-d3992c187186") },
                    { new Guid("33a143c7-ca06-42b1-a4b9-75bfab987860"), "Houses and buildings", new Guid("170355ac-0996-42cf-a1e5-d3992c187186") },
                    { new Guid("37093024-3be1-4be2-8c54-9f921922d90e"), "Data processing, Web portals, E-marketing", new Guid("4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3") },
                    { new Guid("371a408f-7812-435f-b80a-d3ffb7e301a9"), "Metal structures", new Guid("eae7965e-5ace-44d0-9b94-af116aa356eb") },
                    { new Guid("372b1d41-619b-4a6e-9d04-f76be8cee6e3"), "Programming, Consultancy", new Guid("4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3") },
                    { new Guid("408cacab-4d25-4b48-b2dc-971293f78821"), "Project furniture", new Guid("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c") },
                    { new Guid("4485157b-40c4-405d-8d98-a5367b98f74d"), "Wooden houses", new Guid("0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9") },
                    { new Guid("4b12e7cc-f507-475a-b198-45646f2dc4d2"), "Bakery &amp; confectionery products", new Guid("046157a9-a497-420c-b8f1-1234b4bea756") },
                    { new Guid("5116d5b8-dd3c-4b6f-baf6-b8a53a3d30f3"), "Water", new Guid("28caca3c-a99b-4bb9-b19b-11d6e3b07b70") },
                    { new Guid("589bf163-9180-43f0-9cf8-165c5cb2149d"), "Software, Hardware", new Guid("4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3") },
                    { new Guid("5da3c473-79b4-4bb5-adca-7fa96bd0ab53"), "Bathroom/sauna", new Guid("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c") },
                    { new Guid("77f6ce62-8a5e-44f6-a623-354393d71ea9"), "Kitchen", new Guid("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c") },
                    { new Guid("84fb9773-cf97-4242-97a4-b8bc4244aa02"), "Textile", new Guid("646b7716-9852-45db-ad7c-da6e6772b3bb") },
                    { new Guid("853c0ac3-2dda-4081-9c49-f9125d975889"), "Other", new Guid("046157a9-a497-420c-b8f1-1234b4bea756") },
                    { new Guid("86a44339-0353-4950-8666-f56795cd2fbe"), "Fish &amp; fish products", new Guid("046157a9-a497-420c-b8f1-1234b4bea756") },
                    { new Guid("880b1b11-7a44-4636-87f5-f60b4ca720da"), "Outdoor", new Guid("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c") },
                    { new Guid("9f5941a1-a4ef-4e31-9114-b6333e6e8d44"), "Plastic goods", new Guid("11c4d645-baeb-4033-a965-4d39915aea87") },
                    { new Guid("a158fdbc-2148-4d6f-856d-7479dd9f31fb"), "Packaging", new Guid("11c4d645-baeb-4033-a965-4d39915aea87") },
                    { new Guid("a868e04a-6d35-4eb3-8f81-539dfa5aedd8"), "Beverages", new Guid("046157a9-a497-420c-b8f1-1234b4bea756") },
                    { new Guid("a8e94d75-f5e9-41b1-96f1-eb56551067c3"), "Office", new Guid("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c") },
                    { new Guid("a9b73b0c-0ea3-4792-8522-a741463888b6"), "Milk &amp; dairy products", new Guid("046157a9-a497-420c-b8f1-1234b4bea756") },
                    { new Guid("ae70e815-feba-43fc-a63c-ca8770c8cf34"), "Sweets &amp; snack food", new Guid("046157a9-a497-420c-b8f1-1234b4bea756") },
                    { new Guid("c662db43-fe38-47a9-99d5-80f02f2c6eef"), "Other", new Guid("0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9") },
                    { new Guid("c6c2030d-27af-478b-aeb3-2d87ec872f81"), "Book/Periodicals printing", new Guid("4783bc42-20f7-4218-a346-cb067668cdf5") },
                    { new Guid("d279196b-fb78-4f6b-927a-f10e32714fc0"), "Advertising", new Guid("4783bc42-20f7-4218-a346-cb067668cdf5") },
                    { new Guid("d54417b1-dec1-4405-b14a-c1d350e1c750"), "Air", new Guid("28caca3c-a99b-4bb9-b19b-11d6e3b07b70") },
                    { new Guid("e3a9da1a-9925-4022-ae32-af03f2f217ad"), "Plastic processing technology", new Guid("11c4d645-baeb-4033-a965-4d39915aea87") },
                    { new Guid("e74d5e79-ea61-45c3-a35e-069fc262afa6"), "Repair and maintenance service", new Guid("eae7965e-5ace-44d0-9b94-af116aa356eb") },
                    { new Guid("e8d4e310-7b24-41f6-816c-37ce78c727c3"), "Living room", new Guid("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c") },
                    { new Guid("ee504569-4666-4cd9-85a0-a2c9cd0d4e83"), "Metal products", new Guid("170355ac-0996-42cf-a1e5-d3992c187186") },
                    { new Guid("ee9c0b26-1e9c-4127-8e73-204eb68527c3"), "Children’s room", new Guid("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c") },
                    { new Guid("ef179370-a0ba-413f-b810-d68f0a793446"), "Other (Furniture)", new Guid("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c") },
                    { new Guid("f7692977-8c0f-49e2-bf12-0e5cc00c555f"), "Road", new Guid("28caca3c-a99b-4bb9-b19b-11d6e3b07b70") },
                    { new Guid("f80ad83c-fc72-4073-bb2e-87facabbbfec"), "Machinery equipment/tools", new Guid("eae7965e-5ace-44d0-9b94-af116aa356eb") },
                    { new Guid("f9349e44-58aa-4976-b0d3-13d342a56733"), "Manufacture of machinery", new Guid("eae7965e-5ace-44d0-9b94-af116aa356eb") },
                    { new Guid("29692620-cc6b-407c-a27d-ba918c598621"), "Blowing", new Guid("e3a9da1a-9925-4022-ae32-af03f2f217ad") },
                    { new Guid("31956b83-31e5-47a8-aa27-1817c7ff57ab"), "Boat/Yacht building", new Guid("08f9c602-4a72-4b9a-9123-d05dca9570c6") },
                    { new Guid("4beb5253-ce43-41cc-ba03-8cbd59ae6b16"), "Ship repair and conversion", new Guid("08f9c602-4a72-4b9a-9123-d05dca9570c6") },
                    { new Guid("4fc45347-e65b-44ca-b63b-90a5d29737ab"), "CNC-machining", new Guid("1b5b36a4-214a-482c-b9f1-01f6c6152979") },
                    { new Guid("5b25ef14-4b9d-4706-8ed1-cc7d115984ed"), "Gas, Plasma, Laser cutting", new Guid("1b5b36a4-214a-482c-b9f1-01f6c6152979") },
                    { new Guid("708a8638-35c2-4b7f-80dc-cfeefeb90d08"), "Forgings, Fasteners", new Guid("1b5b36a4-214a-482c-b9f1-01f6c6152979") },
                    { new Guid("9732f4cb-8fb4-4e9d-9b5c-8fdb42090ea5"), "Aluminium and steel workboats", new Guid("08f9c602-4a72-4b9a-9123-d05dca9570c6") },
                    { new Guid("a98d02ea-beaa-41f6-a01c-d48d27a94b2c"), "MIG, TIG, Aluminum welding", new Guid("1b5b36a4-214a-482c-b9f1-01f6c6152979") },
                    { new Guid("e9c07801-4440-4a8b-9de7-9d3010b0d6d3"), "Moulding", new Guid("e3a9da1a-9925-4022-ae32-af03f2f217ad") },
                    { new Guid("fdb9e91a-9120-439f-a6a1-ff9356949420"), "Plastics welding and processing", new Guid("e3a9da1a-9925-4022-ae32-af03f2f217ad") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_AppUserId",
                table: "RefreshTokens",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_SuperSectorId",
                table: "Sectors",
                column: "SuperSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInSectors_AppUserId",
                table: "UserInSectors",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInSectors_SectorId",
                table: "UserInSectors",
                column: "SectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserInSectors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}
