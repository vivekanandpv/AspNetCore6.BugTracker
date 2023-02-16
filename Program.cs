using AspNetCore6.BugTracker.Configuration;
using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Filters;
using AspNetCore6.BugTracker.Services.Implementations;
using AspNetCore6.BugTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Serilog;

namespace AspNetCore6.BugTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("app-log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            //  Logging is a fundamental feature of Asp.Net Core
            builder.Host.UseSerilog();

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

            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            var app = builder.Build();

            //  If you want this, it must come before MapControllers();
            //  Very useful feature for profiling request processing
            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "BugTracker");
            });

            app.MapControllers();

            app.Run();
        }
    }
}