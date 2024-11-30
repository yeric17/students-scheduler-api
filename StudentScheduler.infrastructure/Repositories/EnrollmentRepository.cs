using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentScheduler.Domain.Abstractions;
using StudentScheduler.Domain.Entities;
using StudentScheduler.infrastructure.Abstractions;
using StudentScheduler.infrastructure.Data;

namespace StudentScheduler.infrastructure.Repositories
{
    internal class EnrollmentRepository : BaseEFRepository, IEnrollmentRepository
    {
        public EnrollmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddEnrollment(string enrrollmentId, string userId)
        {
            var enrollment = new Enrollment
            {
                EnrollmentId = Guid.NewGuid().ToString(),
                StudentId = userId,
                SubjectAssignmentId = enrrollmentId
            };

            _dbContext.Enrollments.Add(enrollment);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error while adding enrollment.", e);
            }
        }
    }
}
