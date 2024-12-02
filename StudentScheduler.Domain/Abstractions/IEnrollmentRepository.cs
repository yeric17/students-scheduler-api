using StudentScheduler.Domain.Entities;
using StudentScheduler.Share.Abstractions;

namespace StudentScheduler.Domain.Abstractions
{
    public interface IEnrollmentRepository
    {
        Task<Result> AddEnrollment(string enrrollmentId, string userId);
		Task<ResultValue<List<Enrollment>>> GetStudentEnrollments(string userId);
        Task<Result> RemoveEnrollment(string subjectAssigmentId, string userId);
    }
}
