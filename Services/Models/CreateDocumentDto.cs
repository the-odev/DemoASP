namespace Services.Models
{
    public class CreateDocumentDto
    {
        public string DocumentName { get; set; }

        public short DocumentTypeId { get; set; }

        public int UserId { get; set; }
    }
}