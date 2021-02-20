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
                new Student {Name="Marilyn Manson", CourseID=1},
                new Student {Name="Joao Carlos", CourseID=1},
                new Student {Name="Vinny Caravella", CourseID=3},
                new Student {Name="Alex Navarro", CourseID=3},
                new Student {Name="Jeff Bakalar", CourseID=2},
            };

            context.Students.AddRange(students);
            context.SaveChanges();

        }
    }
}
