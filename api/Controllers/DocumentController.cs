using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("document")]
    public class DocumentController
    {
        private readonly IDocumentService documentService;

        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        [Route("")]
        [HttpPost]
        public IActionResult CreateDocument([FromBody] CreateDocumentDto createDocumentDto)
        {
            var result = this.documentService.CreateDocument(createDocumentDto);
            return new OkObjectResult(result);
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetDocumentOfUser([FromQuery] int userId, [FromQuery] int? documentTypeId = null) {
            var result = this.documentService.GetDocumentsOfUser(userId);
            return new OkObjectResult(result);
        }


        [Route("type")]
        [HttpGet]
        public IActionResult GetDocumentOfType([FromQuery] int documentTypeId) {
            var result = this.documentService.GetDocumentsOfType(documentTypeId);
            return new OkObjectResult(result);
        }
    }
}