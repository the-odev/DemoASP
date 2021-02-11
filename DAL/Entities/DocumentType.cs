using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class DocumentType
    {
        [Key]
        [Required]
        public int DocumentTypeId { get; set; }

        [Required]
        public string DocumentTypeName { get; set; }
    }
}