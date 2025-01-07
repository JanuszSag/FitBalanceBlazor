using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClassLibrary1;

public class LoginModel
{
    public string Email { get; set; }

    public string Password { get; set; }
}