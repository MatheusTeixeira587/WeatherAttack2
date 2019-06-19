using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherAttack.Infra.Migrations
{
    public partial class ignoringNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users");
        }
    }
}
