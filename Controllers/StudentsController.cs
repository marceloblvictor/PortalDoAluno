using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalDoAluno.Data;
using PortalDoAluno.Models;
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
            // Com o include, preenche-se a propriedade de navegação às entidades Student
            var students = await _context.Students.Include( s => s.Enrollments).ToListAsync();

            return View(students);
        }

        // GET: /Students/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(ent => ent.ID == id);

            if (student is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // GET: /Students/Create/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, CourseID")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        
    }
}
