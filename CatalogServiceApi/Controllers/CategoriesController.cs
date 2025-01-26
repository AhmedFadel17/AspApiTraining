using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _service;
        public CategoriesController(CategoryService service)
        {
            _service=service;
        }

        [HttpGet]
        public IActionResult All()
        {
            var categories = _service.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id) {
            var category = _service.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto categoryDto) 
        {
            var category=_service.CreateAsync(categoryDto);
            return Ok(category);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id,UpdateCategoryDto categoryDto) 
        {
            var category = _service.UpdateAsync(id, categoryDto);
            return Ok(category);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var category = _service.DeleteAsync(id);
            return Ok(new { message = "Category Deleted!" });
        }
    }
}
