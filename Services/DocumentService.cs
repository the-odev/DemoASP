using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Services.Models;
using System.Threading.Tasks;

namespace Services
{
    public class DocumentService : IDocumentService
    {
        private IDataContext context;
        private readonly ILogger<DocumentService> logger;
        private readonly IMemoryCache cache;

        public DocumentService(IDataContext context, IMemoryCache cache, ILogger<DocumentService> logger)
        {
            this.context = context;
            this.cache = cache;
            this.logger = logger;
        }


        public ICollection<DocumentDto> GetDocumentsOfUser(int userId)
        {
            cache.TryGetValue($"documentOfUser{userId}", out ICollection<DocumentDto> cachedDocs);
            if (cachedDocs != null)
            {
                logger.LogInformation("Cache hit");
                return cachedDocs;
            }
            else
            {
                var docs = context.Documents.Where(doc => doc.UserId == userId).Select(doc =>
                            new DocumentDto
                            {
                                DocumentName = doc.DocumentName,
                                DocumentTypeName = doc.DocumentType.DocumentTypeName
                            }).ToList();
                cache.Set($"documentOfUser{userId}", docs, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(300), // cache will expire in 300 seconds or 5 minutes
                    SlidingExpiration = TimeSpan.FromSeconds(60) // cache will expire if inactive for 60 seconds
                });
                return docs;
            }
        }


        public async Task<IEnumerable<DocumentDto>> GetDocumentsOfType(int documentTypeId)
        {

            var docs = await context.Documents.Where(doc => doc.DocumentTypeId == documentTypeId).Select(doc =>
            new DocumentDto
            {
                DocumentName = doc.DocumentName,
                DocumentTypeName = doc.DocumentType.DocumentTypeName
            }).ToListAsync();
            return docs;
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

    }
}