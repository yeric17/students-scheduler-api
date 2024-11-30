using System.ComponentModel.DataAnnotations;

namespace StudentScheduler.Domain.Entities
{
    public class Enrollment
    {
        [Key]
        [StringLength(50)]
        public required string EnrollmentId { get; set; }
        public required string SubjectAssignmentId { get; set; }
        public required string StudentId { get; set; }
        
        public SubjectAssignment SubjectAssignment { get; set; }
        public User Student { get; set; }
    }
}
