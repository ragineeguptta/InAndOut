using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objList = _db.Students;
            return View(objList);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            _db.Students.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
