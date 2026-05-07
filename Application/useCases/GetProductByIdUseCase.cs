using AppCrud.Domain.Entities;
using AppCrud.Domain.Interfaces;

namespace AppCrud.Application.useCases
{
    public class GetProductByIdUseCase
    {
        private readonly IProductRepository _repo;

        public GetProductByIdUseCase(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Product?> Execute(int id)
        {
            return await _repo.GetById(id);
        }
    
    }
}

