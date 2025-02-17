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
            return Ok(product);
        }

        [HttpPost]
        [Route("api/product/attachments")]
        public async Task<IActionResult> CreateProductAttachments([FromBody] CreateProductAttachmentsDto dto)
        {
            var product = await _service.CreateAsync(dto);
            return Ok(product);
        }

        [HttpGet]
        [Route("api/product/attachments")]
        public async Task<IActionResult> GetByName([FromQuery] string name, [FromQuery] int type)
        {
            var attachments = await _service.GetAttachmentsByNameAsync(name,type);
            return Ok(attachments);
        }
    }
}
