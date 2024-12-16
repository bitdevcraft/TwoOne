using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TwoOne.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "admin",
                table: "RefreshTokens");

            migrationBuilder.EnsureSchema(
                name: "audit");

            migrationBuilder.CreateTable(
                name: "Audits",
                schema: "audit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Operation = table.Column<string>(type: "text", nullable: true),
                    TableName = table.Column<string>(type: "text", nullable: true),
                    RecordId = table.Column<string>(type: "text", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditEntries",
                schema: "audit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FieldName = table.Column<string>(type: "text", nullable: true),
                    OldValue = table.Column<string>(type: "text", nullable: true),
                    NewValue = table.Column<string>(type: "text", nullable: true),
                    AuditId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditEntries_Audits_AuditId",
                        column: x => x.AuditId,
                        principalSchema: "audit",
                        principalTable: "Audits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "530b21d4-4dd9-4749-9444-ee1384d37d38",
                column: "ConcurrencyStamp",
                value: "a13f3674-ced6-4170-9c50-932042c95c20");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7db8bdb6-8ffe-4f73-903f-fe0424d52e10",
                column: "ConcurrencyStamp",
                value: "a5d00a4a-b72e-4211-8098-dcac05b0bd4c");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c79c336b-5210-411e-b8c5-f6f210d06204",
                column: "ConcurrencyStamp",
                value: "ae4f6b31-2dfb-414e-921b-ba0bd7b3c0e9");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "52f9a82a-e4b6-4f67-ae91-2e173aa21a1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c03f2a5-291a-49ae-8af1-0c256374a325", "AQAAAAIAAYagAAAAEKdtKuFrgIu61Jnxy2w4sZZzsxQq/p0ldbQNVvvujXGzK+Slk02ZMwv67ZdA1YiTSQ==", "7f069c5b-5de4-4167-8a0c-48c3dfaf7c63" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "a901fdf4-edcb-4b6d-9a65-40df5b062f24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "044ad136-1682-4a03-994e-71250a73dd30", "AQAAAAIAAYagAAAAEPZ1yZkiPE2RveHNPZmDbYi32VWbFIKt9O8hoKsBMnVhjAbBmtWTYTKYWU6ec2jKcA==", "3e020684-17e3-4db2-803f-234c8341537a" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "e63a9b1c-2f89-406e-a5dc-d6ebe5cdf05a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cbc178c-fc8f-4bf5-804d-f53d0ecc08e8", "AQAAAAIAAYagAAAAEBKACsKm3AX6dpFSreTG787HyFUB7JG52sfWOk4iVqkHXs+BYXkq9xeRaRZtt1ULzw==", "4597baac-a47d-49c9-a236-74aa96817989" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "admin",
                table: "RefreshTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditEntries_AuditId",
                schema: "audit",
                table: "AuditEntries",
                column: "AuditId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditEntries",
                schema: "audit");

            migrationBuilder.DropTable(
                name: "Audits",
                schema: "audit");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "admin",
                table: "RefreshTokens");

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
    }
}
