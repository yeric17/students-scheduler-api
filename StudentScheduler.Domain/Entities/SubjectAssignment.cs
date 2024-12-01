using System.ComponentModel.DataAnnotations;

namespace StudentScheduler.Domain.Entities
{
    public class SubjectAssignment
    {
        [Key]
        [StringLength(50)]
        public required string SubjectAssignmentId { get; set; }
        public Subject Subject { get; set; }
        public User Teacher { get; set; }
        public required string SubjectId { get; set; }
        public required string TeacherId { get; set; }

        public List<Enrollment> Enrollments { get; set; }
        public List<User> Students { get; set; }
	}

}
