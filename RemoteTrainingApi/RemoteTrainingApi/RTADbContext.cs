using Microsoft.EntityFrameworkCore;
using RemoteTrainingApi.Groups;
using RemoteTrainingApi.Groups.Models;
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
        public virtual DbSet<UserOnWorkout> UserOnWorkout { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Discussion> Discussion { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Membership> Membership { get; set; }

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
