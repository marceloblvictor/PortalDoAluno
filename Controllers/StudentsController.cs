using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalDoAluno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Controllers
{
    public class StudentsController : Controller
    {
        private readonly PortalDoAlunoDbContext _context;

        public StudentsController(PortalDoAlunoDbContext context) 
        {
            _context = context;
        }

        // GET: /Students/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.ToListAsync();

            return View(students);
        }

        // GET: /Students/Create/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // GET: /Students/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(ent => ent.ID == id);

            if(student is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }
    }
}
