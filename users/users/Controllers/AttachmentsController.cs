using Microsoft.AspNetCore.Mvc;
using users.Services;
using users.Models;
using System.Data;

namespace users.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentsServices _attachmentsService;

        public AttachmentsController(IAttachmentsServices attachmentsService)
        {
            _attachmentsService = attachmentsService;
        }

        [HttpPost("create")]
        public IActionResult CreateAttachment([FromBody] Attachment model)
        {
            if (model == null || string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Path) || string.IsNullOrEmpty(model.DateUplode))
            {
                return BadRequest("All fields are required.");
            }

            DataTable result = _attachmentsService.CreateAttachment(model.Name, model.Path, model.DateUplode);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AttachmentWithTask model)
        {
            if (model == null || model.Attachment == null || model.Task == null)
            {
                return BadRequest("Attachment and Task are required.");
            }

            bool success = _attachmentsService.Create(model);
            if (success)
            {
                return Ok("Transaction completed successfully.");
            }
            return StatusCode(500, "Failed to process transaction.");
        }
    }
}
