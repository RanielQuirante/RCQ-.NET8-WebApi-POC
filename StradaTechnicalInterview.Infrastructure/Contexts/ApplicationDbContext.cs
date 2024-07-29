using Microsoft.EntityFrameworkCore;
using StradaTechnicalInterview.Models.Entities;

namespace StradaTechnicalInterview.Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<EmploymentEntity> Employment { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.HasIndex(e => e.Email).IsUnique();

                entity.HasOne(e => e.Address)
                      .WithOne(a => a.User)
                      .HasForeignKey<AddressEntity>(a => a.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.Employments)
                      .WithOne(em => em.User)
                      .HasForeignKey(em => em.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AddressEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Street).IsRequired();
                entity.Property(e => e.City).IsRequired();
            });

            modelBuilder.Entity<EmploymentEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Company).IsRequired();
                entity.Property(e => e.MonthsOfExperience).IsRequired();
                entity.Property(e => e.Salary).IsRequired();
                entity.Property(e => e.StartDate).IsRequired();
            });

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new UserEntity { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
            );

            modelBuilder.Entity<AddressEntity>().HasData(
                new AddressEntity { Id = 1, Street = "123 Main St", City = "Anytown", PostCode = 12345, UserId = 1 },
                new AddressEntity { Id = 2, Street = "456 Maple Ave", City = "Othertown", PostCode = 67890, UserId = 2 }
            );

            modelBuilder.Entity<EmploymentEntity>().HasData(
                new EmploymentEntity { Id = 1, Company = "ABC Corp", MonthsOfExperience = 24, Salary = 60000, StartDate = new DateTime(2020, 1, 1), EndDate = new DateTime(2021, 1, 1), UserId = 1 },
                new EmploymentEntity { Id = 2, Company = "XYZ Inc", MonthsOfExperience = 36, Salary = 80000, StartDate = new DateTime(2019, 6, 1), EndDate = new DateTime(2020, 1, 1), UserId = 1 },
                new EmploymentEntity { Id = 3, Company = "DEF Ltd", MonthsOfExperience = 12, Salary = 50000, StartDate = new DateTime(2021, 1, 1), EndDate = new DateTime(2022, 1, 1), UserId = 2 }
            );
        }
    }
}