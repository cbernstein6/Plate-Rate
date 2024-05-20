using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RatePlate.Models
{
    public class DiningHall
    {
        [Key]
        public int HallId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public float AverageScore { get; set; } = 0;
        public int CollegeId { get; set; }
        public string ImagePath{ get; set; }
    }
}