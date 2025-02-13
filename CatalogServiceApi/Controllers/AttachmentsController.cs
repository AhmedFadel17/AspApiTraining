using CatalogServiceApi.Application.Interfaces.Products;
using CatalogServiceApi.Application.Services.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogServiceApi.WebUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IProductAttachmentsService _service;
        public AttachmentsController(IProductAttachmentsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetProductAttachments(id);
            return Ok(product);
        }
    }
}
