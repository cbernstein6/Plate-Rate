using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RatePlate.Data;
using RatePlate.Dto;
using RatePlate.Interface;
using RatePlate.Models;


namespace RatePlate.Services
{
    public class HallServices : IHallServices
    {

        private readonly DataContext context;
        private readonly IMapper _mapper;
        public HallServices(DataContext context, IMapper mapper){
            this.context = context;
            this._mapper = mapper;
        }
        
        public void AddHall(string hallName)
        {
            var hall = new DiningHall { Name = hallName };
            context.DiningHalls.Add(hall);
            context.SaveChanges();
            // return _mapper.Map<DiningHallDto>(hall);
        }

        public bool DeleteHall(int id)
        {
            var hall = context.DiningHalls.Find(id);
            if (hall == null)
            {
                return false;
            }
            context.DiningHalls.Remove(hall);
            context.SaveChanges();
            return true;
        }

        public DiningHallDto GetHallById(int id)
        {
            return _mapper.Map<DiningHallDto>(context.DiningHalls.Find(id));
        }

        public List<DiningHallDto> GetHallsByCollege(int collegeId)
        {
            var list = context.DiningHalls.Where(h => h.CollegeId == collegeId).ToList();
            return list.Select(h => _mapper.Map<DiningHallDto>(h)).ToList();
        }
    }
}