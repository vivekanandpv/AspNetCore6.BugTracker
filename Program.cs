using AspNetCore6.BugTracker.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore6.BugTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<BugTrackerContext>(config =>
            {
                config.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlLocalDb"));
            });
            
            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}