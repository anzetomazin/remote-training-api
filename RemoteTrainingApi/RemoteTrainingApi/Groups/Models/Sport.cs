using System.Collections.Generic;

namespace RemoteTrainingApi.Groups.Models
{
    public class Sport
    {
        public int SportId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SportOnGroup> SportsOnGroup { get; set; }
    }
}
