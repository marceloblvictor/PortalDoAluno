using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalDoAluno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Controllers
{
    public class CoursesController : Controller
    {
        private readonly PortalDoAlunoDbContext _context;

        public CoursesController(PortalDoAlunoDbContext context) 
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

        // GET: /Courses/Create/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // GET: /Courses/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(ent => ent.ID == id);

            if(course is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }
    }
}
