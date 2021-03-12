using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Models;

namespace Services
{
    public interface IDocumentService
    {
        string CreateDocument(CreateDocumentDto createDocumentDto);

        ICollection<DocumentDto> GetDocumentsOfUser(int userId);

        Task<IEnumerable<DocumentDto>> GetDocumentsOfType(int documentTypeId);
    }
}