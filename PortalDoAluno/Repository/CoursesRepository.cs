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

        public async Task<Course> GetOne(int id, bool getStudents = false)
        {
            Course course = null;
            
            try
            {
                if (getStudents == false)
                {
                    course = await _context.Courses.FirstOrDefaultAsync(ent => ent.ID == id);
                }
                else
                {
                    course = await _context.Courses.Include(nameof(Course.Students)).FirstOrDefaultAsync(ent => ent.ID == id);
                }
                
            }
            catch (DbUpdateException ex)
            {
                //TODO: implementar um Logger
                Console.WriteLine(ex.Message);
                throw;
            }

            return course;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            IEnumerable<Course> courses = null;

            try
            {
                courses = await _context.Courses.AsNoTracking().ToListAsync();                
            }
            catch (DbUpdateException ex)
            {
                //TODO: implementar um Logger
                Console.WriteLine(ex.Message);
                throw;
            }

            return courses;
        }

        public async Task<int> Count()
        {
            int count = 0;

            try
            {
                count = await _context.Courses.CountAsync();
            }
            catch (DbUpdateException ex)
            {
                //TODO: implementar um Logger
                Console.WriteLine(ex.Message);
                throw;
            }

            return count;
        }

        public async Task<bool> Add(Course course)
        {
            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException ex)
            {
                //TODO: implementar um Logger
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Update(Course course)
        {            
            try
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                //TODO: implementar um Logger
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public async Task<bool> Delete(int courseID)
        {
            try
            {
                var course = await GetOne(courseID);
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                //TODO: implementar um Logger
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
