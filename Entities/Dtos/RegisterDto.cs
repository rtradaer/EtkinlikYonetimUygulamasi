using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record RegisterDto
{
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
    public String? FirstName { get; init; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Soyisim alanı boş bırakılamaz.")]
    public String? LastName { get; init; }

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "E-mail alanı boş bırakılamaz.")]
    public String? Email { get; init; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
    public String? Password { get; init; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Şifre Doğrulama alanı boş bırakılamaz.")]
    public String? ConfirmPassword { get; init; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Doğum Tarihi alanı boş bırakılamaz.")]
    public DateTime? BirthDate { get; init; }
}