﻿using CatalogServiceApi.Application.DTOs.Categories;
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
        private readonly ICategoryServices _service;
        public CategoriesController(ICategoryServices service)
        {
            _service=service;
        }

        [HttpGet]
        [Authorize(Roles ="Manager")]
        public async Task<IActionResult> All()
        {
            //var claims = User.Claims.Select(c => new { c.Type, c.Value });
            //return Ok(claims);
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Store))]
        [Route("{id:int}")]
        public IActionResult GetById(int id) {
            var category = _service.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Customer))]
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
