using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RatePlate.Dto;
using RatePlate.Models;

namespace RatePlate.Interface
{
    public interface ICollegeServices
    {
        CollegeDto GetCollegeById(int id);
        List<CollegeDto> GetMostPopular();
        List<CollegeDto> GetColleges();
        bool AddCollege(string name, string location);
        bool UpdateCollege(int id, string name, string location);
        bool DeleteCollege(int id); 
    }
}