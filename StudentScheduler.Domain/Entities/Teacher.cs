using System.ComponentModel.DataAnnotations;

namespace StudentScheduler.Domain.Entities
{
    public class Teacher
    {
        [Key]
        public required string TeacherId { get; set; }

        public required string UserId { get; set; }
        public required User User { get; set; }
    }
}
