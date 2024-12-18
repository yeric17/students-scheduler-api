﻿using StudentScheduler.Application.Enrollment.Requests;
using StudentScheduler.Application.Enrollment.Responses;
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
        Task<ResultValue<List<EnrollmentGetResponse>>> GetUserEnrollments();
        Task<Result> RemoveEnrollment(EnrollmentRemoveRequest request);
    }
}
