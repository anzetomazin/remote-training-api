using RemoteTrainingApi.Workouts.Models;
using System.Collections.Generic;

namespace RemoteTrainingApi.Users.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
