﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using PortalDoAluno.Controllers;
using PortalDoAluno.DTO;
using PortalDoAluno.Facade;
using PortalDoAluno.Models;
using PortalDoAluno.Repository;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PortalDoAluno.Tests
{
    public class CoursesControllerTest
    {
        public IEnumerable<Course> GenerateFakeCourses()
        {
            Course[] courses =
            {
                new Course { Name = "Intro to Testando", Description = "Aprenda de Heidegger a Sartre", TotalHours = 44 },
                new Course { Name = "History of Urbanism", Description = "Aprenda os estilos arquitetônicos", TotalHours = 36 },
                new Course { Name = "Linear Algebra", Description = "Aprenda Matrizes e Vetores", TotalHours = 68 }
            };

            return new List<Course>(courses);
        }

        [Fact]
        public async void Index_ListCourses_PaginationIsTheModel()
        {
            // Arrange
            var falseRepository = new Mock<ICoursesRepository>();
            var coursesFacade = new CoursesFacade();
            falseRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GenerateFakeCourses());
            var coursesController = new CoursesController(falseRepository.Object, coursesFacade);

            // Act
            var result = await coursesController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Pagination<CourseOT>>(viewResult.ViewData.Model);            
        }

        [Fact]
        public async void Index_ListCourses_HasThreeCourses()
        {
            // Arrange
            var falseRepository = new Mock<ICoursesRepository>();
            var coursesFacade = new CoursesFacade();
            falseRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GenerateFakeCourses());
            var coursesController = new CoursesController(falseRepository.Object, coursesFacade);

            // Act
            var result = await coursesController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);            
            var model = Assert.IsAssignableFrom<Pagination<CourseOT>>(viewResult.ViewData.Model);        
            Assert.Equal(3, model.Count());
        }
    }
}