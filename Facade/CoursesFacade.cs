using PortalDoAluno.Data;
using PortalDoAluno.DTO;
using PortalDoAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Facade
{
    public class CoursesFacade
    {
        public PortalDoAlunoDbContext _context { get; set; }

        public CoursesFacade(PortalDoAlunoDbContext context)
        {
            _context = context;
        }

        public CourseOT BuildOT(Course course)
        {
            var courseOT = new CourseOT();


            return courseOT;
            
        }
    }
}
