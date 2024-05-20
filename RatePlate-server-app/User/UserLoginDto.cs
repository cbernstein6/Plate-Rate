using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RatePlateserverapp.Userlogindto
{
    public class UserLoginDto
    {
        [Key]
        public int id { get; set; } = -1;
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}