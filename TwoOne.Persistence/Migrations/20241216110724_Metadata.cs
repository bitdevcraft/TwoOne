using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwoOne.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Metadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Roles_RoleId",
                schema: "app",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Users_UserId",
                schema: "app",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                schema: "app",
                table: "AspNetUserRoles");

            migrationBuilder.EnsureSchema(
                name: "metadata");

            migrationBuilder.RenameTable(
                name: "ObjectMetadata",
                schema: "app",
                newName: "ObjectMetadata",
                newSchema: "metadata");

            migrationBuilder.RenameTable(
                name: "ObjectFieldMetadata",
                schema: "app",
                newName: "ObjectFieldMetadata",
                newSchema: "metadata");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "app",
                newName: "UserRoles",
                newSchema: "admin");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "admin",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "admin",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "530b21d4-4dd9-4749-9444-ee1384d37d38",
                column: "ConcurrencyStamp",
                value: "e21423d9-7306-43cd-a20b-19e76b0652bc");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7db8bdb6-8ffe-4f73-903f-fe0424d52e10",
                column: "ConcurrencyStamp",
                value: "d7c44bbd-0de6-44bb-b6db-72b9cf518e97");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c79c336b-5210-411e-b8c5-f6f210d06204",
                column: "ConcurrencyStamp",
                value: "3b76cca3-58e3-460f-823d-f24aeb7768a3");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "52f9a82a-e4b6-4f67-ae91-2e173aa21a1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7ab75e6-6739-4a6b-83cc-d051c98311ec", "AQAAAAIAAYagAAAAEGDbWtSRHcPaBG+tFuEl0OSJWa0uYL/SpCKGUjeYnkb//b+v66mOvH/6LSHQgMyPRw==", "ccd990a2-48b5-4f84-90a5-12798f993153" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "a901fdf4-edcb-4b6d-9a65-40df5b062f24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50db3cc5-8fd5-4af0-b761-7d1386fdf2ff", "AQAAAAIAAYagAAAAEGcMNQf4L8FVZbuKL/L6e2AM4KgtcVohCC4ZYTVovnKTf6hL8Gbgde9rcYVYgJHyuQ==", "b895c013-ac68-4608-92cf-0d8a4b39ca26" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "e63a9b1c-2f89-406e-a5dc-d6ebe5cdf05a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d49e8973-4f21-4986-bf57-44a1aa9a834e", "AQAAAAIAAYagAAAAEM1mD+4HXJsWygaeWg8YFgkXTWHJNeByKMpv23H9gxX3mMR4SUJkpacYmJuPNU8V3w==", "03c4f97f-14dd-4b52-947b-3d8cf14c07a3" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "admin",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "admin",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "admin",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "admin",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                schema: "admin",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "admin",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "admin",
                table: "UserRoles");

            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.RenameTable(
                name: "ObjectMetadata",
                schema: "metadata",
                newName: "ObjectMetadata",
                newSchema: "app");

            migrationBuilder.RenameTable(
                name: "ObjectFieldMetadata",
                schema: "metadata",
                newName: "ObjectFieldMetadata",
                newSchema: "app");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "admin",
                newName: "AspNetUserRoles",
                newSchema: "app");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                schema: "app",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                schema: "app",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

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
        }
    }
}
