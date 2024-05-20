using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RatePlate.Dto
{
    public class RatingDto
    {
        [Key]
        public int RatingId { get; set; }
        public float Score { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public int HallId { get; set; }
        public int Taste { get; set; }
        public int Atmosphere { get; set; }
        public int Location { get; set; }
        public int Service { get; set; }
        public int Cleanliness { get; set; }
        public int Menu { get; set; }
        public int Price { get; set; }
    }
}