using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatePlate.Data;
using RatePlate.Dto;
using RatePlate.Interface;
using RatePlate.Models;

namespace RatePlate.Services
{
    public class RatingServices : IRatingServices
    {
        private readonly DataContext context;
        private readonly IMapper _mapper;
        public RatingServices(DataContext context, IMapper mapper){
            this.context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<RatingDto>> GetRatingByCollege(int collegeId)
        {
            try{
                string query = $"SELECT HallId FROM DiningHalls WHERE CollegeId = {collegeId}";
                List<DiningHall> halls = await context.DiningHalls.Where(dh => dh.CollegeId == collegeId).ToListAsync();

                List<RatingDto> ratings = new List<RatingDto>();
                foreach(DiningHall hall in halls){
                    var hallRatings = await GetRatingByHall(hall.HallId);
                    ratings.AddRange(hallRatings);
                }
                
                return ratings;
            }catch(Exception err){
                Console.WriteLine(err);
                throw;
            }
        }
        public async Task<IEnumerable<RatingDto>> GetRatingByUser(int userId)
        {
            var list = await context.Ratings.Where(r => r.UserId == userId).ToListAsync();
            return list.Select(l => _mapper.Map<RatingDto>(l));
        }

        public async Task<IEnumerable<RatingDto>> GetRatingByHall(int hallId)
        {
            var ratings = await context.Ratings.Where(r => r.HallId == hallId).ToListAsync();
            return ratings.Select(r => _mapper.Map<RatingDto>(r));
        }


        public async Task<List<double>> GetRatingDetails(int hallId){
            IEnumerable<RatingDto> ratings = await GetRatingByHall(hallId);
            List<double> list = new List<double>(new double[7]);
            
            
            int count = 0;
            foreach(RatingDto r in ratings){
                count++;
                
                list[0] += r.Taste;
                list[1] += r.Atmosphere;
                list[2] += r.Location;
                list[3] += r.Service;
                list[4] += r.Cleanliness;
                list[5] += r.Menu;
                list[6] += r.Price;
            }

            for(int i=0;i<list.Count;i++){
                list[i] /= count;
                list[i] = (double)Math.Round(list[i],1);
            }
            
            return list;
        }
        
        public bool CreateRating(RatingDto rating)
        {
            
            try{
                var r = _mapper.Map<Rating>(rating);
                context.Ratings.Add(r);
                context.SaveChanges();
                
            }
            catch(Exception err){
                Console.WriteLine(err.ToString);
                return false;
            }
            
            return true;
        }

        public bool ModifyRating(RatingDto ratingDto)
        {
            var rating = context.Ratings.Find(ratingDto.RatingId);
            if (rating == null)
            {
                return false;
            }

            rating.Message = ratingDto.Message;
            rating.Score = rating.Score;
            context.SaveChanges();
            return true;
        }

        public bool DeleteRating(int ratingId)
        {
            var rating = context.Ratings.Find(ratingId);
            if (rating == null)
            {
                return false;
            }
            context.Ratings.Remove(rating);
            context.SaveChanges();
            return true;
        }
    }
}