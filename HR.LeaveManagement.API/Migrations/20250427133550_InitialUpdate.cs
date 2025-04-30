using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee6d7b8c-dbd8-4c10-b5a0-4899059df1e0", "AQAAAAIAAYagAAAAEMyGPi5LPdB5VDC2eAbBShYVE8YzZN2dhus4xDi6iM4bhOeX78oYcN/j3uewnb2ccQ==", "c68eeb89-8cef-46cc-a2b1-a842d33e760e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "027400b6-5d95-4aec-a695-e88f7c4edc88", "AQAAAAIAAYagAAAAEOm+zQ7jdJvr2L7JqiqjLTLRy3RJhNB7lVgme9wdjK+Vxhc2jBjT3jSJXbWlyYwjWw==", "735c773c-2a40-4b0a-87d8-695d3426e4f6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25b0fdbb-0c24-4b3d-8d1a-02ac7278a4cb", "AQAAAAIAAYagAAAAEECgs9QwG2lC1h4GgxN+jp4Dfr4DZ0pYgpbXgmAS5v6yM2aAbPvD7pOe0T7Ml+w7Yw==", "34d2322a-8dc8-4f72-a7bc-17e4e18b748a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53f64297-4a5f-47e4-ac30-909f98d9ac2e", "AQAAAAIAAYagAAAAEECgs9QwG2lC1h4GgxN+jp4Dfr4DZ0pYgpbXgmAS5v6yM2aAbPvD7pOe0T7Ml+w7Yw==", "95a30b0c-ab1d-444a-8021-a2f7331561ee" });
        }
    }
}
