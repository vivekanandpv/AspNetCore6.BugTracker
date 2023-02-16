namespace AspNetCore6.BugTracker.ViewModels.Auth;

public class UserCreateViewModel
{
    public string Username { get; set; }
    public string FullName { get; set; }
    public string AvatarUrl { get; set; }
    public string Password { get; set; }
    public IEnumerable<string> Roles { get; set; } = new List<string>();
}