using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Entities;
using Services.Models;

namespace Services
{
    public class DocumentService : IDocumentService
    {
        private IDataContext context;

        public DocumentService(IDataContext context)
        {
            this.context = context;
        }


        public ICollection<DocumentDto> GetDocumentsOfUser(int userId)
        {

            var docs = context.Documents.Where(doc => doc.UserId == userId).Select(doc =>
            new DocumentDto
            {
                DocumentName = doc.DocumentName,
                DocumentTypeName = doc.DocumentType.DocumentTypeName
            }).ToList();
            return docs;
        }


        public ICollection<DocumentDto> GetDocumentsOfType(int documentTypeId)
        {

            var docs = context.Documents.Where(doc => doc.DocumentTypeId == documentTypeId).Select(doc =>
            new DocumentDto
            {
                DocumentName = doc.DocumentName,
                DocumentTypeName = doc.DocumentType.DocumentTypeName
            }).ToList();
            return docs;
        }


        public string CreateDocument(CreateDocumentDto createDocumentDto)
        {
            context.Documents.Add(new Document
            {
                DocumentName = createDocumentDto.DocumentName,
                UserId = createDocumentDto.UserId,
                DocumentTypeId = createDocumentDto.DocumentTypeId
            });
            context.SaveChanges();
            return "The document has been created";
        }
    }
}