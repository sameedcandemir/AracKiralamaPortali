using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AracKiralamaPortali.Models;

public class BakimKaydi
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Araç seçimi zorunludur.")]
    [Display(Name = "Araç")]
    public int? AracId { get; set; }
    public Arac? Arac { get; set; }

    [Display(Name = "Tarih")]
    public DateOnly Tarih { get; set; }

    [Required(ErrorMessage = "Bakım türü zorunludur.")]
    [StringLength(50, ErrorMessage = "Bakım türü en fazla 50 karakter olabilir.")]
    [Display(Name = "Bakım Türü")]
    public string BakimTuru { get; set; } = "";

    [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
    [Display(Name = "Açıklama")]
    public string? Aciklama { get; set; }

    [Precision(10, 2)]
    [Range(0, 1000000, ErrorMessage = "Maliyet 0 ile 1.000.000 arasında olmalıdır.")]
    [Display(Name = "Maliyet")]
    public decimal Maliyet { get; set; }
}
