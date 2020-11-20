using RemoteTrainingApi.Users.Models;
using System.Collections.Generic;

namespace RemoteTrainingApi.Workouts.Models
{
    public class UserOnWorkout
    {
        public int UserOnWorkoutId { get; set; }
        public bool WillAttend { get; set; }
        public int WorkoutId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Workout Workout { get; set; }
        public virtual ICollection<ExerciseSet> ExerciseSets { get; set; }
    }
}
