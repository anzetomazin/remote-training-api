using System.Collections.Generic;

namespace RemoteTrainingApi.Groups.Models
{
    public class Discussion
    {
        public int DiscussionId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get;set;}
        public virtual ICollection<Message> Messages { get; set; }
    }
}
