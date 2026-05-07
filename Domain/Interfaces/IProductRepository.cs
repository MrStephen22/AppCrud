using AppCrud.Application.DTOs;
using AppCrud.Domain.Entities;

namespace AppCrud.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<(IEnumerable<Product>, int totalRecords)>
            GetPaginatedFiltered(ProductQueryDto queryDto);
        Task<Product?> GetById(int id);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int id);
        Task<bool> ExistsBySku(string sku);
    }
}
