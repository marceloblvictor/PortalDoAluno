﻿using Microsoft.AspNetCore.Mvc;
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

// TODO: acrescentar blocos try/catch nos acessos à DB!

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

        //[HttpGet]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id is null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }

        //    var course = await _context.Courses.AsNoTracking().FirstOrDefaultAsync(ent => ent.ID == id);

        //    if (course is null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(course);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int? id,
        //    [Bind("ID,Name,Description,TotalHours,ContentType")] Course course)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(course);
        //            await _context.SaveChangesAsync();

        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateException /* ex */)
        //        {
        //            //Log the error (uncomment ex variable name and write a log.)
        //            ModelState.AddModelError("", "Unable to save changes. " +
        //                "Try again, and if the problem persists, " +
        //                "see your system administrator.");
        //        }
        //    }
        //    return View(course);
        //}

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
