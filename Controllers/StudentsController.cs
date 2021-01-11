using Microsoft.AspNetCore.Mvc;
using PortalDoAluno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Controllers
{
    public class StudentsController : Controller
    {
        public readonly PortalDoAlunoDbContext _context;

        public StudentsController(PortalDoAlunoDbContext context) 
        {
            _context = context;
        }

        // GET: /Student/
        [HttpGet]
        public IActionResult Index()
        {
            var students = _context.Students.OrderBy(ent => ent.ID);

            return View(students);
        }
    }
}
