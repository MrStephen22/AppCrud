using AppCrud.Domain.Entities;
using AppCrud.Domain.Interfaces;
using AppCrud.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Infraestructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll()
        => await _context.Products.ToListAsync();

        public async Task<Product?> GetById(int id)
            => await _context.Products.FindAsync(id);

        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsBySku(string sku)
            => await _context.Products.AnyAsync(p => p.Sku == sku);
    }
}
