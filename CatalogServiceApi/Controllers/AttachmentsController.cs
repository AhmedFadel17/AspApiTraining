using CatalogServiceApi.Application.DTOs.ProductAttachments;
using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Application.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceApi.WebUi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IProductAttachmentsService _service;
        public AttachmentsController(IProductAttachmentsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/product/{id:int}/attachments")]
        public async Task<IActionResult> GetProductAttachments(int id)
        {
            var product = await _service.GetProductAttachments(id);
            return Ok(product);
        }

        [HttpDelete]
        [Route("api/product/{id:int}/attachments")]
        public async Task<IActionResult> DeleteProductAttachments(int id)
        {
            var product = await _service.DeleteAsync(id);
            return Ok(new { message = "Product Attachment Deleted!" });
        }

        [HttpPost]
        [Route("api/product/attachments")]
        public async Task<IActionResult> CreateProductAttachments([FromBody] CreateProductAttachmentsDto dto)
        {
            var product = await _service.CreateAsync(dto);
            return Ok(product);
        }

        [HttpGet]
        [Route("api/product/attachments/by-name")]
        public async Task<IActionResult> GetByName([FromQuery] string name, [FromQuery] int type)
        {
            var attachments = await _service.GetAttachmentsByNameAsync(name,type);
            return Ok(attachments);
        }

        [HttpGet]
        [Route("api/product/attachments")]
        public async Task<IActionResult> GetAll(
            [FromQuery] string name, 
            [FromQuery] string productName, 
            [FromQuery] string categoryName, 
            [FromQuery] decimal minProductPrice,
            [FromQuery] int minDiscountPercentage
            )
        {
            var attachments = await _service.GetAllWithFiltersAsync(name, productName, minProductPrice, minDiscountPercentage, categoryName);
            return Ok(attachments);
        }

        [HttpGet]
        [Route("api/product/attachments/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var attachment = await _service.GetByIdAsync(id);
            return Ok(attachment);
        }

        [HttpDelete]
        [Route("api/product/attachments/by-name")]
        public async Task<IActionResult> BulkDeleteByName([FromBody] AttachmentsBulkDeleteDto dto)
        {
            var deletedCount = await _service.BulkDeleteByNameAsync(dto);
            return Ok(new { message = $"{deletedCount} Product Attachment Deleted!" });
        }

        [HttpPut]
        [Route("api/product/attachments/by-name")]
        public async Task<IActionResult> BulkUpdateName([FromBody] AttachmentsBulkUpdateDto dto)
        {
            var deletedCount = await _service.BulkUpdateNameAsync(dto);
            return Ok(new { message = $"{deletedCount} Product Attachment Updated!" });
        }
    }
}
