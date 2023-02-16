using AspNetCore6.BugTracker.Configuration;
using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Filters;
using AspNetCore6.BugTracker.Services.Implementations;
using AspNetCore6.BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

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
            builder.Services.AddScoped<IDashboardService, DashboardService>();

            builder.Services.AddSwaggerGen(config => { config.SwaggerDoc("v1.0.0", new OpenApiInfo { Title = "BugTracker API Documentation" }); });

            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:JwtSecret").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddAuthorization(options => {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Roles", "Admin"));
                options.AddPolicy("User", policy => policy.RequireClaim("Roles", "User", "Admin"));
            });

            var app = builder.Build();

            //  If you want this, it must come before MapControllers();
            //  Very useful feature for profiling request processing
            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "BugTracker");
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}