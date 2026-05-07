using AppCrud.Domain.Entities;

namespace AppCrud.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int id);
        Task<bool> ExistsBySku(string sku);
    }
}
