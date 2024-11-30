namespace StudentScheduler.Domain.Entities
{
    public class SubjectAssignment
    {
        public required string SubjectAssignmentId { get; set; }
        public required Subject Subject { get; set; }
        public required Teacher Teacher { get; set; }
        public required string SubjectId { get; set; }
        public required string TeacherId { get; set; }

    }

}
