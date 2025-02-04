﻿using CatalogServiceApi.Application.DTOs.Products;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetByPrice([FromQuery] decimal minFrom, [FromQuery] decimal maxFrom, [FromQuery] decimal minTo, [FromQuery] decimal maxTo)
        {
            var product = await _service.GetByPriceAsync(minFrom,maxFrom,minTo,maxTo);
            return Ok(product);
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
