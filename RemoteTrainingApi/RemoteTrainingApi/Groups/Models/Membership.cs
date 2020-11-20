using RemoteTrainingApi.Users.Models;
using System.Collections.Generic;

namespace RemoteTrainingApi.Groups.Models
{
    public class Membership
    {
        public int MembershipId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public int Role { get; set; }

        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}
