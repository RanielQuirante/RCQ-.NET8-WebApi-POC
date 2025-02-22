using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StradaTechnicalInterview.Infrastructure.Contexts;
using StradaTechnicalInterview.MappingProfiles;
using StradaTechnicalInterview.Middleware;
using StradaTechnicalInterview.Repositories.Implementations;
using StradaTechnicalInterview.Repositories.Interfaces;
using StradaTechnicalInterview.Services.Implementations;
using StradaTechnicalInterview.Services.Interfaces;
using StradaTechnicalInterview.Services.Validators;
using System.Text;

namespace StradaTechnicalInterview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Create ConfigurationManager and add configuration sources
            var configuration = new ConfigurationManager();
            configuration.SetBasePath(Directory.GetCurrentDirectory());
            configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configuration.AddEnvironmentVariables();
            configuration.AddCommandLine(args);

            // Add services to the container.
            builder.Services.AddSingleton<IConfiguration>(configuration);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });

            builder.Services.AddControllers();

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(RequestMappingProfile));
            builder.Services.AddAutoMapper(typeof(ResponseMappingProfile));

            // Add FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<UserRequestDtoValidator>();

            // Add DbContext with SQL Server provider
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly("StradaTechnicalInterview.Infrastructure")));

            // Register repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEmploymentRepository, EmploymentRepository>();

            // Register services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEmploymentService, EmploymentService>();
            builder.Services.AddTransient<IAuthService, AuthService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Add JWT Authentication
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                });
            });

            var app = builder.Build();

            app.UseAuthentication();
            app.UseMiddleware<ErrorHandlingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}