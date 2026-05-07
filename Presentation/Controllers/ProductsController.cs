using AppCrud.Application.useCases;
using AppCrud.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppCrud.Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductUseCase _create;
        private readonly GetProductsUseCase _getAll;
        private readonly GetProductByIdUseCase _getById;

        public ProductsController(
            CreateProductUseCase create,
            GetProductsUseCase getAll,
            GetProductByIdUseCase getById)
        {
            _create = create;
            _getAll = getAll;
            _getById = getById;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _getAll.Execute();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                await _create.Execute(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _getById.Execute(id);

            if (product == null)
                return NotFound(new { message = "Producto no encontrado" });

            return Ok(product);
        }


    }
}
