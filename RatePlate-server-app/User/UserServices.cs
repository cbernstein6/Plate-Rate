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



        public UserDto GetUser(int id)
        {
            var user = context.Users.Find(id);
            var userDto = mapper.Map<UserDto>(user);
            return userDto != null ? userDto : new UserDto { UserId = 1, Username = "myUserName", NumRatings = 0 }; //TODO: make sure this is right, swapped from sql query
        }

        public List<UserDto> GetUserList()
        {
            List<User> userList = context.Users.ToList();
            List<UserDto> listDto = mapper.Map<List<UserDto>>(userList);

            return listDto;
        }

        public UserDto AddUser(UserSignupDto user)
        {
            string name = user.Username, password = user.Password, pass2 = user.Redopassword;
            if(password != pass2){
                throw new ArgumentException("Passwords do not equal");
            }

            if(context.Users.Any(x => x.Username == name)) 
                throw new ArgumentException("Username is already taken");

            User newUser = new User{Username = name, HashedPassword = getHashSha256(password)};
            context.Users.Add(newUser);
            context.SaveChanges();

            return mapper.Map<UserDto>(newUser);
        }

        public bool ValidateUser(UserLoginDto userLoginDto){
            User user = context.Users.FirstOrDefault(x => x.Username == userLoginDto.UserName);
            if(user == null) return false;

            if(user.HashedPassword == getHashSha256(userLoginDto.Password)){
                userLoginDto.id = user.UserId;
                return true;
            }
            return false;
        }

        public UserDto ChangePassword(int id, string newPassword)
        {
            var user = context.Users.Find(id);
            
            if(user == null){
                throw new ArgumentException("User does not exist");
            }
            else{
                var hashed = getHashSha256(newPassword);
                user.HashedPassword = hashed;
                context.SaveChanges();
            }
            return mapper.Map<UserDto>(user);
        }

        public bool DeleteUser(int id)
        {
            var user = context.Users.Find(id);
            if(user != null){
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }else{
                return false;
            }
        }


        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] hash = sha256Hash.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}