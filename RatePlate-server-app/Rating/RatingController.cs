using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RatePlate.Dto;
using RatePlate.Interface;
using RatePlate.Models;
using RatePlate.Services;

namespace RatePlateServerApp.Hall
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingServices _ratings;
        public RatingController(IRatingServices _rating){
            _ratings = _rating;
        }
        
        [HttpGet("College/{id}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetCollegeRatings(int id){
            try{
                var ratings = await _ratings.GetRatingByCollege(id);
                return Ok(ratings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("Hall/{id}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetHallRatings(int id){
            var ratings = await _ratings.GetRatingByHall(id);
            return Ok(ratings);
        }

        [HttpGet("User/{id}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetUserRatings(int id){
            var ratings = await _ratings.GetRatingByUser(id);
            return Ok(ratings);
        }

        [HttpGet("HallDetails/{id}")]
        public async Task<ActionResult<IEnumerable<double>>> GetDetails(int id){
            var ratings = await _ratings.GetRatingDetails(id);
            return Ok(ratings);
        }

        
        [HttpPost]
        public bool CreateRating([FromBody] RatingDto rating){
            return _ratings.CreateRating(rating);
        }

        
        [HttpPut]
        public bool UpdateRating([FromForm] RatingDto rating){
           return _ratings.ModifyRating(rating);
        }

        
        [HttpDelete]
        public bool DeleteRating([FromForm] int id){
            return _ratings.DeleteRating(id);
        }
    }
}