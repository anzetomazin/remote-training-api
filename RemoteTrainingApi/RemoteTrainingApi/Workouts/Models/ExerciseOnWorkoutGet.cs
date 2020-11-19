using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RemoteTrainingApi.Workouts.Models
{
    public class ExerciseOnWorkoutGet
    {
        [Required]
        [JsonProperty("exerciseOnWorkoutId")]
        public int ExerciseOnWorkoutId { get; set; }

        [Required]
        [JsonProperty("exerciseName")]
        public string ExerciseName { get; set; }
    }
}
