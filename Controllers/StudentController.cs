using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentLibary.Models;

namespace StudentLibary.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            TempData["message"] = "Insert success!";
            return Redirect("Index");
        }

        public IActionResult Edit(long id)
        {
            var existStudent = _context.Students.Find(id);
            if (existStudent == null)
            {
                return NotFound();
            }
            return View(existStudent);
        }

        public IActionResult Update(Student student)
        {
            var existStudent = _context.Students.Find(student.Id);
            if (existStudent == null)
            {
                return NotFound();
            }
            existStudent.Name = student.Name;
            existStudent.RollNumber = student.RollNumber;
            _context.Students.Update(existStudent);
            _context.SaveChanges();
            TempData["message"] = "Update success!";
            return Redirect("Index");
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            var existStudent = _context.Students.Find(id);
            if (existStudent == null)
            {
                return NotFound();
            }

            _context.Students.Remove(existStudent);
            _context.SaveChanges();

            return Json(existStudent);
        }
    }
}