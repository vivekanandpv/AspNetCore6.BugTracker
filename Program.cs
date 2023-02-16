using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Filters;
using AspNetCore6.BugTracker.Services.Implementations;
using AspNetCore6.BugTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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

            builder.Services.AddSwaggerGen(config => { config.SwaggerDoc("v1.0.0", new OpenApiInfo { Title = "BugTracker API Documentation" }); });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "BugTracker");
            });

            app.MapControllers();

            app.Run();
        }
    }
}