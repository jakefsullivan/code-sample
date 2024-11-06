using System.Collections.Generic;

namespace CodingExercise.Models
{
    public class UserResponse
    {
        public List<User> Users { get; set; }
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}
