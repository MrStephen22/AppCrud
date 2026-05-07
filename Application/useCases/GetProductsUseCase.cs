using AppCrud.Application.DTOs;
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

        public async Task<object> Execute(ProductQueryDto queryDto)
        {
            if (queryDto.Page <= 0)
                queryDto.Page = 1;

            if (queryDto.Limit <= 0 || queryDto.Limit > 50)
                queryDto.Limit = 10;

            var (products, totalRecords) =
                await _repo.GetPaginatedFiltered(queryDto);

            return new
            {
                data = products,
                totalRecords,
                page = queryDto.Page,
                limit = queryDto.Limit,
                totalPages = (int)Math.Ceiling(
                    (double)totalRecords / queryDto.Limit)
            };
        }

    }
}
