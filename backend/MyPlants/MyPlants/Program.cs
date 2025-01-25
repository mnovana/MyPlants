using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using MyPlants.Models;
using MyPlants.Services;
using MyPlants.Interfaces;
using MyPlants.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyPlants.Repositories;
using MyPlants.Models.DTOs;

namespace MyPlants
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Database for EF  
            builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(ConfigurationExtensions.GetConnectionString(builder.Configuration, "AppConnectionString")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                    });
            });

            // HttpClient
            builder.Services.AddHttpClient<IAuthenticationService, FirebaseAuthenticationService>(httpClient =>
                httpClient.BaseAddress = new Uri(builder.Configuration["AUTHENTICATION_SIGNINURI"])
            );

            // HttpContextAccessor
            builder.Services.AddHttpContextAccessor();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Services
            builder.Services.AddScoped<IPlantService, PlantService>();
            builder.Services.AddScoped<IWateringService, WateringService>();

            // Repositories
            builder.Services.AddScoped<IPlantRepository, PlantRepository>();
            builder.Services.AddScoped<IWateringRepository, WateringRepository>();

            // IMiddleware
            builder.Services.AddScoped<GlobalExceptionHandlingMiddleware>();

            // Firebase
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("firebase.json")
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = builder.Configuration["AUTHENTICATION_ISSUER"];
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["AUTHENTICATION_ISSUER"],
                        ValidAudience = builder.Configuration["AUTHENTICATION_AUDIENCE"],
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
