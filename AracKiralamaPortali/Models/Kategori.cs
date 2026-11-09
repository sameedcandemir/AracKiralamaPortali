using System.ComponentModel.DataAnnotations;

namespace AracKiralamaPortali.Models;

public class Kategori
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Kategori adı zorunludur.")]
    [StringLength(50, ErrorMessage = "Kategori adı en fazla 50 karakter olabilir.")]
    [Display(Name = "Kategori Adı")]
    public string Ad { get; set; } = "";

    [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
    [Display(Name = "Açıklama")]
    public string Aciklama { get; set; } = "";

    public List<Arac> Araclar { get; set; } = new();
}
