namespace RemoteTrainingApi.Workouts.Models
{
    public class ExerciseSet
    {
        public int ExerciseSetId { get; set; }
        public int Repetitions { get; set; }
        public int Weight { get; set; }
        public int DurationSeconds { get; set; }
        public int PauseSeconds { get; set; }
        public bool IsCompleted { get; set; }
        public int ExerciseOnWorkoutId { get; set; }

        public virtual ExerciseOnWorkout ExerciseOnWorkout { get; set; }
    }
}
