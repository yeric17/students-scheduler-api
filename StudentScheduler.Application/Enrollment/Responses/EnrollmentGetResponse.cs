using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Application.Enrollment.Responses
{
    public class EnrollmentGetResponse
    {
        public required string EnrollmentId { get; set; }
        public required string SubjectAssignmentId { get; set; }
        public required string StudentId { get; set; }
    }
}
