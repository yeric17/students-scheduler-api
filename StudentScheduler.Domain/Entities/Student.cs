using System.ComponentModel.DataAnnotations;

namespace StudentScheduler.Domain.Entities
{
    public class Student
    {
        [Key]
        public required string StudentId { get; set; }
        public required string UserId { get; set; }
        public required User User { get; set; }
    }
}
