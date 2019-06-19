using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherAttack.Infra.Migrations
{
    public partial class creatingIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_USER",
                table: "Users",
                columns: new[] { "Email", "Username" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_USER",
                table: "Users");
        }
    }
}
