using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore_PostgreSQL.Migrations
{
    public partial class Rememberme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RememberMe",
                table: "Kullanicis",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RememberMe",
                table: "Kullanicis");
        }
    }
}
