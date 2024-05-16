using LMS.Models;
using LMS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IStandardRepository standardRepository;

        public StudentController(IStudentRepository studentRepository, IStandardRepository standardRepository)
        {
            this.studentRepository = studentRepository;
            this.standardRepository = standardRepository;
        }

        public IActionResult Index(int? id= null)
        {
            var data = studentRepository.GetStudents(id);
            ViewBag.standard = id;
            ViewBag.All = "All ▼";
            return View(data);
        }
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(StudentModel model)
        {
            var result = studentRepository.IsExist(model.CNIC);
            if (result)
            {
                ModelState.AddModelError("", "This cnic is already exist in the database");
            }
            if (ModelState.IsValid)
            {
            studentRepository.Add(model);
                TempData["Message"] = "Student has been added successfully";
                return RedirectToAction("Index");
            }
            
            return View(model);
        }
        public IActionResult EditStudent(int id)
        {
            var student = studentRepository.GetStudent(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult EditStudent(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                studentRepository.UpdateStudent(model);
                TempData["Message"] = "Student has been updated successfully";
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            studentRepository.DeleteStudent(id);
            TempData["Message"] = "Student has been deleted successfully";
            return RedirectToAction("Index", "Home");

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
