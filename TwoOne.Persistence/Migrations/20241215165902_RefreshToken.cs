using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwoOne.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "530b21d4-4dd9-4749-9444-ee1384d37d38",
                column: "ConcurrencyStamp",
                value: "2776cd56-ca4f-4bcc-971b-92971bce9258");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7db8bdb6-8ffe-4f73-903f-fe0424d52e10",
                column: "ConcurrencyStamp",
                value: "6aca05b0-de07-4b3e-acd6-7a96e13ae6db");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c79c336b-5210-411e-b8c5-f6f210d06204",
                column: "ConcurrencyStamp",
                value: "b104a928-11e5-4673-a8ea-173a62209c96");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "52f9a82a-e4b6-4f67-ae91-2e173aa21a1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8121073-a54b-4fa8-b23f-9c25c05c9d87", "AQAAAAIAAYagAAAAEGMOQjb46SvbsTltRJsv5WP1SQhQjC7w8sZhpdfUd1FfIE1wTiysBcgWTkNhFk0a3Q==", "8ebe16db-d57e-4652-8ca3-fe699c0726de" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "a901fdf4-edcb-4b6d-9a65-40df5b062f24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c830a3f6-5160-4f74-810d-acb9429982bc", "AQAAAAIAAYagAAAAEC45scDBuSzlbHl3QOacujHfSLaAXDwxpsSyYqcA83iYlWwxh4kH4zey/RXg0ta/mQ==", "378bb452-cdc5-4e90-b5b6-24cbea1d6545" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "e63a9b1c-2f89-406e-a5dc-d6ebe5cdf05a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4eddeb8-cba7-4e9e-b5ca-b317bed0a2b9", "AQAAAAIAAYagAAAAEC9x66xtYPLyPVsyF3TX0fONX9ycYjc/OMuNTqOekDZ2vmMUeFyk4JzupRhrWZoC+w==", "b48992a4-ed08-4462-99b5-c845908cefb5" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "admin",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "admin");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "530b21d4-4dd9-4749-9444-ee1384d37d38",
                column: "ConcurrencyStamp",
                value: "8c3a2d6f-da03-4ba4-9a0e-6b0dd999f181");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7db8bdb6-8ffe-4f73-903f-fe0424d52e10",
                column: "ConcurrencyStamp",
                value: "7c7664c1-abe8-4bd9-afa1-283895d5d91f");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c79c336b-5210-411e-b8c5-f6f210d06204",
                column: "ConcurrencyStamp",
                value: "aafee775-cba8-4746-988a-efc4d69e6e68");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "52f9a82a-e4b6-4f67-ae91-2e173aa21a1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04811756-a60e-4173-964a-036c126fc60a", "AQAAAAIAAYagAAAAEAbzOp7lfJQS133/b8/Qy3cMcv1vOEVWyaYXKU8FjQk39V+fn6etXVIgqm0qJmcFXQ==", "551014cc-6037-41f5-a61f-8e55b0c03bc4" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "a901fdf4-edcb-4b6d-9a65-40df5b062f24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5636d2e9-b997-4b4c-8c75-c686d8fa8e0d", "AQAAAAIAAYagAAAAEI5CYKr7FgAT7TRu9kX+PjcnlZ5TOgxIKmhzEmazu40GGfyv6z5L5zG0DF58BJXQ/w==", "dd90ef36-dea0-40e5-9644-205bdb76f425" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "e63a9b1c-2f89-406e-a5dc-d6ebe5cdf05a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ceb5c48-fa94-4f5f-b50b-b792d090dd79", "AQAAAAIAAYagAAAAELyvTJQU7R6Mdpnchpvzjoy5x8wZIiFUEFbcH+1QoXChI2Cc3ln8CiHzNbuIOK5qAQ==", "7499d5d4-40da-434e-a139-dfad41c43d95" });
        }
    }
}
