using System.Collections.Generic;
using Services.Models;

namespace Services
{
    public interface IDocumentService
    {
         string CreateDocument(CreateDocumentDto createDocumentDto);

         ICollection<DocumentDto> GetDocumentsOfUser(int userId);
    }
}