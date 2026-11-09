using System.ComponentModel.DataAnnotations;

namespace AracKiralamaPortali.Models;

public class Sube
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Şube adı zorunludur.")]
    [StringLength(100, ErrorMessage = "Şube adı en fazla 100 karakter olabilir.")]
    [Display(Name = "Şube Adı")]
    public string Ad { get; set; } = "";

    [Required(ErrorMessage = "Şehir zorunludur.")]
    [StringLength(50, ErrorMessage = "Şehir en fazla 50 karakter olabilir.")]
    [Display(Name = "Şehir")]
    public string Sehir { get; set; } = "";

    [Required(ErrorMessage = "Adres zorunludur.")]
    [StringLength(250, ErrorMessage = "Adres en fazla 250 karakter olabilir.")]
    [Display(Name = "Adres")]
    public string Adres { get; set; } = "";

    [Required(ErrorMessage = "Telefon zorunludur.")]
    [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
    [StringLength(20, ErrorMessage = "Telefon en fazla 20 karakter olabilir.")]
    [Display(Name = "Telefon")]
    public string Telefon { get; set; } = "";
}
