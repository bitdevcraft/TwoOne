using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TwoOne.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.EnsureSchema(
                name: "admin");

            migrationBuilder.CreateTable(
                name: "PermissionActions",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "app",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "ObjectFieldMetadata",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsPrimaryKey = table.Column<bool>(type: "boolean", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    IsCollection = table.Column<bool>(type: "boolean", nullable: false),
                    IsLookup = table.Column<bool>(type: "boolean", nullable: false),
                    RelatedObject = table.Column<string>(type: "text", nullable: true),
                    ObjectMetadataId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedById = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedById = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectFieldMetadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectMetadata",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedById = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedById = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectMetadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: true),
                    ActionId = table.Column<string>(type: "text", nullable: true),
                    ObjectMetadataId = table.Column<string>(type: "text", nullable: true),
                    ObjectFieldMetadataId = table.Column<string>(type: "text", nullable: true),
                    CanCreate = table.Column<bool>(type: "boolean", nullable: false),
                    CanRead = table.Column<bool>(type: "boolean", nullable: false),
                    CanEdit = table.Column<bool>(type: "boolean", nullable: false),
                    CanDelete = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedById = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedById = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_ObjectFieldMetadata_ObjectFieldMetadataId",
                        column: x => x.ObjectFieldMetadataId,
                        principalSchema: "app",
                        principalTable: "ObjectFieldMetadata",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permissions_ObjectMetadata_ObjectMetadataId",
                        column: x => x.ObjectMetadataId,
                        principalSchema: "app",
                        principalTable: "ObjectMetadata",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionActions_ActionId",
                        column: x => x.ActionId,
                        principalSchema: "admin",
                        principalTable: "PermissionActions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedById = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedById = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedById = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedById = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "admin",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "admin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "admin",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "admin",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedById", "DeletedAt", "DeletedById", "IsDeleted", "Name", "NormalizedName", "UpdatedAt", "UpdatedById" },
                values: new object[,]
                {
                    { "530b21d4-4dd9-4749-9444-ee1384d37d38", "f3890335-b369-4abf-ad43-558069e8574f", null, null, null, null, false, "Administrator", "ADMINISTRATOR", null, null },
                    { "7db8bdb6-8ffe-4f73-903f-fe0424d52e10", "1447aab3-643f-44ab-b41b-39b3c9e75737", null, null, null, null, false, "SystemAdministrator", "SYSTEMADMINISTRATOR", null, null },
                    { "c79c336b-5210-411e-b8c5-f6f210d06204", "6c70601c-3d19-4613-88e1-346306c8c0b6", null, null, null, null, false, "User", "USER", null, null }
                });

            migrationBuilder.InsertData(
                schema: "admin",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "CreatedById", "DeletedAt", "DeletedById", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "Mobile", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UpdatedById", "UserName" },
                values: new object[,]
                {
                    { "52f9a82a-e4b6-4f67-ae91-2e173aa21a1a", 0, "43a826bd-586d-4845-8f5f-f6fbf4ea5421", null, null, null, null, "admin@localhost.com", false, null, false, "Admin", false, null, null, null, "ADMIN@LOCALHOST.COM", "DEMOADMIN", null, null, null, false, "530b21d4-4dd9-4749-9444-ee1384d37d38", "70e52111-c5a3-492b-86f4-1e2c56a00999", false, null, null, "DemoAdmin" },
                    { "a901fdf4-edcb-4b6d-9a65-40df5b062f24", 0, "a3d86acc-2841-44f4-b561-2cdb9a069dcf", null, null, null, null, "user@localhost.com", false, null, false, "User", false, null, null, null, "USER@LOCALHOST.COM", "DEMOUSER", null, null, null, false, "c79c336b-5210-411e-b8c5-f6f210d06204", "593ce062-4d32-4e9b-973d-65610dc291e0", false, null, null, "DemoUser" },
                    { "e63a9b1c-2f89-406e-a5dc-d6ebe5cdf05a", 0, "cba53403-fee7-49ce-9ebf-70118a02e3db", null, null, null, null, "sysadmin@localhost.com", false, null, false, "System Admin", false, null, null, null, "SYSADMIN@LOCALHOST.COM", "SYSADMIN", null, null, null, false, "7db8bdb6-8ffe-4f73-903f-fe0424d52e10", "212f76c3-f3d3-44a1-a8b3-08b1f39001ff", false, null, null, "SysAdmin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "app",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectFieldMetadata_CreatedById",
                schema: "app",
                table: "ObjectFieldMetadata",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectFieldMetadata_DeletedById",
                schema: "app",
                table: "ObjectFieldMetadata",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectFieldMetadata_ObjectMetadataId",
                schema: "app",
                table: "ObjectFieldMetadata",
                column: "ObjectMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectFieldMetadata_UpdatedById",
                schema: "app",
                table: "ObjectFieldMetadata",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectMetadata_CreatedById",
                schema: "app",
                table: "ObjectMetadata",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectMetadata_DeletedById",
                schema: "app",
                table: "ObjectMetadata",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectMetadata_UpdatedById",
                schema: "app",
                table: "ObjectMetadata",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ActionId",
                schema: "admin",
                table: "Permissions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_CreatedById",
                schema: "admin",
                table: "Permissions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_DeletedById",
                schema: "admin",
                table: "Permissions",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ObjectFieldMetadataId",
                schema: "admin",
                table: "Permissions",
                column: "ObjectFieldMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ObjectMetadataId",
                schema: "admin",
                table: "Permissions",
                column: "ObjectMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                schema: "admin",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UpdatedById",
                schema: "admin",
                table: "Permissions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "admin",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedById",
                schema: "admin",
                table: "Roles",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DeletedById",
                schema: "admin",
                table: "Roles",
                column: "DeletedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UpdatedById",
                schema: "admin",
                table: "Roles",
                column: "UpdatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "admin",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "admin",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "admin",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "admin",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                schema: "admin",
                table: "Users",
                column: "CreatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedById",
                schema: "admin",
                table: "Users",
                column: "DeletedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "admin",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedById",
                schema: "admin",
                table: "Users",
                column: "UpdatedById",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "admin",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleId",
                schema: "app",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "admin",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Users_UserId",
                schema: "app",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectFieldMetadata_ObjectMetadata_ObjectMetadataId",
                schema: "app",
                table: "ObjectFieldMetadata",
                column: "ObjectMetadataId",
                principalSchema: "app",
                principalTable: "ObjectMetadata",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectFieldMetadata_Users_CreatedById",
                schema: "app",
                table: "ObjectFieldMetadata",
                column: "CreatedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectFieldMetadata_Users_DeletedById",
                schema: "app",
                table: "ObjectFieldMetadata",
                column: "DeletedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectFieldMetadata_Users_UpdatedById",
                schema: "app",
                table: "ObjectFieldMetadata",
                column: "UpdatedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectMetadata_Users_CreatedById",
                schema: "app",
                table: "ObjectMetadata",
                column: "CreatedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectMetadata_Users_DeletedById",
                schema: "app",
                table: "ObjectMetadata",
                column: "DeletedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectMetadata_Users_UpdatedById",
                schema: "app",
                table: "ObjectMetadata",
                column: "UpdatedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "admin",
                table: "Permissions",
                column: "RoleId",
                principalSchema: "admin",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_CreatedById",
                schema: "admin",
                table: "Permissions",
                column: "CreatedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_DeletedById",
                schema: "admin",
                table: "Permissions",
                column: "DeletedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_UpdatedById",
                schema: "admin",
                table: "Permissions",
                column: "UpdatedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                schema: "admin",
                table: "RoleClaims",
                column: "RoleId",
                principalSchema: "admin",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_CreatedById",
                schema: "admin",
                table: "Roles",
                column: "CreatedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_DeletedById",
                schema: "admin",
                table: "Roles",
                column: "DeletedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UpdatedById",
                schema: "admin",
                table: "Roles",
                column: "UpdatedById",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "admin",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "ObjectFieldMetadata",
                schema: "app");

            migrationBuilder.DropTable(
                name: "PermissionActions",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "ObjectMetadata",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "admin");
        }
    }
}
