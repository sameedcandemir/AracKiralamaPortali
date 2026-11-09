using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AracKiralamaPortali.Models;

public enum AracDurumu
{
    [Display(Name = "Müsait")]
    Musait,

    [Display(Name = "Kirada")]
    Kirada,

    [Display(Name = "Bakımda")]
    Bakimda
}

public class Arac
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Marka zorunludur.")]
    [StringLength(50, ErrorMessage = "Marka en fazla 50 karakter olabilir.")]
    [Display(Name = "Marka")]
    public string Marka { get; set; } = "";

    [Required(ErrorMessage = "Model zorunludur.")]
    [StringLength(50, ErrorMessage = "Model en fazla 50 karakter olabilir.")]
    [Display(Name = "Model")]
    public string Model { get; set; } = "";

    [Range(1990, 2100, ErrorMessage = "Yıl 1990 ile 2100 arasında olmalıdır.")]
    [Display(Name = "Yıl")]
    public int Yil { get; set; }

    [Required(ErrorMessage = "Plaka zorunludur.")]
    [StringLength(15, ErrorMessage = "Plaka en fazla 15 karakter olabilir.")]
    [Display(Name = "Plaka")]
    public string Plaka { get; set; } = "";

    [Required(ErrorMessage = "Yakıt türü zorunludur.")]
    [StringLength(20, ErrorMessage = "Yakıt türü en fazla 20 karakter olabilir.")]
    [Display(Name = "Yakıt Türü")]
    public string YakitTuru { get; set; } = "";

    [Required(ErrorMessage = "Vites türü zorunludur.")]
    [StringLength(20, ErrorMessage = "Vites türü en fazla 20 karakter olabilir.")]
    [Display(Name = "Vites")]
    public string Vites { get; set; } = "";

    [Precision(10, 2)]
    [Range(1, 1000000, ErrorMessage = "Günlük ücret 1 ile 1.000.000 arasında olmalıdır.")]
    [Display(Name = "Günlük Ücret")]
    public decimal GunlukUcret { get; set; }

    [Display(Name = "Durum")]
    public AracDurumu Durum { get; set; } = AracDurumu.Musait;

    [StringLength(250)]
    [Display(Name = "Fotoğraf")]
    public string? FotografYolu { get; set; }

    [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
    [Display(Name = "Kategori")]
    public int? KategoriId { get; set; }
    public Kategori? Kategori { get; set; }

    [Required(ErrorMessage = "Şube seçimi zorunludur.")]
    [Display(Name = "Şube")]
    public int? SubeId { get; set; }
    public Sube? Sube { get; set; }

    public List<Rezervasyon> Rezervasyonlar { get; set; } = new();

    public List<BakimKaydi> BakimKayitlari { get; set; } = new();
}
