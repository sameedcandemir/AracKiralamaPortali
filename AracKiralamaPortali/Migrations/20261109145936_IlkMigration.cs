using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AracKiralamaPortali.Migrations
{
    /// <inheritdoc />
    public partial class IlkMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Aciklama = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sehir = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Telefon = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marka = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Yil = table.Column<int>(type: "integer", nullable: false),
                    Plaka = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    YakitTuru = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Vites = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    GunlukUcret = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Durum = table.Column<int>(type: "integer", nullable: false),
                    FotografYolu = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    KategoriId = table.Column<int>(type: "integer", nullable: false),
                    SubeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Araclar_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Araclar_Subeler_SubeId",
                        column: x => x.SubeId,
                        principalTable: "Subeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciId = table.Column<string>(type: "text", nullable: false),
                    AracId = table.Column<int>(type: "integer", nullable: false),
                    AlisSubeId = table.Column<int>(type: "integer", nullable: false),
                    IadeSubeId = table.Column<int>(type: "integer", nullable: false),
                    BaslangicTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    BitisTarihi = table.Column<DateOnly>(type: "date", nullable: false),
                    ToplamUcret = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Durum = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Araclar_AracId",
                        column: x => x.AracId,
                        principalTable: "Araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Subeler_AlisSubeId",
                        column: x => x.AlisSubeId,
                        principalTable: "Subeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Subeler_IadeSubeId",
                        column: x => x.IadeSubeId,
                        principalTable: "Subeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_KategoriId",
                table: "Araclar",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_Plaka",
                table: "Araclar",
                column: "Plaka",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_SubeId",
                table: "Araclar",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_AlisSubeId",
                table: "Rezervasyonlar",
                column: "AlisSubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_AracId",
                table: "Rezervasyonlar",
                column: "AracId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_IadeSubeId",
                table: "Rezervasyonlar",
                column: "IadeSubeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Subeler");
        }
    }
}
