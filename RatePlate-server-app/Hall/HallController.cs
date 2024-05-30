using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RatePlate.Dto;
using RatePlate.Interface;

namespace RatePlateServerApp.Hall
{
    [ApiController]
    [Route("api/[controller]")]
    public class HallController : ControllerBase
    {
        private readonly IHallServices _services;
        public HallController(IHallServices services){
            _services = services;
        }

        [HttpGet("{id}")]
        public ActionResult<DiningHallDto> GetHallById(int id)
        {
            var hall = _services.GetHallById(id);
            if (hall == null)
            {
                return NotFound();
            }
            return Ok(hall);
        }

        [HttpGet("CollegeHalls/{collegeId}")]
        public ActionResult<List<DiningHallDto>> GetHallsByCollege(int collegeId)
        {
            var halls = _services.GetHallsByCollege(collegeId);
            if (halls == null || halls.Count == 0)
            {
                return NotFound();
            }
            return Ok(halls);
        }

        
        [HttpPost]
        public ActionResult AddHall([FromBody] string hallName)
        {
            _services.AddHall(hallName);
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public ActionResult DeleteHall(int id)
        {
            var result = _services.DeleteHall(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
