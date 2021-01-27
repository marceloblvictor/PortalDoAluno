using PortalDoAluno.Data;
using PortalDoAluno.Models;
using System.Collections.Generic;
using System.Linq;

namespace PortalDoAluno.Repository
{
    public class CoursesRepository
    {
        public PortalDoAlunoDbContext _context { get; set; }
        
        public CoursesRepository(PortalDoAlunoDbContext context)
        {
            _context = context;
        }

        public Course GetOne(int id)
        {
            var qryEnt = from ent in _context.Courses
                            where ent.ID == id
                            select ent;

            return qryEnt.FirstOrDefault();
        }

        public IQueryable<Course> GetAll()
        {
            var qryEnt = from ent in _context.Courses                         
                         select ent;

            return qryEnt;
        }

    }
}
