using System;
namespace Services.Models
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}