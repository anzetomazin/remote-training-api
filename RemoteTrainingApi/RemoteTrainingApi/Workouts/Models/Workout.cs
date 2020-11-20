using System.Collections.Generic;

namespace RemoteTrainingApi.Workouts.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool IsTemplate { get; set; }
        public int? GroupId { get; set; }

        public virtual ICollection<ExerciseOnWorkout> ExerciseOnWorkouts { get; set; }
        public virtual ICollection<UserOnWorkout> UsersOnWorkout { get; set; }
    }
}
