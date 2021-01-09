using PortalDoAluno.Models;
using System.Linq;


namespace PortalDoAluno.Data
{
    static public class SeedData
    {
        static void Initiatize(PortalDoAlunoDbContext context)
        {
            
            // Se já houver algum registro na tabela Students, não realiza o seeding
            if (context.Students.Any()) return;

            var course1 = new Course
            {
                ID = 1,
                Name = "Ciência da Computação",
                KnowledgeField = KnowledgeField.CienciasExatasEDaTerra
            };
            var course2 = new Course
            {
                ID = 2,
                Name = "Letras (Alemão)",
                KnowledgeField = KnowledgeField.LetrasEArtes
            };
            var course3 = new Course
            {
                ID = 3,
                Name = "Ciências Sociais",
                KnowledgeField = KnowledgeField.CienciasHumanas
            };

            var student1 = new Student
            {
                ID = 1,
                Name = "Marcelo",
                GlobalRating = 9.3m,
                
            };
            var student2 = new Student
            {
                ID = 2,
                Name = "Clarice",
                GlobalRating = 9.89m
            };
            var student3 = new Student
            {
                ID = 3,
                Name = "Luiz",
                GlobalRating = 8.45m
            };

            context.Add(student1);
            context.Add(student2);
            context.Add(student3);


        }
    }
}
