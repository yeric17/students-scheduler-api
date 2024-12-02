
using Microsoft.EntityFrameworkCore;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Domain.Entities;
using StudentScheduler.infrastructure.Abstractions;
using StudentScheduler.infrastructure.Data;
using StudentScheduler.Share.Abstractions;
using StudentScheduler.Share.ErrorHandling;

namespace StudentScheduler.infrastructure.Repositories
{
    internal class EnrollmentRepository : BaseEFRepository, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Result> AddEnrollment(string subjectAssignmentId, string userId)
        {
            var enrollment = new Enrollment
            {
                EnrollmentId = Guid.NewGuid().ToString(),
                StudentId = userId,
                SubjectAssignmentId = subjectAssignmentId
            };

            _dbContext.Enrollments.Add(enrollment);

            try
            {
                await _dbContext.SaveChangesAsync();
				return Result.Success();
			}
            catch (Exception e)
            {
                Console.WriteLine(e);
				return Result.Failure(EnrollmentErrors.AddEnrollmentFailure);
            }
        }

        public async Task<Result> RemoveEnrollment(string subjectAssigmentId, string userId)
        {

            try
            {

                await _dbContext.Enrollments
                    .Where(e => e.SubjectAssignmentId == subjectAssigmentId && e.StudentId == userId)
                    .ExecuteDeleteAsync();
                return Result.Success();
            }
            catch (Exception e)
            {

                return EnrollmentErrors.EronllmentConflict(e);
            }
        }

        public async Task<ResultValue<List<Enrollment>>> GetStudentEnrollments(string userId)
		{
			var results = await _dbContext.Enrollments
                .Include(e => e.SubjectAssignment)
                .Where(e => e.StudentId == userId).ToListAsync();
			if (results is null)
			{
				return new List<Enrollment>();
			}
			return results;
		}
	}
}
