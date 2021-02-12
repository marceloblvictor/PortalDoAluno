using PortalDoAluno.Models;
using System;
using System.Linq;

namespace PortalDoAluno.Data
{
    static public class DataSeeder
    {               
        static public void Initialize(PortalDoAlunoDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var courses = new Course[]
            {
                new Course {Name="Intro to Existentialism", Description="Aprenda de Heidegger a Sartre", TotalHours=44},
                new Course {Name="History of Urbanism", Description="Aprenda os estilos arquitetônicos", TotalHours=36},
                new Course {Name="Linear Algebra", Description="Aprenda Matrizes e Vetores", TotalHours=68},
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var students = new Student[]
            {
                new Student {Name="Teobaldo", CourseID=2},
                new Student {Name="Francisco Rasputin", CourseID=2},
                new Student {Name="Marilyn Manson", CourseID=2}
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department {Name="History"},
                new Department {Name="Computer Science"},
                new Department {Name="Philosophy"},
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {CourseID=1, StudentID=1},
                new Enrollment {CourseID=3, StudentID=1},
                new Enrollment {CourseID=1, StudentID=2},
                new Enrollment {CourseID=1, StudentID=2},
                new Enrollment {CourseID=1, StudentID=3},
                new Enrollment {CourseID=2, StudentID=3},
                new Enrollment {CourseID=3, StudentID=3},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();

            var professors = new Professor[]
            {
                new Professor {DepartmentID=1},
                new Professor {DepartmentID=2},
                new Professor {DepartmentID=3},
            };

            context.Professors.AddRange(professors);
            context.SaveChanges();


        }
    }
}
