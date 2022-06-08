using CodeTest.Models;
using CodeTest.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepo _repo;

        public HomeController(ILogger<HomeController> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var result = await GetClasses();
            if (result != null)
            {
                ViewData["Classes"] = result;
            }
            return View();
        }


        public async Task<List<Classes>> GetClasses()
        {
            var classes = await _repo.GetClasses();
            return classes;
        }

        public async Task<List<Student>> GetStudent(string ClassName)
        {
            var students = await _repo.GetStudents(ClassName);
            return students;
        }

        public async Task<string> AddClass(Classes classes)
        {
            try
            {
                var addClass = await _repo.AddClass(classes);
                return addClass.ToString();
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> AddStudent(Student student)
        {
            try
            {
                var addStudent = await _repo.AddStudent(student);
                return addStudent.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> EditClass(Classes classes)
        {
            try
            {
                var EditClass = await _repo.EditClass(classes);
                return EditClass.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteClass(Classes classes)
        {
            try
            {
                var EditClass = await _repo.RemoveClass(classes);
                return EditClass.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public async Task<string> EditStudent(Student student)
        {
            try
            {
                var addStudent = await _repo.EditStudent(student);
                return addStudent.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteStudent(Student student)
        {
            try
            {
                var EditClass = await _repo.RemoveStudent(student);
                return EditClass.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
