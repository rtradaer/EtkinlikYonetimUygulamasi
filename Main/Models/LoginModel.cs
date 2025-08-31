using System.ComponentModel.DataAnnotations;

namespace Main.Models;

public class LoginModel
{
    private string? _returnurl;

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "E-mail alanı zorunludur.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Şifre alanı zorunludur.")]
    public string? Password { get; set; }

    public string ReturnUrl
    {
        get
        {
            if (_returnurl is null)
                return "/";
            else
                return _returnurl;
        }
        set
        {
            _returnurl = value;
        }
    }
}