using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
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
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("by-price-range")]
        public async Task<IActionResult> GetByPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var product = await _service.GetByPriceAsync(min,max);
            return Ok(product);
        }

        [HttpPost("create-many")]
        public async Task<IActionResult> CreateMany([FromBody] List<CreateProductDto> productDtos)
        {
            var products = await _service.CreateWithBatchedKeysAsync(productDtos);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            var product = await _service.CreateAsync(productDto);
            return Ok(product);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateProductDto productDto)
        {
            var product = await _service.UpdateAsync(id, productDto);
            return Ok(product);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.DeleteAsync(id);
            return Ok(new { message="Product Deleted!"});
        }
    }
}
