using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RemoteTrainingApi.Workouts.Models
{
    public class WorkoutPut
    {
        [Required]
        [JsonProperty("workoutId")]
        public int WorkoutId { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("isTemplate")]
        public bool IsTemplate { get; set; }
    }
}
