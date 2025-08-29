using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record RegisterDto
{
    [Required(ErrorMessage ="Kullanıcı Adı alanı boş bırakılamaz.")]
    public String? UserName { get; init; }

    [Required(ErrorMessage ="E-mail alanı boş bırakılamaz.")]
    public String? Email { get; init; }

    [Required(ErrorMessage ="Şifre alanı boş bırakılamaz.")]
    public String? Password { get; init; }
    
    [Required(ErrorMessage ="Şifre Doğrulama alanı boş bırakılamaz.")]
    public String? ConfirmPassword { get; init; }

    [Required(ErrorMessage = "Doğum Tarihi alanı boş bırakılamaz.")]
    [DataType(DataType.Date)]
    public DateTime? BirthDate { get; init; }
}