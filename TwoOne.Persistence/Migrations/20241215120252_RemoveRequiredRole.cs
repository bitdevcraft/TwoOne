using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwoOne.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRequiredRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "admin",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                schema: "admin",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "admin",
                table: "Users",
                column: "RoleId",
                principalSchema: "admin",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "admin",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                schema: "admin",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "530b21d4-4dd9-4749-9444-ee1384d37d38",
                column: "ConcurrencyStamp",
                value: "ac959942-c360-4e32-96ef-3972dbf6ae2b");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7db8bdb6-8ffe-4f73-903f-fe0424d52e10",
                column: "ConcurrencyStamp",
                value: "c21b3e00-a978-4190-b2b4-b3a1a1c182fa");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c79c336b-5210-411e-b8c5-f6f210d06204",
                column: "ConcurrencyStamp",
                value: "fd807087-de76-4407-a0bc-22d11c3e246a");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "52f9a82a-e4b6-4f67-ae91-2e173aa21a1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c977c1f9-0ddf-4682-89ca-729ddd0d33cd", "AQAAAAIAAYagAAAAEMxQZkQ3rq0EtFLBvsMsyjYQQElcZlSORWEZ8z/Dt2wN/HVD3pOKMtkWpW1ENVPwOQ==", "135caa45-2196-4927-8d4e-38044e8b3618" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "a901fdf4-edcb-4b6d-9a65-40df5b062f24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9250086f-1849-49a8-b758-79f4d3e838e3", "AQAAAAIAAYagAAAAECr8E/zkwOW5o71jKh8HpGtqTyJ7UwNV/uZw++Y19whbNTune1iiN9IqCFr4XQQxtQ==", "60a5dba3-2a2e-4555-8ff2-f2d401028823" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "e63a9b1c-2f89-406e-a5dc-d6ebe5cdf05a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a00b4322-f6a0-4dda-9698-8269894c96da", "AQAAAAIAAYagAAAAED2deqvpWpstZ51blqq0lat3C41AI9KlPY5HZSZI4v2aGJ9nO6QVPeWuGx0jQB0eyQ==", "45bd56af-7266-427e-8fc7-9628f7a90bbe" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "admin",
                table: "Users",
                column: "RoleId",
                principalSchema: "admin",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
