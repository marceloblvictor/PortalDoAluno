using Microsoft.AspNetCore.Mvc;
using Moq;
using PortalDoAluno.Controllers;
using PortalDoAluno.DTO;
using PortalDoAluno.Facade;
using PortalDoAluno.Models;
using PortalDoAluno.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PortalDoAluno.Tests
{
    public class CoursesControllerTest
    {
        public IEnumerable<Course> GenerateFakeCoursesList()
        {
            return new List<Course>() 
            {
                new Course { Name = "Intro to Testando", Description = "Aprenda de Heidegger a Sartre", TotalHours = 44 },
                new Course { Name = "History of Urbanism", Description = "Aprenda os estilos arquitetônicos", TotalHours = 36 },
                new Course { Name = "Linear Algebra", Description = "Aprenda Matrizes e Vetores", TotalHours = 68 }
            };
        }

        public Course GenerateFakeCourse()
        {
            return new Course { Name = "ABC", 
                                Description = "Aprenda as letras",
                                TotalHours = 86 };
        }

        [Fact]
        public async void Index_ListCourses_PaginationIsTheModel()
        {
            // Arrange
            var falseRepository = new Mock<ICoursesRepository>();
            var coursesFacade = new CoursesFacade();
            falseRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GenerateFakeCoursesList());
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
            falseRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GenerateFakeCoursesList());
            var coursesController = new CoursesController(falseRepository.Object, coursesFacade);

            // Act
            var result = await coursesController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);            
            var model = Assert.IsAssignableFrom<Pagination<CourseOT>>(viewResult.ViewData.Model);        
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async void CreatePost_NewCoursePostValid_Redirects()
        {
            // Arrange
            var falseRepository = new Mock<ICoursesRepository>();
            var coursesFacade = new CoursesFacade();
            var coursesController = new CoursesController(falseRepository.Object, coursesFacade);            

            // Act
            var result = await coursesController.Create(GenerateFakeCourse());

            // Assert
            Assert.IsType<RedirectToActionResult>(result);            
        }

        [Fact]
        public async void Create_NewCoursePost_AddsNewCourseEntity()
        {
            // Arrange
            var mockRepository = new Mock<ICoursesRepository>();
            var coursesFacade = new CoursesFacade();
            mockRepository.Setup(repo => repo.Add(It.IsAny<Course>())).Returns(Task.FromResult(true))
                .Verifiable();

            var coursesController = new CoursesController(mockRepository.Object, coursesFacade);

            // Act
            var result = await coursesController.Create(GenerateFakeCourse());

            // Assert
            mockRepository.Verify();
        }

        [Fact]
        public async void CreatePost_NewCoursePostInvalid_ReloadsSamePage()
        {
            // Arrange
            var falseRepository = new Mock<ICoursesRepository>();
            var coursesFacade = new CoursesFacade();
            falseRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GenerateFakeCoursesList());
            var coursesController = new CoursesController(falseRepository.Object, coursesFacade);
            coursesController.ModelState.AddModelError("erro", "erro no teste");

            // Act
            var result = await coursesController.Create(GenerateFakeCourse());

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Create", viewResult.ViewName);
        }

        [Fact]
        public async void Delete_PassedIDIsNull_ReturnsBadRequestObject()
        {
            // Arrange
            var falseRepository = new Mock<ICoursesRepository>();
            var coursesFacade = new CoursesFacade();
            falseRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GenerateFakeCoursesList());
            var coursesController = new CoursesController(falseRepository.Object, coursesFacade);

            // Act
            var result = await coursesController.Delete(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async void DeleteConfirmed_PassedIDIsNull_ReturnsBadRequestObject()
        {
            // Arrange
            var falseRepository = new Mock<ICoursesRepository>();
            var coursesFacade = new CoursesFacade();
            falseRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GenerateFakeCoursesList());
            var coursesController = new CoursesController(falseRepository.Object, coursesFacade);

            // Act
            var result = await coursesController.DeleteConfirmed(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
