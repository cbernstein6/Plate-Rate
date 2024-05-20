using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RatePlate.Data;
using RatePlate.Dto;
using RatePlate.Interface;
using RatePlate.Models;

namespace RatePlate.Services
{
    public class CollegeServices : ICollegeServices
    {

        private readonly DataContext context;
        private readonly IMapper _mapper;
        public CollegeServices(DataContext context, IMapper mapper){
            this.context = context;
            this._mapper = mapper;
        }

        public CollegeDto GetCollegeById(int id)
        {
            return _mapper.Map<CollegeDto>(context.Colleges.Find(id));
        }

        public List<CollegeDto> GetMostPopular()
        {
            // First, get ratings grouped by HallId and count them
            var hallRatings = context.Ratings
                                    .GroupBy(r => r.HallId)
                                    .Select(group => new
                                    {
                                        HallId = group.Key,
                                        RatingCount = group.Count()
                                    })
                                    .ToList();

            // Now, join this with the Halls to get the CollegeId
            var collegeRatingCounts = hallRatings
                                    .Join(context.DiningHalls, // Join with the Halls table
                                            rating => rating.HallId, // HallId from the ratings grouping
                                            hall => hall.HallId, // HallId in the Halls table
                                            (rating, hall) => new { hall.CollegeId, rating.RatingCount })
                                    .GroupBy(x => x.CollegeId) // Now group by CollegeId
                                    .Select(group => new
                                    {
                                        CollegeId = group.Key,
                                        TotalRatings = group.Sum(x => x.RatingCount) // Sum up all the ratings for each college
                                    })
                                    .OrderByDescending(x => x.TotalRatings)
                                    .Take(5)
                                    .ToList();

            // Fetch the corresponding colleges for the top 5 rating counts
            List<CollegeDto> popularColleges = collegeRatingCounts
                                            .Select(x => context.Colleges.Find(x.CollegeId))
                                            .Select(x => _mapper.Map<CollegeDto>(x))
                                            .ToList();

            return popularColleges;
        }

        public List<CollegeDto> GetColleges()
        {
            return context.Colleges.Select(c => _mapper.Map<CollegeDto>(c)).ToList();
        }

        public bool AddCollege(string collegeName, string location)
        {
            var college = new College { Name = collegeName , Location = location };
            context.Colleges.Add(college);
            context.SaveChanges();
            return true;
        }

        public bool UpdateCollege(int id, string collegeName, string location){
            var college = context.Colleges.Find(id);
            if (college == null) return false;
            
            college.Name = collegeName;
            college.Location = location;
            context.SaveChanges();

            return true;
        }

        public bool DeleteCollege(int id)
        {
            var college = context.Colleges.Find(id);
            if (college == null)
            {
                return false;
            }
            context.Colleges.Remove(college);
            context.SaveChanges();
            return true;
        }

        

    }
}