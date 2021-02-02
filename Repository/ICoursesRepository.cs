using PortalDoAluno.Data;
using PortalDoAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortalDoAluno.Repository
{
    public interface ICoursesRepository
    {
        public PortalDoAlunoDbContext _context { get; set; }
        
        public Task<Course> GetOne(int id);

        public Task<IEnumerable<Course>> GetAll();

        public Task<int> Count();




    }
}
