using System.ComponentModel.DataAnnotations;

namespace RatePlate.Dto
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }
        public string Email {get; set; }
        public string FirstName {get; set; }
        public string LastName {get; set; }
        public string Picture { get; set; }
        public string Role{ get; set; }
    }
}