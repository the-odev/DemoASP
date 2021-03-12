using System.Reflection.Metadata;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }

        [Required]        
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}