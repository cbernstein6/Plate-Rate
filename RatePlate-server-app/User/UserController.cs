using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RatePlate.Dto;
using RatePlate.Interface;

namespace RatePlateServerApp.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserServices _services;
        public UserController(IUserServices services){
            _services = services;
        }

        [HttpGet("GetUser/{email}")]
        public int GetUser(string email){
            UserDto user = _services.GetUser(email);
            return user == null ? -1 : user.UserId;
        }

        [HttpGet]
        public List<UserDto> GetUsers(){
            return _services.GetUserList();
        }

        [HttpPost]
        public int CreateUser([FromBody] UserDto user){
            return _services.CreateUser(user);
        }


        



    }
}