using LMS.Data;
using LMS.Models;
using LMS.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }
        public IActionResult Index()
        {
            var teachers = teacherRepository.GetTeachers();
            return View(teachers);
        }
        public IActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeacher(TeacherModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if (!teacherRepository.AddTeacher(model))
            {
                return View(model);
            }
            TempData["Message"] = "Teacher has been Added successfully";
            return RedirectToAction("Index");
        }
        public IActionResult EditTeacher(int id)
        {
            var teacher = teacherRepository.GetTeacher(id);
            return View(teacher);
        }
        [HttpPost]
        public IActionResult EditTeacher(TeacherModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!teacherRepository.UpdateTeacher(model))
            {
                return View(model);
            }
            TempData["Message"] = "Class has been Updated successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = teacherRepository.IsExist(id);
            if(!result)
            {
                return NotFound();
            }
                teacherRepository.DeleteTeacher(id);
            TempData["Message"] = "Class has been Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
