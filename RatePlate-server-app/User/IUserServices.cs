using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RatePlate.Dto;
using RatePlate.Models;
using RatePlateserverapp.Userlogindto;

namespace RatePlate.Interface
{
    public interface IUserServices
    {
        UserDto GetUser(int id);
        List<UserDto> GetUserList();
        UserDto AddUser(UserSignupDto user);
        bool DeleteUser(int userId);
        UserDto ChangePassword(int id, string newpassword);
        bool ValidateUser(UserLoginDto userLoginDto);
    }
}