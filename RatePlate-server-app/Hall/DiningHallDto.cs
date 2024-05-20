using System.ComponentModel.DataAnnotations;

namespace RatePlate.Dto
{
    public class DiningHallDto
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