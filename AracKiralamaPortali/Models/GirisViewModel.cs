using System.ComponentModel.DataAnnotations;

namespace AracKiralamaPortali.Models;

public class GirisViewModel
{
    [Required(ErrorMessage = "E-posta zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
    [Display(Name = "E-posta")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Şifre zorunludur.")]
    [DataType(DataType.Password)]
    [Display(Name = "Şifre")]
    public string Sifre { get; set; } = "";

    [Display(Name = "Beni hatırla")]
    public bool BeniHatirla { get; set; }
}
