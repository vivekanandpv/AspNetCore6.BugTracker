using AspNetCore6.BugTracker.Configuration;
using AspNetCore6.BugTracker.DataContext;
using AspNetCore6.BugTracker.Filters;
using AspNetCore6.BugTracker.Services.Implementations;
using AspNetCore6.BugTracker.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AspNetCore6.BugTracker.Extensions
{
    public static class ApplicationGeneralExtensions
    {
        public static WebApplicationBuilder AddApplicationDependencies(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("app-log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            //  Logging is a fundamental feature of Asp.Net Core
            builder.Host.UseSerilog();

            builder.Services
                .AddControllersConfigured()
                .AddServices()
                .AddModelConfiguration(builder)
                .AddCorsConfigured(builder)
                .AddDataContextConfigured(builder)
                .AddSwaggerConfigured(builder)
                .AddAuthConfigured(builder)
                .AddCorsConfigured(builder);

            return builder;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISoftwareProjectService, SoftwareProjectService>();
            services.AddScoped<IBugService, BugService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IDashboardService, DashboardService>();

            return services;
        }

        private static IServiceCollection AddControllersConfigured(this IServiceCollection services)
        {
            services
                .AddControllers(config => 
                {
                    config.Filters.Add<GeneralExceptionHandlerFilter>();
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            return services;
        }

        private static IServiceCollection AddDataContextConfigured(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<BugTrackerContext>(config =>
            {
                config.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlLocalDb"));
            });

            return services;
        }

        private static IServiceCollection AddModelConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            return services;
        }

        private static IServiceCollection AddAuthConfigured(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:JwtSecret").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Roles", "Admin"));
                options.AddPolicy("User", policy => policy.RequireClaim("Roles", "User", "Admin"));
            });

            return services;
        }

        private static IServiceCollection AddCorsConfigured(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AppCorsPolicy", config =>
                {
                    config
                        .WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>())
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return services;
        }

        private static IServiceCollection AddSwaggerConfigured(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(config => { config.SwaggerDoc("v1.0.0", new OpenApiInfo { Title = "BugTracker API Documentation" }); });

            return services;
        }

        public static WebApplication AddApplicationMiddleware(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "BugTracker");
            });

            app.UseCors("AppCorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
