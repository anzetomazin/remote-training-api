using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RemoteTrainingApi.Workouts.Models
{
    public class ExercisePost
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
