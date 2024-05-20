using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RatePlate.Dto;
using RatePlateserverapp.Userlogindto;
using RatePlateServerApp.User;

namespace RatePlate.Interface
{
    public interface ITokenServices
    {
        string GenerateToken(UserLoginDto user);
    }
}