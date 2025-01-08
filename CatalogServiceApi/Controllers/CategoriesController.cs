using CatalogServiceAPI.Data;
using CatalogServiceAPI.DTOs.Categories;
using CatalogServiceAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult All()
        {
            List<Category> categories = _dbContext.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id) {
            Category? category = _dbContext.Categories.Find(id);
            if (category is null) {
                return NotFound(new { message = "Category Not Found" });
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto categoryDto) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category? category=new Category { 
                Name= categoryDto.Name,
                Description= categoryDto.Description,
            };
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return Ok(category);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id,UpdateCategoryDto categoryDto) {

            Category? category = _dbContext.Categories.Find(id);
            if (category is null)
            {
                return NotFound(new { message = "Category Not Found" });
            }
            category.Name = categoryDto.Name ?? category.Name;
            category.Description = categoryDto.Description ?? category.Description;
            _dbContext.SaveChanges();
            return Ok(category);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            Category? category = _dbContext.Categories.Find(id);
            if (category is null)
            {
                return NotFound(new { message = "Category Not Found" });
            }
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return Ok(new { message = "Category Deleted!" });
        }
    }
}
