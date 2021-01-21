using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortalDoAluno.Data;
using PortalDoAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// TODO: acrescentar blocos try/catch nos acessos à DB!

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
        public async Task<IActionResult> Index(string searchString="", string sortingOrder="", 
            int itemsPerPage = 5, int pageNumber = 1)
        {

            // gera uma variável IQueryable
            var courses = from course in _context.Courses
                          select course;
                       

            if (!String.IsNullOrWhiteSpace(searchString))
            {                
                // Como a query está sendo feita num IQueryable, ela será feita no servidor e a comparação (Contains) será case insensitive (default do SQL Server)
                // Se fosse usado o Linq to entity num IEnumberable, a comparação (Contains) é case insensitive por default
                courses = courses.Where(c => c.Name.Contains(searchString));
            }

            // TODO: levar isso para fora do Controller (fachada?)!
            switch (sortingOrder)
            {
                case "name":
                    goto default;                    

                case "name_desc":
                    courses = courses.OrderByDescending(c => c.Name);
                    break;

                case "description":
                    courses = courses.OrderBy(c => c.Description);
                    break;

                case "description_desc":
                    courses = courses.OrderByDescending(c => c.Description);
                    break;

                case "totalHours":
                    courses = courses.OrderBy(c => c.TotalHours);
                    break;

                case "totalHours_desc":
                    courses = courses.OrderByDescending(c => c.TotalHours);
                    break;
                
                default:
                    courses = courses.OrderBy(c => c.Name);
                    break;
            }

            ViewBag.searchString = searchString;
            ViewBag.sortingOrder = sortingOrder;
            ViewBag.pageNumber = pageNumber;
            ViewBag.itemsPerPage = itemsPerPage;
            ViewBag.totalCourses = await courses.CountAsync();


            //The code creates an IQueryable variable before the switch statement, modifies it in the switch statement, 
            //and calls the ToListAsync method after the switch statement.When you create and modify IQueryable variables, 
            //no query is sent to the database. The query isn't executed until you convert the IQueryable object into a 
            //collection by calling a method such as ToListAsync. Therefore, this code results in a single query that's not 
            //executed until the return View statement.
            return View(await Pagination<Course>.CreateAsync(courses.AsNoTracking(), itemsPerPage, pageNumber));            
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,
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

        // TODO: dividir em um action para o GET e outro para o POST!
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
