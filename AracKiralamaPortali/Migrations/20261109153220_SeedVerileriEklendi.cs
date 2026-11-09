using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AracKiralamaPortali.Migrations
{
    /// <inheritdoc />
    public partial class SeedVerileriEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Aciklama", "Ad" },
                values: new object[,]
                {
                    { 1, "Düşük yakıt tüketimli, şehir içi kullanıma uygun araçlar", "Ekonomi" },
                    { 2, "Geniş iç hacimli, uzun yol ve aile kullanımına uygun araçlar", "SUV" },
                    { 3, "Üst segment konfor ve donanıma sahip araçlar", "Lüks" }
                });

            migrationBuilder.InsertData(
                table: "Subeler",
                columns: new[] { "Id", "Ad", "Adres", "Sehir", "Telefon" },
                values: new object[,]
                {
                    { 1, "Kadıköy Şubesi", "Caferağa Mah. Moda Cad. No: 10 Kadıköy", "İstanbul", "02160000001" },
                    { 2, "Çankaya Şubesi", "Kızılay Mah. Atatürk Bulvarı No: 20 Çankaya", "Ankara", "03120000002" },
                    { 3, "Konak Şubesi", "Alsancak Mah. Kıbrıs Şehitleri Cad. No: 30 Konak", "İzmir", "02320000003" }
                });

            migrationBuilder.InsertData(
                table: "Araclar",
                columns: new[] { "Id", "Durum", "FotografYolu", "GunlukUcret", "KategoriId", "Marka", "Model", "Plaka", "SubeId", "Vites", "YakitTuru", "Yil" },
                values: new object[,]
                {
                    { 1, 0, null, 1200m, 1, "Renault", "Clio", "34 ABC 101", 1, "Manuel", "Benzin", 2023 },
                    { 2, 0, null, 1100m, 1, "Fiat", "Egea", "06 DEF 202", 2, "Manuel", "Dizel", 2022 },
                    { 3, 0, null, 1800m, 2, "Dacia", "Duster", "35 GHI 303", 3, "Otomatik", "Dizel", 2023 },
                    { 4, 0, null, 2500m, 2, "Hyundai", "Tucson", "34 JKL 404", 1, "Otomatik", "Hibrit", 2024 },
                    { 5, 2, null, 5000m, 3, "BMW", "520i", "06 MNO 505", 2, "Otomatik", "Benzin", 2024 }
                });

            migrationBuilder.InsertData(
                table: "BakimKayitlari",
                columns: new[] { "Id", "Aciklama", "AracId", "BakimTuru", "Maliyet", "Tarih" },
                values: new object[,]
                {
                    { 1, "Yağ ve filtre değişimi", 1, "Periyodik Bakım", 3500m, new DateOnly(2026, 9, 15) },
                    { 2, "Dört lastik kışlık lastikle değiştirildi", 5, "Lastik Değişimi", 18000m, new DateOnly(2026, 11, 2) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Araclar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Araclar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Araclar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BakimKayitlari",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BakimKayitlari",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Araclar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Araclar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kategoriler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subeler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kategoriler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategoriler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subeler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subeler",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
