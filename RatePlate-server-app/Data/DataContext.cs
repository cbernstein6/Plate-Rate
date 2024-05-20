using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RatePlate.Models;


namespace RatePlate.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DataContext(){} // for testing purposes
        public DbSet<College> Colleges => Set<College>();
        public DbSet<DiningHall> DiningHalls => Set<DiningHall>();
        public DbSet<Rating> Ratings => Set<Rating>();
        public virtual DbSet<User> Users => Set<User>();
    }
}