using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RemoteTrainingApi.Workouts.Models
{
    public class WorkoutPost
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("isTemplate")]
        public bool IsTemplate { get; set; }
    }
}
