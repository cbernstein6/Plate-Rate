using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RatePlate.Dto;
using RatePlate.Models;

namespace RatePlate.Interface
{
    public interface IHallServices
    {
        DiningHallDto GetHallById(int id);
        void AddHall(string hallName);
        bool DeleteHall(int id);
        List<DiningHallDto> GetHallsByCollege(int collegeId);
    }
}