using RemoteTrainingApi.Users.Models;
using System.Collections.Generic;

namespace RemoteTrainingApi.Workouts.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool IsTemplate { get; set; }

        public virtual ICollection<ExerciseOnWorkout> ExerciseOnWorkouts { get; set; }
        public virtual User User { get; set; }
    }
}
