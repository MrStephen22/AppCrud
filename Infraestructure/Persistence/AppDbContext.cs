

using AppCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Infraestructure.Persistence
{
    public class AppDbContext: DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    }
}
