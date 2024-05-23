using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RatePlate.Dto;
using RatePlate.Interface;
using RatePlate.Services;
using RatePlateserverapp.Userlogindto;

namespace RatePlateServerApp.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserServices _services;
        private readonly ITokenServices _tokenServices;
        public UserController(IUserServices services, ITokenServices tokenServices){
            _services = services;
            _tokenServices = tokenServices;
        }

        [HttpGet("GetUser/{id}")]
        public UserDto GetUser(int id){
            return _services.GetUser(id);
        }

        [Authorize]
        [HttpGet]
        public List<UserDto> GetUsers(){
            return _services.GetUserList();
        }

        [HttpPost]
        public UserDto AddUser([FromBody] UserSignupDto user){
            return _services.AddUser(user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto user){
            
            if(!_services.ValidateUser(user)) return BadRequest(new {message="Not Valid Credentials"});
            

            var token = _tokenServices.GenerateToken(user);
            return Ok(new {token = token, id = user.id});
        }

        [Authorize]
        [HttpPut]
        public UserDto ChangePassword(int id, string newPassword){
            return _services.ChangePassword(id, newPassword);
        }

        [Authorize]
        [HttpDelete]
        public bool DeleteUser(int id){
            return _services.DeleteUser(id);
        }


    }
}