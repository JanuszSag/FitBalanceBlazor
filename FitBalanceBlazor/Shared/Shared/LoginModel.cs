using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1;

public class LoginModel
{
    [Required]
    public string email { get; set; }
    [Required]
    public string Password { get; set; }
}