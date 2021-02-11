using System.Collections.Generic;
using Services.Models;

namespace Services
{
    public interface IDocumentService
    {
        string CreateDocument(CreateDocumentDto createDocumentDto);

        ICollection<DocumentDto> GetDocumentsOfUser(int userId);

        ICollection<DocumentDto> GetDocumentsOfType(int documentTypeId);
    }
}