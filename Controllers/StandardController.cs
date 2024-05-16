using LMS.Data;
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
    public class StandardController : Controller
    {
        private readonly IStandardRepository standardRepository;
        private readonly IStandardTeacherRepository standardTeacherRepository;

        public StandardController(IStandardRepository standardRepository,IStandardTeacherRepository standardTeacherRepository)
        {
            this.standardRepository = standardRepository;
            this.standardTeacherRepository = standardTeacherRepository;
        }

        public IActionResult Index()
        {
            var data = standardRepository.GetStandards();
            return View(data);
        }
        public IActionResult AddStandard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStandard(StandardModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if (!standardRepository.AddStandard(model))
            {
                return View(model);
            }
            TempData["Message"] = "Class has been Added successfully";
            return RedirectToAction("Index");
        }
        public IActionResult EditStandard(int id)
        {
            var standard = standardRepository.GetStandard(id);
            return View(standard);
        }
        [HttpPost]
        public IActionResult EditStandard(StandardModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!standardRepository.UpdateStandard(model))
            {
                return View(model);
            }
                
           TempData["Message"] = "Class has been updated successfully";
           return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            standardRepository.DeleteStandard(id);
            TempData["Message"] = "standard has been deleted successfully";
            return RedirectToAction("Index");
        }
        public IActionResult AddTeacherToClass(int id)
        {
            ViewBag.standardId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddTeacherToClass(StandardTeacherModel model)
        {
            var data = standardRepository.GetTeacherByClass(model.StandardId);
            foreach(var item in data)
            {
                if(item.Id == model.TeacherId)
                {
                    ViewBag.Error = "This teacher is already Exist";
                    return RedirectToAction("AddTeacherToClass", 1);
                }
            }
            if(model.TeacherId == 0)
            {
                ViewBag.Error = "Kindly Select a Teacher";
                return RedirectToAction("AddTeacherToClass", 1);
            }
            standardTeacherRepository.AddTeacher(model);
            var id = model.StandardId;
            TempData["Message"] = "Teacher has been added to class successfully";
            return RedirectToAction("AddTeacherToClass", 1);
        }
        public IActionResult RemoveTeacherFromClass(int standardId, int teacherId)
        {
            var standardTeacher = new StandardTeacherModel()
            {
                StandardId = standardId,
                TeacherId = teacherId
            };
            if(!standardTeacherRepository.RemoveTeeacher(standardTeacher))
            {
                return BadRequest("Something Went Wrong");
            }
            TempData["Message"] = "Teacher has been removed from class successfully";
            return Redirect("AddTeacherToClass/" + standardId);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
