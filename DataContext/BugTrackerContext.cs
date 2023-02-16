using AspNetCore6.BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore6.BugTracker.DataContext
{
    public class BugTrackerContext : DbContext
    {
        public BugTrackerContext(DbContextOptions<BugTrackerContext> options) : base(options)
        {
            
        }

        public DbSet<SoftwareProject> SoftwareProjects { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoftwareProject>()
                .ToTable(nameof(SoftwareProject));

            modelBuilder.Entity<Bug>()
                .ToTable(nameof(Bug));

            modelBuilder.Entity<Message>()
                .ToTable(nameof(Message));

            modelBuilder.Entity<User>()
                .ToTable("AppUser");    //  User is a keyword in SQL Server

            modelBuilder.Entity<Role>()
                .ToTable("AppRole");    //  Role is a keyword in SQL Server

            modelBuilder.Entity<UserRole>()
                .ToTable(nameof(UserRole))
                .HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}
