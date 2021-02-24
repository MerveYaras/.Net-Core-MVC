using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore_PostgreSQL.Migrations
{
    public partial class AdresBaslik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdresBaslik",
                table: "Adres",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdresBaslik",
                table: "Adres");
        }
    }
}
