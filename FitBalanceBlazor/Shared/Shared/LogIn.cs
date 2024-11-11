using System.ComponentModel.DataAnnotations;

namespace FitBalanceBlazor.Models;

public class LogIn
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}