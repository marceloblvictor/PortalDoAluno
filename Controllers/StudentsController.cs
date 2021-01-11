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

        // GET: /Student/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _context.Student.ToListAsync();

            if (students is null)
            {
                return NotFound();
            }

            return View(students);
        }
    }
}
