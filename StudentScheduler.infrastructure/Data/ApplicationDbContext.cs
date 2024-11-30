using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentScheduler.Domain.Entities;

namespace StudentScheduler.infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public required DbSet<Subject> Subjects { get; set; }
        public required DbSet<Student> Students { get; set; }
        public required DbSet<Teacher> Teachers { get; set; }
        public required DbSet<SubjectAssignment> SubjectAssignments { get; set; }
        public required DbSet<Enrollment> Enrollments { get; set; }

        

    }
}
