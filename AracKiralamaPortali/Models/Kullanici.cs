using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AracKiralamaPortali.Models;

public class Kullanici : IdentityUser
{
    [Required(ErrorMessage = "Ad zorunludur.")]
    [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
    [Display(Name = "Ad")]
    public string Ad { get; set; } = "";

    [Required(ErrorMessage = "Soyad zorunludur.")]
    [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
    [Display(Name = "Soyad")]
    public string Soyad { get; set; } = "";

    [Display(Name = "Ehliyet Tarihi")]
    public DateOnly? EhliyetTarihi { get; set; }

    public List<Rezervasyon> Rezervasyonlar { get; set; } = new();
}
