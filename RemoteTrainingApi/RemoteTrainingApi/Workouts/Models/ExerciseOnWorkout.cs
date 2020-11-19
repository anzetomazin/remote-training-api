using System.Collections.Generic;

namespace RemoteTrainingApi.Workouts.Models
{
    public class ExerciseOnWorkout
    {
        public int ExerciseOnWorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public int WorkoutId { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual Workout Workout { get; set; }
        public virtual ICollection<ExerciseSet> ExerciseSets { get; set; }
    }
}
