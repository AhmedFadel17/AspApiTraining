using ExternalAPi.Enums;
using ExternalAPi.Interfaces;
using ExternalAPi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExternalAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentService _service;
        public AttachmentsController(IAttachmentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id:int}/media")]
        public async Task<IActionResult> GetMediaAttachments(int id)
        {
            var productAttachments = await _service.FetchAttachmentsAsync(id,AttachmentsType.Media);
            return Ok(productAttachments);
        }

        [HttpGet]
        [Route("{id:int}/discount")]
        public async Task<IActionResult> GetDiscountAttachments(int id)
        {
            var productAttachments = await _service.FetchAttachmentsAsync(id, AttachmentsType.Discount);
            return Ok(productAttachments);
        }

        [HttpGet]
        [Route("{id:int}/brand")]
        public async Task<IActionResult> GetBrandAttachments(int id)
        {
            var productAttachments = await _service.FetchAttachmentsAsync(id, AttachmentsType.Brand);
            return Ok(productAttachments);
        }
    }
}
