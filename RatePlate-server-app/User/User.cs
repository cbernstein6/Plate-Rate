using System.ComponentModel.DataAnnotations;

namespace RatePlate.Models
{
    public class User{
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public int NumRatings { get; set; } = 0;
    }
}