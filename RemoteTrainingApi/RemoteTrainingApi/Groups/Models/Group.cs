using RemoteTrainingApi.Workouts.Models;
using System.Collections.Generic;

namespace RemoteTrainingApi.Groups.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<Membership> Membership { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<SportOnGroup> SportsOnGroup { get; set; }
    }
}
