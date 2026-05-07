

using AppCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Mouse Gamer",
                    Sku = "SKU-001",
                    Price = 150000,
                    Stock = 10,
                    Category = "Tecnología"
                },
                new Product
                {
                    Id = 2,
                    Name = "Teclado Mecánico",
                    Sku = "SKU-002",
                    Price = 250000,
                    Stock = 5,
                    Category = "Tecnología"
                },
                new Product
                {
                    Id = 3,
                    Name = "Monitor 24",
                    Sku = "SKU-003",
                    Price = 800000,
                    Stock = 7,
                    Category = "Tecnología"
                },
                new Product
                {
                    Id = 4,
                    Name = "Audífonos",
                    Sku = "SKU-004",
                    Price = 120000,
                    Stock = 15,
                    Category = "Audio"
                },
                new Product
                {
                    Id = 5,
                    Name = "Silla Gamer",
                    Sku = "SKU-005",
                    Price = 950000,
                    Stock = 3,
                    Category = "Muebles"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    FirstName = "Pepito",
                    LastName = "Perez",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456")
                }
    );
        }
    }
}