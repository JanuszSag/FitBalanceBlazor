using System.ComponentModel.DataAnnotations;

namespace FitBalanceBlazor.Models;

public class SignIn
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}