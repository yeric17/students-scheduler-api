using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Application.Enrollment.Requests
{
    public class EnrollmentRemoveRequest
    {
        public required string UserId { get; set; }
        public required string SubjectAssignmentId { get; set; }
    }
}
