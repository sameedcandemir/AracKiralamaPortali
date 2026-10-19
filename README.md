# Araç Kiralama Portalı

BLM4581 Ağ Tabanlı Teknolojiler ve Uygulamaları dersi (2026–2027 Güz) dönem projesi.

Müşterilerin şubelerdeki araçları inceleyip tarih aralığı seçerek rezervasyon yapabildiği, yöneticinin araç, şube, kategori, rezervasyon ve bakım kayıtlarını yönettiği bir web uygulaması.

## Ekip

| Ad Soyad | Lider olduğu haftalar |
|---|---|
| Samed Candemir | 1–3 |
| Muhammed Mete | 4–6 |
| Ahmet Taha Erol | 7–9 |

## Kullanılan teknolojiler

- ASP.NET Core MVC (.NET 10)
- PostgreSQL
- Entity Framework Core (Npgsql sağlayıcısı, migration'lar)
- ASP.NET Core Identity (Admin ve Musteri rolleri)
- Bootstrap 5 (mobil uyumlu arayüz)
- Swagger (Web API testi)

## Gereksinimler

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/) (15 veya üzeri) ve pgAdmin
- EF Core komut satırı aracı:

```powershell
dotnet tool install --global dotnet-ef
```

## Kurulum

### 1. Depoyu klonlayın

```powershell
git clone https://github.com/sameedcandemir/AracKiralamaPortali.git
cd AracKiralamaPortali/AracKiralamaPortali
```

### 2. Veritabanı bağlantı dizesini ekleyin

Şifre içerdiği için bağlantı dizesi `appsettings.json` dosyasında **tutulmaz**. Bunun yerine .NET'in user-secrets özelliği kullanılır; değer bilgisayarınızdaki kullanıcı klasöründe saklanır ve depoya girmez.

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=AracKiralamaDb;Username=postgres;Password=SIFRENIZ"
```

`SIFRENIZ` yerine PostgreSQL kurulumunda belirlediğiniz şifreyi yazın.

### 3. Veritabanını oluşturun

```powershell
dotnet ef database update
```

Bu komut migration'ları uygulayarak `AracKiralamaDb` veritabanını ve tabloları oluşturur.

### 4. Uygulamayı çalıştırın

```powershell
dotnet run
```

Terminalde yazan adresi (ör. `https://localhost:7xxx`) tarayıcıda açın.

## Ekip çalışma düzeni

`main` dalına doğrudan push yapılmaz. Her iş ayrı bir dalda yapılır ve pull request ile birleştirilir:

```powershell
git checkout main
git pull
git checkout -b ozellik/kategori-yonetimi   # işe uygun bir dal adı
# ... değişiklikler ...
git add .
git commit -m "Kategori listeleme sayfası eklendi"
git push -u origin ozellik/kategori-yonetimi
```

Ardından GitHub'da **Compare & pull request** ile PR açılır; başka bir üye kontrol edip birleştirir. Migration ekleyecek kişi önce güncel `main`'i çekmelidir; aynı anda iki kişi migration eklememelidir.

## Proje yapısı

| Klasör | İçerik |
|---|---|
| `Controllers/` | MVC denetleyicileri |
| `Models/` | Varlık sınıfları |
| `Data/` | `AppDbContext` ve veritabanı ayarları |
| `Views/` | Razor görünümleri |
| `wwwroot/` | CSS, JavaScript, Bootstrap ve yüklenen görseller |
