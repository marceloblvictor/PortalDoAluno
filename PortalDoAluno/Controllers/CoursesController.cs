using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortalDoAluno.Data;
using PortalDoAluno.DTO;
using PortalDoAluno.Facade;
using PortalDoAluno.Models;
using PortalDoAluno.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Controllers
{
    public class CoursesController : Controller
    {          
        private readonly ICoursesRepository _repository;

        private readonly ICoursesFacade _facade;

        public CoursesController(ICoursesRepository repository, ICoursesFacade facade) 
        {            
            _repository = repository;
            _facade = facade;
        }

        // GET: /Courses/
        [HttpGet]
        public async Task<IActionResult> Index(string searchString="", string sortingOrder="", 
            int itemsPerPage = 5, int pageNumber = 1)
        {
            IEnumerable<Course> courses = await _repository.GetAll();

            // Filtra os registros da entidade Course conforme o texto passado pelo cliente                       
            if (!String.IsNullOrWhiteSpace(searchString))
            {                                
                courses = courses.Where(c => c.Name.Contains(searchString));
            }

            // Ordena os registros da entidade Course conforme a ordem passada pelo cliente
             var sortedCourses = _facade.SortList(courses, sortingOrder);

            // Monta uma lista com os objetos de transferência
            var coursesOTs = _facade.BuildOTList(sortedCourses);

            // Passa pela ViewBag valores relevantes para a interface
            ViewBag.searchString = searchString;
            ViewBag.sortingOrder = sortingOrder;
            ViewBag.pageNumber = pageNumber;
            ViewBag.itemsPerPage = itemsPerPage;
            ViewBag.totalCourses = await _repository.Count();            
            
            return View(Pagination<CourseOT>.Create(coursesOTs, ViewBag.totalCourses, itemsPerPage, pageNumber));            
        }

        // GET: /Courses/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var course = await _repository.GetOne((int) id);

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
        public async Task<IActionResult> Create([Bind("Name,Description,TotalHours")] Course course)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(course);
                
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

            var course = await _repository.GetOne((int) id);

            if (course is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,
            [Bind("ID,Name,Description,TotalHours")] Course course)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.Update(course);
            }
            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var course = await _repository.GetOne((int) id);

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        //// TODO: dividir em um action para o GET e outro para o POST!
        //public async Task<IActionResult> Delete(int? id, bool? confirmed = false)
        //{
        //    if (id is null)
        //    {
        //        return NotFound();
        //    }

        //    var courseToBeDeleted = await _context.Courses.FirstOrDefaultAsync(ent => ent.ID == id);

        //    if (confirmed == true)
        //    {                
        //        _context.Courses.Remove(courseToBeDeleted);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(courseToBeDeleted);
        //}
    }
}
