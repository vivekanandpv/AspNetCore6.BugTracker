using System.ComponentModel.DataAnnotations;

namespace AspNetCore6.BugTracker.ViewModels.Auth;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Username { get; set; }

    [Required]
    [MaxLength(100)]
    //  Do not validate by regex here!
    public string Password { get; set; }
}