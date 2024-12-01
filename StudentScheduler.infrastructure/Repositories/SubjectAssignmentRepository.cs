
using Microsoft.EntityFrameworkCore;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Domain.Entities;
using StudentScheduler.infrastructure.Abstractions;
using StudentScheduler.infrastructure.Data;
using StudentScheduler.Share.Abstractions;
using StudentScheduler.Share.ErrorHandling;

namespace StudentScheduler.infrastructure.Repositories
{
	internal class SubjectAssignmentRepository : BaseEFRepository, ISubjectAssignmentRepository
	{
		public SubjectAssignmentRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<Result> AddSubjectAssignment(string subjectId, string teacherId)
		{
			var subjectAssignment = new SubjectAssignment
			{
				SubjectAssignmentId = Guid.NewGuid().ToString(),
				SubjectId = subjectId,
				TeacherId = teacherId
			};
			_dbContext.SubjectAssignments.Add(subjectAssignment);
			try
			{
				await _dbContext.SaveChangesAsync();
				return Result.Success();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return Result.Failure(SubjectAssignmentErrors.AddSubjectAssignmentFailure);
			}
		}

		public async Task<ResultValue<List<SubjectAssignment>>> GetSubjectsAssignment()
		{
			var results = await _dbContext
				.SubjectAssignments
				.Include(sa => sa.Teacher)
				.Include(sa => sa.Subject)
				.AsSplitQuery()
				.AsNoTracking()
				.ToListAsync();
			if(results is null)
			{
				return new List<SubjectAssignment>();
			}

			return results;
		}

		public async Task<ResultValue<List<SubjectAssignment>>> GetSubjectsAssignmentByTeacherId(string teacherId)
		{
			var results = await _dbContext.SubjectAssignments.Where(sa => sa.TeacherId == teacherId).ToListAsync();

			if (results is null)
			{
				return new List<SubjectAssignment>();
			}

			return results;
		}

		public async Task<ResultValue<SubjectAssignment>> GetSubjectAssigmentById(string subjectAssignmentId)
		{
			var result = await _dbContext.SubjectAssignments
				.Include(sa => sa.Subject)
				.FirstOrDefaultAsync(sa => sa.SubjectAssignmentId == subjectAssignmentId);
			if (result is null)
			{
				return SubjectAssignmentErrors.SubjectAssignmentNotFound;
			}
			return result;
		}

		public async Task<ResultValue<List<SubjectAssignment>>> GetSubjectsAssigmentByStudentId(string studentId)
		{
			var results = await _dbContext.Enrollments
				.Include(e => e.SubjectAssignment)
				.ThenInclude(sa => sa.Enrollments)
				.Where(es => es.StudentId == studentId)
				.AsSplitQuery()
				.AsNoTracking()
				.Select(es => es.SubjectAssignment)
				.ToListAsync();

			if (results is null)
			{
				return new List<SubjectAssignment>();
			}
			return results;
		}

		public async Task<ResultValue<List<SubjectAssignment>>> GetSubjectAssigmentDetail(string subjectAssignmentId)
		{
			var results = await _dbContext.SubjectAssignments
				.Include(sa => sa.Teacher)
				.Include(sa => sa.Subject)
				.Include(sa => sa.Enrollments)
				.ThenInclude(e => e.Student)
				.Where(sa => sa.SubjectAssignmentId == subjectAssignmentId)
				.AsSplitQuery()
				.AsNoTracking()
				.ToListAsync();

			if (results is null)
			{
				return new List<SubjectAssignment>();
			}
			return results;
		}
	}
}
