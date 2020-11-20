using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RemoteTrainingApi.Groups.Models
{
    public class GroupPost
    {
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }
    }
}
