using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RatePlate.Dto;
using RatePlate.Interface;

namespace RatePlateServerApp
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollegeController
    {
        private readonly ICollegeServices _services;
        public CollegeController(ICollegeServices services){
            _services = services;
        }


        [HttpGet("GetCollege/{id}")]
        public CollegeDto GetCollege(int id){
            return _services.GetCollegeById(id);
        }

        [HttpGet("GetPopular")]
        public List<CollegeDto> GetPopular(){
            return _services.GetMostPopular();
        }
        [HttpGet]
        public List<CollegeDto> GetColleges(){
            return _services.GetColleges();
        }

        [Authorize]
        [HttpPost]
        public bool AddCollege(string collegeName, string location)
        {
            return _services.AddCollege(collegeName, location);
        }
        
        [Authorize]
        [HttpPut("{id}")]
        public bool UpdateCollege(int id, string collegeName, string location)
        {
            return _services.UpdateCollege(id, collegeName, location);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public bool DeleteCollege(int id)
        {
            return _services.DeleteCollege(id);
        }
        
    }
}