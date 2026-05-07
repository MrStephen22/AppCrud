using AppCrud.Application.DTOs;
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
        private readonly UpdateProductUseCase _update;
        private readonly DeleteProductUseCase _delete;

        public ProductsController(
            CreateProductUseCase create,
            GetProductsUseCase getAll,
            GetProductByIdUseCase getById,
            UpdateProductUseCase update,
            DeleteProductUseCase delete)
        {
            _create = create;
            _getAll = getAll;
            _getById = getById;
            _update = update;
            _delete = delete;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                await _create.Execute(product);

                return Created("", new ApiResponse<Product>
                {
                    Success = true,
                    Message = "Producto creado correctamente",
                    StatusCode = 201,
                    Data = product
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = 400
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] Product product)
        {
            try
            {
                var updated = await _update.Execute(id, product);

                if (!updated)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Producto no encontrado",
                        StatusCode = 404
                    });
                }

                return Ok(new ApiResponse<Product>
                {
                    Success = true,
                    Message = "Producto actualizado correctamente",
                    StatusCode = 200,
                    Data = product
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = 400
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] ProductQueryDto queryDto)
        {
            try
            {
                var result = await _getAll.Execute(queryDto);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Productos obtenidos correctamente",
                    StatusCode = 200,
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = 500
                });
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _getById.Execute(id);

            try
            {
                if (product == null)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Producto no encontrado",
                        StatusCode = 404
                    });
                }

                return Ok(new ApiResponse<Product>
                {
                    Success = true,
                    Message = "Producto obtenido correctamente",
                    StatusCode = 200,
                    Data = product
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = 400
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _delete.Execute(id);

            try
            {
                if (!deleted)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Producto no encontrado",
                        StatusCode = 404
                    });
                }

                return Ok(new ApiResponse<Product>
                {
                    Success = true,
                    Message = "Producto eliminado correctamente",
                    StatusCode = 200,
                });
            }
            catch (Exception ex) {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    StatusCode = 400
                });
            }

        }
    }
}
