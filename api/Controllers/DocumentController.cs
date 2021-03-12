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

        public DocumentController(IDocumentService documentServcie)
        {
            this.documentService = documentServcie;
        }


        [Route("")]
        [HttpPost]
        public IActionResult CreateDocument([FromBody] CreateDocumentDto createDocumentDto)
        {
            var result = this.documentService.CreateDocument(createDocumentDto);
            return new OkObjectResult(result);
        }


        [Route("{userId}")]
        [HttpGet]
        public IActionResult GetUserDocuments(int userId)
        {
            var result = this.documentService.GetDocumentsOfUser(userId);
            return new OkObjectResult(result);
        }


    }
}