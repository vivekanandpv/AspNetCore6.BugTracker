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
using AspNetCore6.BugTracker.Extensions;

namespace AspNetCore6.BugTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddApplicationDependencies();

            var app = builder.Build();

            app.AddApplicationMiddleware();

            app.Run();
        }
    }
}