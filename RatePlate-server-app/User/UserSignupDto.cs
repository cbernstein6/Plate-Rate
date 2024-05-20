using System.ComponentModel.DataAnnotations;

namespace RatePlate.Dto
{
    public class UserSignupDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Redopassword { get; set; }
        
    }
}