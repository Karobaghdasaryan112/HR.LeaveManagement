using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "25b0fdbb-0c24-4b3d-8d1a-02ac7278a4cb", "34d2322a-8dc8-4f72-a7bc-17e4e18b748a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "53f64297-4a5f-47e4-ac30-909f98d9ac2e", "95a30b0c-ab1d-444a-8021-a2f7331561ee" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "94419f96-3963-4629-8b45-d0aedae8e180", "858b006e-ccb6-421c-a2a5-02aa4a7e8a96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b1d54ab6-1728-4117-b16c-56cee667f783", "c889983a-546e-419b-98b5-74bc242e5bcb" });
        }
    }
}
