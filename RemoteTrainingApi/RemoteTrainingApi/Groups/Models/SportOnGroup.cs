namespace RemoteTrainingApi.Groups.Models
{
    public class SportOnGroup
    {
        public int SportOnGroupId { get; set; }
        public int SportId { get; set; }
        public int GroupId { get; set; }

        public virtual Sport Sport { get; set; }
        public virtual Group Group { get; set; }
    }
}
