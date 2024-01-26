using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Visa.Migrations
{
    /// <inheritdoc />
    public partial class dnajd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EvisaForm_AppUserId",
                table: "EvisaForm");

            migrationBuilder.CreateIndex(
                name: "IX_EvisaForm_AppUserId",
                table: "EvisaForm",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EvisaForm_AppUserId",
                table: "EvisaForm");

            migrationBuilder.CreateIndex(
                name: "IX_EvisaForm_AppUserId",
                table: "EvisaForm",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");
        }
    }
}
