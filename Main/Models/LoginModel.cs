using System.ComponentModel.DataAnnotations;

namespace Main.Models;

public class LoginModel
{
    private string? _returnurl;

    [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur.")]
    public string? Name { get; set; }
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