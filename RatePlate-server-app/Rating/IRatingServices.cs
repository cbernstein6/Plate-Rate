using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RatePlate.Dto;
using RatePlate.Models;

namespace RatePlate.Interface
{
    public interface IRatingServices
    {
        Task<IEnumerable<RatingDto>> GetRatingByCollege(int collegeId);
        Task<IEnumerable<RatingDto>> GetRatingByHall(int hallId);
        Task<IEnumerable<RatingDto>> GetRatingByUser(int userId);
        Task<List<double>> GetRatingDetails(int hallId); 
        bool CreateRating(RatingDto rating);
        bool ModifyRating(RatingDto rating);
        bool DeleteRating(int ratingId);
    }
}