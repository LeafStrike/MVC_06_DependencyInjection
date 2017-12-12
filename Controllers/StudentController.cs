using System;
using System.Collections.Generic;
using MVC_Dependency.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_Dependency.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MVC_Dependency.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult List([FromServices]IStudentService studentService)
        {
            return View(_studentService.GetStudentsList());
        }

        public IActionResult Edit(int num)
        {
            return View(_studentService.GetStudent(num));
        }
        

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            int num = student.Id;
            if (!ModelState.IsValid)
            {
                return Edit(num);
            }
            var service = HttpContext.
                RequestServices.
                GetService<IStudentService>();
            service.EditStudent(student);

            return RedirectToAction("List", "Student", new { num = student.Id });
        }
        public IActionResult Remove(Student student, int studentId)
        {
            var service = HttpContext.RequestServices.GetService<IStudentService>();
            var instance = ActivatorUtilities.CreateInstance<Remover>(HttpContext.RequestServices, service);
            instance._studentService.RemoveStudent(studentId);
            return View("List",instance._studentService.GetStudentsList());
        }
    }

    public class Remover
    {
        public IStudentService _studentService;
        public Remover(IStudentService studentService)
        {
            _studentService = studentService;
        }
    }
}
