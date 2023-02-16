using System.ComponentModel.DataAnnotations;

namespace AspNetCore6.BugTracker.ViewModels.Auth;

public class UserCreateViewModel
{
    [Required]
    [EmailAddress]
    public string Username { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string FullName { get; set; }
    
    [MaxLength(200)]
    public string AvatarUrl { get; set; }
    
    [Required]
    [MinLength(8)]
    [MaxLength(100)]
    //  https://stackoverflow.com/a/21456918
    //  Minimum eight characters, at least one uppercase letter,
    //  one lowercase letter, one number and one special character
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
    public string Password { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(100)]
    public IEnumerable<string> Roles { get; set; } = new List<string>();
}