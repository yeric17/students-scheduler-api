using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        public required DbSet<SubjectAssignment> SubjectAssignments { get; set; }
        public required DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RenameIdentityTables(modelBuilder);

            AddInitialData(modelBuilder);

        }

        private void AddInitialData(ModelBuilder modelBuilder) {

            var subjects = SeedSubjects(modelBuilder);
            var roles = SeedRoles(modelBuilder);
            var teachers = SeedTeachers(modelBuilder);
            SeedTeacherRoles(modelBuilder, teachers, roles);
            SeedSubjectAssignments(modelBuilder, teachers, subjects);
        }

        private List<Subject> SeedSubjects(ModelBuilder modelBuilder)
        {
            List<Subject> subjects = new()
            {
                new Subject { SubjectId = Guid.NewGuid().ToString(), Name = "Introducción a la Programación", Description = "Introducción a la Programación", Credits = 3, Image = "images/Introduccion-a-la-programacion.jpg" },
                new Subject { SubjectId = Guid.NewGuid().ToString(), Name = "Estructuras de Datos y Algoritmos", Description = "Estructuras de Datos y Algoritmos", Credits = 3, Image = "images/estructura-de-datos-algorithmos.jpg" },
                new Subject { SubjectId = Guid.NewGuid().ToString(), Name = "Sistemas de Gestión de Bases de Datos", Description = "Sistemas de Gestión de Bases de Datos", Credits = 3, Image = "images/sistema-gestion-bases-datos.jpg"},
                new Subject { SubjectId = Guid.NewGuid().ToString(), Name = "Ingeniería de Software", Description = "Ingeniería de Software", Credits = 3, Image = "images/ingenieria-software.jpg" },
                new Subject { SubjectId = Guid.NewGuid().ToString(), Name = "Desarrollo Web", Description = "Desarrollo Web", Credits = 3, Image = "images/desarrollo-web.jpg" },
                new Subject { SubjectId = Guid.NewGuid().ToString(), Name = "Desarrollo de Aplicaciones Móviles", Description = "Desarrollo de Aplicaciones Móviles", Credits = 3, Image = "images/aplicaciones-moviles.jpg" },
                new Subject { SubjectId = Guid.NewGuid().ToString(), Name = "Computación en la Nube", Description = "Computación en la Nube", Credits = 3, Image= "images/computacion-en-la-nube.jpg" },
                new Subject { SubjectId = Guid.NewGuid().ToString(), Name = "Inteligencia Artificial y Aprendizaje Automático", Description = "Inteligencia Artificial y Aprendizaje Automático", Credits = 3, Image ="images/inteligencia-artificial.jpg" },
                new Subject { SubjectId = Guid.NewGuid().ToString(), Name = "Fundamentos de Ciberseguridad", Description = "Fundamentos de Ciberseguridad", Credits = 3, Image = "images/ciberseguridad.jpg" },
                new Subject { SubjectId = Guid.NewGuid().ToString(), Name = "Control de Versiones y Herramientas de Colaboración", Description = "Control de Versiones y Herramientas de Colaboración", Credits = 3, Image = "images/contol-de-versiones-herramientas.jpg" }
            };

            modelBuilder.Entity<Subject>().HasData(subjects);

            return subjects;
        }

        private List<IdentityRole> SeedRoles(ModelBuilder modelBuilder)
        {
            List<IdentityRole> roles = new()
            {
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Student", NormalizedName = "STUDENT" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Teacher", NormalizedName = "TEACHER" }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
            return roles;
        }
    

        private List<User> SeedTeachers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();

            User teacher1 = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "JuanPerez",
                FirstName = "Juan",
                LastName = "Pérez",
                NormalizedUserName = "JUANPEREZ",
                Email = "juan.perez@inventado.com",
                NormalizedEmail = "JUAN.PEREZ@INVENTADO.COM",
                EmailConfirmed = true,
            };

            User teacher2 = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "MariaGonzalez",
                FirstName = "María",
                LastName = "González",
                NormalizedUserName = "MARIAGONZALEZ",
                Email = "maria.gonzalez@inventado.com",
                NormalizedEmail = "MARIA.GONZALEZ@INVENTADO.COM",
                EmailConfirmed = true,
            };

            User teacher3 = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "CarlosRamirez",
                FirstName = "Carlos",
                LastName = "Ramírez",
                NormalizedUserName = "CARLOSRAMIREZ",
                Email = "carlos.ramirez@inventado.com",
                NormalizedEmail = "CARLOS.RAMIREZ@INVENTADO.COM",
                EmailConfirmed = true,
            };

            User teacher4 = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "AnaMartinez",
                FirstName = "Ana",
                LastName = "Martínez",
                NormalizedUserName = "ANAMARTINEZ",
                Email = "ana.martinez@inventado.com",
                NormalizedEmail = "ANA.MARTINEZ@INVENTADO.COM",
                EmailConfirmed = true,
            };

            User teacher5 = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "LuisFernandez",
                FirstName = "Luis",
                LastName = "Fernández",
                NormalizedUserName = "LUISFERNANDEZ",
                Email = "luis.fernandez@inventado.com",
                NormalizedEmail = "LUIS.FERNANDEZ@INVENTADO.COM",
                EmailConfirmed = true,
            };


            teacher1.PasswordHash = hasher.HashPassword(teacher1, "Teacher1@123");
            teacher2.PasswordHash = hasher.HashPassword(teacher2, "Teacher2@123");
            teacher3.PasswordHash = hasher.HashPassword(teacher3, "Teacher3@123");
            teacher4.PasswordHash = hasher.HashPassword(teacher4, "Teacher4@123");
            teacher5.PasswordHash = hasher.HashPassword(teacher5, "Teacher5@123");


            var usersList = new List<User>(5);

            usersList.Add(teacher1);
            usersList.Add(teacher2);
            usersList.Add(teacher3);
            usersList.Add(teacher4);
            usersList.Add(teacher5);

            modelBuilder.Entity<User>().HasData(usersList);

            return usersList;
        }

        private void SeedTeacherRoles(ModelBuilder modelBuilder, List<User> users, List<IdentityRole> roles)
        {
            var teacherRole = roles.FirstOrDefault(r => r.Name == "Teacher");

            if(teacherRole == null)
            {
                return;
            }

            string teacherRoleId = teacherRole.Id;
            List<IdentityUserRole<string>> userRoles = new()
            {
                new IdentityUserRole<string> { UserId = users[0].Id, RoleId = teacherRoleId },
                new IdentityUserRole<string> { UserId = users[1].Id, RoleId = teacherRoleId },
                new IdentityUserRole<string> { UserId = users[2].Id, RoleId = teacherRoleId },
                new IdentityUserRole<string> { UserId = users[3].Id, RoleId = teacherRoleId },
                new IdentityUserRole<string> { UserId = users[4].Id, RoleId = teacherRoleId }
            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
        private void SeedSubjectAssignments(ModelBuilder modelBuilder, List<User> teachers, List<Subject> subjects)
        {
            List<SubjectAssignment> subjectAssignments = new()
            {
                new SubjectAssignment { SubjectAssignmentId = Guid.NewGuid().ToString(), SubjectId = subjects[0].SubjectId, TeacherId = teachers[0].Id },
                new SubjectAssignment { SubjectAssignmentId = Guid.NewGuid().ToString(), SubjectId = subjects[1].SubjectId, TeacherId = teachers[1].Id },
                new SubjectAssignment { SubjectAssignmentId = Guid.NewGuid().ToString(), SubjectId = subjects[2].SubjectId, TeacherId = teachers[2].Id },
                new SubjectAssignment { SubjectAssignmentId = Guid.NewGuid().ToString(), SubjectId = subjects[3].SubjectId, TeacherId = teachers[3].Id },
                new SubjectAssignment { SubjectAssignmentId = Guid.NewGuid().ToString(), SubjectId = subjects[4].SubjectId, TeacherId = teachers[4].Id },
                new SubjectAssignment { SubjectAssignmentId = Guid.NewGuid().ToString(), SubjectId = subjects[5].SubjectId, TeacherId = teachers[0].Id },
                new SubjectAssignment { SubjectAssignmentId = Guid.NewGuid().ToString(), SubjectId = subjects[6].SubjectId, TeacherId = teachers[1].Id },
                new SubjectAssignment { SubjectAssignmentId = Guid.NewGuid().ToString(), SubjectId = subjects[7].SubjectId, TeacherId = teachers[2].Id },
                new SubjectAssignment { SubjectAssignmentId = Guid.NewGuid().ToString(), SubjectId = subjects[8].SubjectId, TeacherId = teachers[3].Id },
                new SubjectAssignment { SubjectAssignmentId = Guid.NewGuid().ToString(), SubjectId = subjects[9].SubjectId, TeacherId = teachers[4].Id },
            };

            modelBuilder.Entity<SubjectAssignment>().HasData(subjectAssignments);
		}
        private void RenameIdentityTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("Users");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("UserTokens");
            });

            modelBuilder.Entity<IdentityRole>(b =>
            {
                b.ToTable("Roles");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("UserRoles");
            });
        }

    }
}
