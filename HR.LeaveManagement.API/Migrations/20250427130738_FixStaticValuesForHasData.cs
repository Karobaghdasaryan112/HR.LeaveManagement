using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class FixStaticValuesForHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "96533749-e618-48c9-9148-04acc632c49d", "34d99c8b-0018-4670-a882-6da50ade9658" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "50c0b4c1-e561-4f8e-a72d-0b233e412044", "08864c12-f556-43c7-be85-765f36172612" });
        }
    }
}
