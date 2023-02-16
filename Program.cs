using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Filters;
using AspNetCore6.BugTracker.Services.Implementations;
using AspNetCore6.BugTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore6.BugTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(config =>
            {
                config.Filters.Add<GeneralExceptionHandlerFilter>();
            });
            builder.Services.AddDbContext<BugTrackerContext>(config =>
            {
                config.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlLocalDb"));
            });
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ISoftwareProjectService, SoftwareProjectService>();
            builder.Services.AddScoped<IBugService, BugService>();
            builder.Services.AddScoped<IMessageService, MessageService>();

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}