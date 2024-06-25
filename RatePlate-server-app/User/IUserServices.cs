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
        UserDto GetUser(string email);
        List<UserDto> GetUserList();
        int CreateUser(UserDto user);
        string GetRole(int id);
        void UpdateUser(UserDto userDto);
    }
}