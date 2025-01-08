using CatalogServiceAPI.Data;
using CatalogServiceAPI.DTOs.Categories;
using CatalogServiceAPI.DTOs.Products;
using CatalogServiceAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CatalogServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductsController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult All([FromQuery] int CurrentPage = 1, [FromQuery] int PageSize = 5)
        {
            List<Product> products = _dbContext.Products.ToList();
            int totalCount=products.Count();
            var pagedData = products
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
            var pagedResponse = new PaginateProductsDto(
            pagedData,
            totalCount,
            CurrentPage,
            PageSize
            );

            return Ok(pagedResponse);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            Product? product = _dbContext.Products.Find(id);
            if (product is null)
            {
                return NotFound(new { message = "Product Not Found" });
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto productDto)
        {
            Category? category = _dbContext.Categories.Find(productDto.CategoryId);
            if (category is null)
            {
                return NotFound(new { message = "Category Not Found" });
            }
            Product? product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                CategoryId= category.Id,
                Category=category,
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return Ok(product);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, UpdateProductDto productDto)
        {
            Product? product = _dbContext.Products.Find(id);
            if (product is null)
            {
                return NotFound(new { message = "Product Not Found" });
            }
            Category? category = _dbContext.Categories.Find(productDto.CategoryId);
            if (category is null)
            {
                return NotFound(new { message = "Category Not Found" });

            }
            product.Name = productDto.Name ?? product.Name;
            product.Description = productDto.Description ?? product.Description;
            product.CategoryId = category.Id;

            _dbContext.SaveChanges();
            return Ok(category);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            Product? product = _dbContext.Products.Find(id);
            if (product is null)
            {
                return BadRequest("Product Not Found");
            }
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return Ok(new { message="Product Deleted!"});
        }
    }
}
