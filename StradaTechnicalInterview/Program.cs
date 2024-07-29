using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StradaTechnicalInterview.Infrastructure.Contexts;
using StradaTechnicalInterview.MappingProfiles;
using StradaTechnicalInterview.Repositories.Implementations;
using StradaTechnicalInterview.Repositories.Interfaces;
using StradaTechnicalInterview.Services.Implementations;
using StradaTechnicalInterview.Services.Interfaces;
using StradaTechnicalInterview.Services.Validators;

namespace StradaTechnicalInterview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(RequestMappingProfile));
            builder.Services.AddAutoMapper(typeof(ResponseMappingProfile));

            // Add FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<UserRequestDtoValidator>();

            // Add DbContext with SQL Server provider
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly("StradaTechnicalInterview.Infrastructure")));

            // Register repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEmploymentRepository, EmploymentRepository>();

            // Register services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEmploymentService, EmploymentService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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