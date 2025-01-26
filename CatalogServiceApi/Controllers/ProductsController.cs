using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult All()
        {
            var products = _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
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
