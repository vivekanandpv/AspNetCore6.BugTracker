namespace AspNetCore6.BugTracker.Models;

public class User {
    public int Id { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string AvatarUrl { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public IList<UserRole> UserRoles { get; set; } = new List<UserRole>();
}