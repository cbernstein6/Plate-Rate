using System.ComponentModel.DataAnnotations;

namespace RatePlate.Dto
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public int NumRatings { get; set; } = 0;
    }
}