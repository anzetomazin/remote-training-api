namespace RemoteTrainingApi.Groups.Models
{
    public class GroupGet
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public bool? Joined { get; set; }
        public bool IsPublic { get; set; }

    }
}
