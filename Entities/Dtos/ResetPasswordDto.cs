using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record ResetPasswordDto
{
    public String? Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Mevcut Şifre alanı boş bırakılamaz.")]
    public String? CurrentPassword { get; init; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
    public String? Password { get; init; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Şifre Doğrulama alanı boş bırakılamaz.")]
    public String? ConfirmPassword { get; init; }
}