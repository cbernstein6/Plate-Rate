using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RatePlate.Models;

namespace RatePlate.Dto.MappingProfiles
{
    public class UserMapper : Profile
    {
        public UserMapper(){
            CreateMap<User,UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<DiningHall,DiningHallDto>();
            CreateMap<College,CollegeDto>();
            CreateMap<Rating,RatingDto>();
            CreateMap<RatingDto,Rating>();
        }
    }
}