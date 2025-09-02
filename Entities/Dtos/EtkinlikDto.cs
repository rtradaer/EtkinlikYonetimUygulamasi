using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record EtkinlikDto
{
    public int Id { get; init; }

    [Required(ErrorMessage = "Başlık alanı boş bırakılamaz.")]
    [StringLength(255, ErrorMessage = "Başlık en fazla 255 karakter olabilir.")]
    public String? Title { get; init; } 
    
    [Required(ErrorMessage = "Başlangıç Tarihi alanı boş bırakılamaz.")]
    public DateTime StartDate { get; init; }  // Takvim üzerinden seçim
    
    [Required(ErrorMessage = "Bitiş Tarihi boş bırakılamaz.")]
    public DateTime EndDate { get; init; } // Takvim üzerinden seçim
    
    public String? ImageUrl { get; set; }  // En fazla 2 MB

    [Required(ErrorMessage = "Kısa Açıklama alanı boş bırakılamaz.")]
    [StringLength(512, ErrorMessage = "Kısa Açıklama en fazla 512 karakter olabilir.")]
    public String? ShortDescription { get; init; } 
    
    [Required(ErrorMessage = "Uzun Açıklama alanı boş bırakılamaz.")]
    public String? LongDescription { get; init; }  // Html editör üzerinden veri giriş

    public bool IsActive { get; init; }
    public DateTime CreatedAt { get; set; }
    
}
