namespace Services.Models
{
    public class CreateDocumentDto
    {
        public string DocumentName { get; set; }
        public int DocumentTypeId { get; set; }
        public int UserId { get; set; }
    }
}