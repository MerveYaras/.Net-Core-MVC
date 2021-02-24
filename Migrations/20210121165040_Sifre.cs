using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore_PostgreSQL.Migrations
{
    public partial class Sifre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sifre",
                table: "Kullanicis",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sifre",
                table: "Kullanicis");
        }
    }
}
