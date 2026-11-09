# Araç Kiralama Portalı

BLM4581 Ağ Tabanlı Teknolojiler ve Uygulamaları dersi (2026–2027 Güz) dönem projesi.

Müşterilerin şubelerdeki araçları inceleyip tarih aralığı seçerek rezervasyon yapabildiği, yöneticinin araç, şube, kategori, rezervasyon ve bakım kayıtlarını yönettiği bir web uygulaması.

## Ekip

| Ad Soyad | Lider olduğu haftalar |
|---|---|
| Samed Candemir | 1–3 |
| Muhammed Mete | 4–6 |
| Ahmet Taha Erol | 7–9 |

Haftalık videolar: [Google Drive klasörü](https://drive.google.com/drive/folders/14getoNzJrZwLKVoA4S7gkM4P9as_9mSX)

## Haftalık ilerleme

| Hafta | Lider | Yapılanlar |
|---|---|---|
| 1 | Samed Candemir | **Samed:** GitHub deposu ve README; ASP.NET Core MVC projesi; PostgreSQL + EF Core (Npgsql) bağlantısı, bağlantı dizesi user-secrets ile; Google Drive klasörü. **Muhammed Mete:** Bootstrap ile mobil uyumlu sayfa düzeni. **Ahmet Taha:** README kurulum adımlarının temiz klonda test edilmesi |
| 2 | Samed Candemir | **Samed:** Arac ve Rezervasyon varlıkları, ilişkiler (iki şube ilişkisi `Restrict`), ilk migration. **Muhammed Mete:** Kategori ve Sube varlıkları. **Ahmet Taha:** BakimKaydi varlığı ve seed verileri |
| 3 | Samed Candemir | **Samed:** ASP.NET Core Identity, `Kullanici` sınıfı, Admin ve Musteri rolleri. **Muhammed Mete:** Kayıt, giriş ve çıkış sayfaları. **Ahmet Taha:** Rol bazlı yetkilendirme, başlangıç admin hesabı |

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

### 2. Paketleri yükleyin

```powershell
dotnet restore
```

Bu adım atlanırsa sonraki `dotnet ef` komutu `project.assets.json` bulunamadı hatası verir.

### 3. Veritabanı bağlantı dizesini ekleyin

Şifre içerdiği için bağlantı dizesi `appsettings.json` dosyasında **tutulmaz**. Bunun yerine .NET'in user-secrets özelliği kullanılır; değer bilgisayarınızdaki kullanıcı klasöründe saklanır ve depoya girmez.

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=AracKiralamaDb;Username=postgres;Password=SIFRENIZ"
```

`SIFRENIZ` yerine PostgreSQL kurulumunda belirlediğiniz şifreyi yazın.

### 4. Veritabanını oluşturun

```powershell
dotnet ef database update
```

Bu komut migration'ları uygulayarak `AracKiralamaDb` veritabanını ve tabloları oluşturur.

### 5. Başlangıç admin hesabını tanımlayın

Admin bilgileri de depoya girmez, user-secrets ile verilir. Uygulama açılırken bu e-postayla bir kullanıcı yoksa `Admin` rolüyle oluşturur.

```powershell
dotnet user-secrets set "BaslangicAdmin:Email" "ADMIN_EPOSTANIZ"
dotnet user-secrets set "BaslangicAdmin:Sifre" "ADMIN_SIFRENIZ"
```

Şifre en az 6 karakter olmalı; büyük harf, küçük harf, rakam ve özel karakter içermelidir.

### 6. Uygulamayı çalıştırın

```powershell
dotnet run
```

Terminalde yazan adresi (ör. `https://localhost:7xxx`) tarayıcıda açın.

## Roller

| Rol | Nasıl alınır | Yetki |
|---|---|---|
| `Musteri` | Kayıt formuyla otomatik | Müşteri sayfaları |
| `Admin` | Yalnızca başlangıç admin hesabı | Yönetim paneli (`/Yonetim`) |

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
