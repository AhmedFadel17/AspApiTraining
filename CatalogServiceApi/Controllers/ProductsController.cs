using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
    [Authorize(Roles = $"{nameof(UserRole.Manager)},{nameof(UserRole.Store)}")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = $"{nameof(UserRole.Manager)},{nameof(UserRole.Store)},{nameof(UserRole.Customer)}")]
        public IActionResult All()
        {
            var products = _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Authorize(Roles = $"{nameof(UserRole.Manager)},{nameof(UserRole.Store)},{nameof(UserRole.Customer)}")]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto productDto)
        {
            var product = _service.CreateAsync(productDto);
            return Ok(product);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, UpdateProductDto productDto)
        {
            var product = _service.UpdateAsync(id, productDto);
            return Ok(product);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var product = _service.DeleteAsync(id);
            return Ok(new { message="Product Deleted!"});
        }
    }
}
