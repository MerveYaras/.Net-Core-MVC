using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore_PostgreSQL.Migrations
{
    public partial class SiparisDüzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiparisId",
                table: "SiparisDetays",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetays_SiparisId",
                table: "SiparisDetays",
                column: "SiparisId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisDetays_Siparis_SiparisId",
                table: "SiparisDetays",
                column: "SiparisId",
                principalTable: "Siparis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiparisDetays_Siparis_SiparisId",
                table: "SiparisDetays");

            migrationBuilder.DropIndex(
                name: "IX_SiparisDetays_SiparisId",
                table: "SiparisDetays");

            migrationBuilder.DropColumn(
                name: "SiparisId",
                table: "SiparisDetays");
        }
    }
}
