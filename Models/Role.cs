namespace AspNetCore6.BugTracker.Models;

public class Role {
    public int RoleId { get; set; }
    public string Name { get; set; }
        
    public IList<UserRole> UserRoles { get; set; } = new List<UserRole>();
}