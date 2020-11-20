using RemoteTrainingApi.Groups.Models;
using RemoteTrainingApi.Users.Models;

namespace RemoteTrainingApi.Groups
{
    public class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int DiscussionId { get; set; }

        public virtual User User { get; set; }
        public virtual Discussion Discussion { get; set; }
    }
}
