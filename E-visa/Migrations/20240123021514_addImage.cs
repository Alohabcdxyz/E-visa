using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Visa.Migrations
{
    /// <inheritdoc />
    public partial class addImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassportFrontPage",
                table: "EvisaForm",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PortraitFormat",
                table: "EvisaForm",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassportFrontPage",
                table: "EvisaForm");

            migrationBuilder.DropColumn(
                name: "PortraitFormat",
                table: "EvisaForm");
        }
    }
}
