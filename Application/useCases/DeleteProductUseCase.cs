using AppCrud.Domain.Interfaces;

namespace AppCrud.Application.useCases
{
    public class DeleteProductUseCase
    {
        private readonly IProductRepository _repo;

        public DeleteProductUseCase(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Execute(int id)
        {
            var product = await _repo.GetById(id);

            if (product == null)
                return false;

            await _repo.Delete(id);

            return true;
        }
    }
}
