using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwoOne.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PasswordDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "530b21d4-4dd9-4749-9444-ee1384d37d38",
                column: "ConcurrencyStamp",
                value: "f3890335-b369-4abf-ad43-558069e8574f");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7db8bdb6-8ffe-4f73-903f-fe0424d52e10",
                column: "ConcurrencyStamp",
                value: "1447aab3-643f-44ab-b41b-39b3c9e75737");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c79c336b-5210-411e-b8c5-f6f210d06204",
                column: "ConcurrencyStamp",
                value: "6c70601c-3d19-4613-88e1-346306c8c0b6");

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "52f9a82a-e4b6-4f67-ae91-2e173aa21a1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43a826bd-586d-4845-8f5f-f6fbf4ea5421", null, "70e52111-c5a3-492b-86f4-1e2c56a00999" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "a901fdf4-edcb-4b6d-9a65-40df5b062f24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3d86acc-2841-44f4-b561-2cdb9a069dcf", null, "593ce062-4d32-4e9b-973d-65610dc291e0" });

            migrationBuilder.UpdateData(
                schema: "admin",
                table: "Users",
                keyColumn: "Id",
                keyValue: "e63a9b1c-2f89-406e-a5dc-d6ebe5cdf05a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cba53403-fee7-49ce-9ebf-70118a02e3db", null, "212f76c3-f3d3-44a1-a8b3-08b1f39001ff" });
        }
    }
}
