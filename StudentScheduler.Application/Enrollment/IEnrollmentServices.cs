using StudentScheduler.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Application.Enrollment
{
	public interface IEnrollmentServices
	{
		Task<Result> AddEnrollment(string subjectAssignmentId, string studentId);
	}
}
