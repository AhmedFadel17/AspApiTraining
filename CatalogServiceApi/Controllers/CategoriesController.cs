using CatalogServiceApi.Application.DTOs.Categories;
using CatalogServiceApi.Application.Interfaces.Categories;
using CatalogServiceApi.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service=service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id) {
            var category =await _service.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        //[Authorize(Roles = $"{nameof(UserRole.Manager)},{nameof(UserRole.Store)}")]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto) 
        {
            var category=await _service.CreateAsync(categoryDto);
            return Ok(category);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = $"{nameof(UserRole.Manager)},{nameof(UserRole.Store)}")]
        public async Task<IActionResult> Update(int id,UpdateCategoryDto categoryDto) 
        {
            var category = await _service.UpdateAsync(id, categoryDto);
            return Ok(category);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = nameof(UserRole.Manager))]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _service.DeleteAsync(id);
            return Ok(new { message = "Category Deleted!" });
        }
    }
}
