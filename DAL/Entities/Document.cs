using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Document
    {
        [Key]
        [Required]
        public int DocumentId { get; set; }

        [Required]
        public string DocumentName { get; set; }

        [Required]
        public int DocumentTypeId { get; set; }


        [Required]
        public int UserId { get; set; }

        [ForeignKey("DocumentTypeId")]
        public virtual DocumentType DocumentType { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}