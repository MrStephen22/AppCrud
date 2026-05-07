using AppCrud.Domain.Entities;
using AppCrud.Domain.Interfaces;

namespace AppCrud.Application.useCases
{
    public class GetProductsUseCase
    {
        private readonly IProductRepository _repo;

        public GetProductsUseCase(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> Execute()
            => await _repo.GetAll();

    }
}
