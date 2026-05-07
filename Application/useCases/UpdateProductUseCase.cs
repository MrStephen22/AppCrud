using AppCrud.Domain.Entities;
using AppCrud.Domain.Interfaces;

namespace AppCrud.Application.useCases
{
    public class UpdateProductUseCase
    {
        private readonly IProductRepository _repo;

        public UpdateProductUseCase(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Execute(int id, Product updatedProduct)
        {
            var existing = await _repo.GetById(id);

            if (existing == null)
                return false;

            existing.Name = updatedProduct.Name;
            existing.Sku = updatedProduct.Sku;
            existing.Price = updatedProduct.Price;
            existing.Stock = updatedProduct.Stock;
            existing.Category = updatedProduct.Category;

            await _repo.Update(existing);

            return true;
        }
    }
}
