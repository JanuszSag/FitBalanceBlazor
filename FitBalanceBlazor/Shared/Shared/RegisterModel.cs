using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1;

public class RegisterModel
{
    [Required]
    public string Username { get; set; }
    [Required][EmailAddress]
    public string Email { get; set; }
    [Required]
    public DateOnly Birthday { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public int Weight { get; set; }
    [Required]
    public int Height { get; set; }
    [Required]
    public string Password { get; set; }
}