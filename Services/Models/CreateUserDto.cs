using System;

namespace Services.Models
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime? DateOfBirth { get;set;}
    }
}