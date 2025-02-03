using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClassLibrary1;

public class LoginModel
{
    [Required(ErrorMessage = "Pole login jest wymagane.")]
    [StringLength(20, ErrorMessage = "Login może mieć maksymalnie 40 znaków.")]
    public string login { get; set; } = string.Empty;

    [Required(ErrorMessage = "Pole hasło jest wymagane.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Hasło musi mieć od 3 do 20 znaków.")]
    public string password { get; set; } = string.Empty;
}