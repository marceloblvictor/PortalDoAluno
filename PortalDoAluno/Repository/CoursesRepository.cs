using Microsoft.EntityFrameworkCore;
using PortalDoAluno.Data;
using PortalDoAluno.DTO;
using PortalDoAluno.Facade;
using PortalDoAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        public PortalDoAlunoDbContext _context { get; set; }
        
        public CoursesRepository(PortalDoAlunoDbContext context)
        {
            _context = context;
        }

        public async Task<Course> GetOne(int id)
        {
            var qryEnt = await _context.Courses.FirstOrDefaultAsync(ent => ent.ID == id);

            return qryEnt;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var courses = await _context.Courses.AsNoTracking().ToListAsync();

            return courses;
        }

        public async Task<int> Count() => await _context.Courses.CountAsync();

        public async Task<bool> Add(Course course)
        {
            try
            {
                await _context.Courses.AddAsync(course);
                return true;
            }
            catch (DbUpdateException ex)
            {
                //TODO: implementar um Logger
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Update(Course course, int courseID)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int courseID)
        {
            throw new System.NotImplementedException();
        }
    }
}
