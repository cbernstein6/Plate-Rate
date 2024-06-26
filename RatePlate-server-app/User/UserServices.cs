using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RatePlate.Data;
using RatePlate.Models;
using System.Security.Cryptography;
using RatePlate.Dto;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using RatePlateserverapp.Userlogindto;
using RatePlate.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RatePlate.Services
{
    public class UserServices : IUserServices
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public UserServices(DataContext context, IMapper mapper){
            this.context = context;
            this.mapper = mapper;
        }



        public UserDto GetUser(string email)
        {
            var user = context.Users.FirstOrDefault(e => e.Email == email);

            if(user == null) 
                return null;

            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }

        public List<UserDto> GetUserList()
        {
            List<User> userList = context.Users.ToList();
            List<UserDto> listDto = mapper.Map<List<UserDto>>(userList);

            return listDto;
        }

        
        public int CreateUser(UserDto userDto){
            var user = mapper.Map<User>(userDto);
            context.Users.Add(user);
            context.SaveChanges();

            return GetUser(userDto.Email).UserId;    
        }
        
        public string GetRole(int id){
            return this.context.Users.Find(id).Role;
        }
        
        public void UpdateUser(UserDto userDto){
            var newUser = mapper.Map<User>(userDto);
            User user = context.Users.Find(newUser.UserId);

            user.Email = newUser.Email;
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.Picture = newUser.Picture;
            user.Role = newUser.Role;
            
            context.SaveChanges();
        }

        
    }
}