using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortalDoAluno.Data;
using PortalDoAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Controllers
{
    public class CoursesController : Controller
    {
        private readonly PortalDoAlunoDbContext _context;        

        public CoursesController( PortalDoAlunoDbContext context) 
        {            
            _context = context;
        }

        // GET: /Courses/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses.ToListAsync();
            
            return View(courses);
        }

        // GET: /Courses/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var course = await _context.Courses.FirstOrDefaultAsync(ent => ent.ID == id);

            if(course is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        // GET: /Courses/Create/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,TotalHours,ContentType")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var course = await _context.Courses.AsNoTracking().FirstOrDefaultAsync(ent => ent.ID == id);

            if (course is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id,
            [Bind("ID,Name,Description,TotalHours,ContentType")] Course course)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(course);
        }

       
        public async Task<IActionResult> Delete(int? id, bool? confirmed = false)
        {
            if (id is null)
            {
                return NotFound();
            }

            var courseToBeDeleted = await _context.Courses.FirstOrDefaultAsync(ent => ent.ID == id);

            if (confirmed == true)
            {                
                _context.Courses.Remove(courseToBeDeleted);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(courseToBeDeleted);
        }
    }
}
