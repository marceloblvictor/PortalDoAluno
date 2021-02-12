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
        public async Task<IActionResult> Index(string searchString = "", string sortingOrder = "", 
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
            
            return View(nameof(Index), Pagination<CourseOT>.Create(coursesOTs, ViewBag.totalCourses, itemsPerPage, pageNumber));            
        }

        // GET: /Courses/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var course = await _repository.GetOne((int) id, getStudents: true);

            if(course is null)
            {
                return RedirectToAction(nameof(Index));
            }            

            return View(nameof(Details), course);
        }

        // GET: /Courses/Create/
        [HttpGet]
        public IActionResult Create()
        {
            return View(nameof(Create));
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

            return View(nameof(Create), course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var course = await _repository.GetOne((int) id, getStudents: false);

            if (course is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Edit), course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,
            [Bind("ID,Name,Description,TotalHours")] Course course)
        {
            if (id == null)
            {
                return BadRequest(ModelState);
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
                return BadRequest(ModelState);
            }

            var course = await _repository.GetOne((int) id, getStudents: false);

            return View(nameof(Delete), course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id is null)
            {
                return BadRequest(ModelState);
            }

            await _repository.Delete((int) id);

            return RedirectToAction(nameof(Index));
        }        
    }
}
