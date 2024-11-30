using System.ComponentModel.DataAnnotations;

namespace StudentScheduler.Domain.Entities
{
    public class Enrollment
    {
        [Key]
        public required string EnrollmentId { get; set; }
        public required string SubjectAssignmentId { get; set; }
        public required string StudentId { get; set; }
        
        public required SubjectAssignment SubjectAssignment { get; set; }
        public required Student Student { get; set; }
    }
}
