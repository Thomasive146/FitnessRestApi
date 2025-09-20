using Microsoft.EntityFrameworkCore;

namespace FitnessRestApi.Data
{
    public class FitnessContext : DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options)
        {
        }
        public DbSet<FitnessRestApi.Models.Session> Sessions { get; set; }
        public DbSet<FitnessRestApi.Models.Exercise> Exercises { get; set; }
        public DbSet<FitnessRestApi.Models.Workout> Workouts { get; set; }
    }
}
