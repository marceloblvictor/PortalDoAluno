using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortalDoAluno.Models;
using System;
using System.Linq;


namespace PortalDoAluno.Data
{
    public static class SeedData
    {
        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PortalDoAlunoDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<PortalDoAlunoDbContext>>()))
            {
                // Se já houver algum registro na tabela Students, não realiza o seeding
                if (context.Students.Any()) return;

                var courseCS = new Course
                {
                    ID = 1,
                    Name = "Ciência da Computação",
                    KnowledgeField = KnowledgeField.CienciasExatasEDaTerra
                };
                var courseLetras = new Course
                {
                    ID = 2,
                    Name = "Letras (Alemão)",
                    KnowledgeField = KnowledgeField.LetrasEArtes
                };
                var courseSC = new Course
                {
                    ID = 3,
                    Name = "Ciências Sociais",
                    KnowledgeField = KnowledgeField.CienciasHumanas
                };

                context.Courses.AddRange(courseCS, courseLetras, courseSC);
                context.SaveChangesAsync();

                context.Students.AddRange
                (
                    new Student
                    {
                        ID = 1,
                        Name = "Marcelo",
                        GlobalRating = 9.3m,
                        Course = courseCS,
                        CourseID = 1
                    },
                    new Student
                    {
                        ID = 2,
                        Name = "Clarice",
                        GlobalRating = 9.89m,
                        Course = courseLetras,
                        CourseID = 2
                    },
                    new Student
                    {
                        ID = 3,
                        Name = "Luiz",
                        GlobalRating = 8.45m,
                        Course = courseSC,
                        CourseID = 3
                    }
                );

                context.SaveChangesAsync();

            }
            
            

        }
    }
}
