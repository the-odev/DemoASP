using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Entities;
using Services.Models;

namespace Services
{
    public class DocumentService : IDocumentService
    {
        private IDataContext context { get; set; }

        public DocumentService(IDataContext context)
        {
            this.context = context;
        }




        public string CreateDocument(CreateDocumentDto createDocumentDto)
        {
            context.Documents.Add(new Document
            {
                DocumentName = createDocumentDto.DocumentName,
                DocumentTypeId = createDocumentDto.DocumentTypeId,
                UserId = createDocumentDto.UserId
            });
            context.SaveChanges();
            return "Document Created";
        }

        public ICollection<DocumentDto> GetDocumentsOfUser(int userId)
        {
            var result = context.Documents.Where(d => d.UserId == userId).Select(d =>
                new DocumentDto
                {
                    DocumentName = d.DocumentName,
                    DocumentTypeName = d.DocumentType.DocumentTypeName,
                }).ToList();
            return result;
        }

    }
}