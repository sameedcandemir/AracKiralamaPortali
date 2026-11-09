using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AracKiralamaPortali.Migrations
{
    /// <inheritdoc />
    public partial class RollerEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1f4c2d0-5b7e-4c11-9d3a-0e6f1b2c3d41", "b2e5d3c1-6c8f-4d22-8e4b-1f7a2c3d4e52", "Admin", "ADMIN" },
                    { "c3a6e4d2-7d9a-4e33-9f5c-2a8b3d4e5f63", "d4b7f5e3-8eab-4f44-a06d-3b9c4e5f6a74", "Musteri", "MUSTERI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1f4c2d0-5b7e-4c11-9d3a-0e6f1b2c3d41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a6e4d2-7d9a-4e33-9f5c-2a8b3d4e5f63");
        }
    }
}
