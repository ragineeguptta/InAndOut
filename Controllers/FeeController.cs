using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class FeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Fee> objList = _db.Fees;
            return View(objList);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

      //  post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Fee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Fees.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
