using AppCrud.Domain.Entities;
using AppCrud.Domain.Interfaces;

namespace AppCrud.Application.useCases
{
    public class CreateProductUseCase
    {
        private readonly IProductRepository _repo;

        public CreateProductUseCase(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task Execute(Product product)
        {
            if (await _repo.ExistsBySku(product.Sku))
                throw new Exception("El SKU ya existe");

            if (product.Price < 0 || product.Stock < 0)
                throw new Exception("Valores inválidos");

            await _repo.Add(product);
        }
    }
}
