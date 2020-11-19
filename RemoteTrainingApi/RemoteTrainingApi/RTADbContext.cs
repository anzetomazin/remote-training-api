using Microsoft.EntityFrameworkCore;
using RemoteTrainingApi.Users.Models;
using RemoteTrainingApi.Workouts.Models;

namespace RemoteTrainingApi
{
    public class RTADbContext : DbContext
    {
        public RTADbContext()
        {

        }

        public RTADbContext(DbContextOptions<RTADbContext> options) : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Workout> Workout { get; set; }
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<ExerciseOnWorkout> ExerciseOnWorkout { get; set; }
        public virtual DbSet<ExerciseSet> ExerciseSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=RTADbContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
