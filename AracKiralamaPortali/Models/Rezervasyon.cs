using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AracKiralamaPortali.Models;

public enum RezervasyonDurumu
{
    [Display(Name = "Beklemede")]
    Beklemede,

    [Display(Name = "Onaylandı")]
    Onaylandi,

    [Display(Name = "İptal")]
    Iptal,

    [Display(Name = "Tamamlandı")]
    Tamamlandi
}

public class Rezervasyon
{
    public int Id { get; set; }

    public string KullaniciId { get; set; } = "";

    [Required(ErrorMessage = "Araç seçimi zorunludur.")]
    [Display(Name = "Araç")]
    public int? AracId { get; set; }
    public Arac? Arac { get; set; }

    [Required(ErrorMessage = "Alış şubesi zorunludur.")]
    [Display(Name = "Alış Şubesi")]
    public int? AlisSubeId { get; set; }
    public Sube? AlisSube { get; set; }

    [Required(ErrorMessage = "İade şubesi zorunludur.")]
    [Display(Name = "İade Şubesi")]
    public int? IadeSubeId { get; set; }
    public Sube? IadeSube { get; set; }

    [Display(Name = "Başlangıç Tarihi")]
    public DateOnly BaslangicTarihi { get; set; }

    [Display(Name = "Bitiş Tarihi")]
    public DateOnly BitisTarihi { get; set; }

    [Precision(10, 2)]
    [Display(Name = "Toplam Ücret")]
    public decimal ToplamUcret { get; set; }

    [Display(Name = "Durum")]
    public RezervasyonDurumu Durum { get; set; } = RezervasyonDurumu.Beklemede;
}
