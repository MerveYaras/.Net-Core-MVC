using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetCore_PostgreSQL.Migrations
{
    public partial class Siparis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sepets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciId = table.Column<int>(type: "integer", nullable: false),
                    UrunAdet = table.Column<int>(type: "integer", nullable: false),
                    UrunId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sepets_Kullanicis_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepets_Uruns_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Uruns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciId = table.Column<int>(type: "integer", nullable: false),
                    SiparisTarihi = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "numeric", nullable: false),
                    Adres = table.Column<string>(type: "text", nullable: true),
                    Telefon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparis_Kullanicis_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UrunId = table.Column<int>(type: "integer", nullable: false),
                    UrunAdet = table.Column<int>(type: "integer", nullable: false),
                    UrunFiyat = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDetays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiparisDetays_Uruns_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Uruns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sepets_KullaniciId",
                table: "Sepets",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Sepets_UrunId",
                table: "Sepets",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_KullaniciId",
                table: "Siparis",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetays_UrunId",
                table: "SiparisDetays",
                column: "UrunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sepets");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "SiparisDetays");
        }
    }
}
