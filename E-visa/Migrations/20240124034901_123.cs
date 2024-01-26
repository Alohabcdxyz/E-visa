using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Visa.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "EvisaForm",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvisaForm_AppUserId",
                table: "EvisaForm",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EvisaForm_AspNetUsers_AppUserId",
                table: "EvisaForm",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvisaForm_AspNetUsers_AppUserId",
                table: "EvisaForm");

            migrationBuilder.DropIndex(
                name: "IX_EvisaForm_AppUserId",
                table: "EvisaForm");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "EvisaForm");
        }
    }
}
