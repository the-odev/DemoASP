using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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

        [Authorize(Roles = "Admin, User", Policy = "AtLeast18")]
        [Route("")]
        [HttpGet]
        public IActionResult GetDocumentOfUser([FromQuery] int userId, [FromQuery] int? documentTypeId = null) {
            var result = this.documentService.GetDocumentsOfUser(userId);
            return new OkObjectResult(result);
        }


        [Route("type")]
        [HttpGet]
        public async Task<IActionResult> GetDocumentOfType([FromQuery] int documentTypeId) {
            var result = await this.documentService.GetDocumentsOfType(documentTypeId);
            return new OkObjectResult(result);
        }
    }
}