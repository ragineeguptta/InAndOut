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

        //  get update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Fees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // post update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Fee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Fees.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //  get delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Fees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // post delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletepost(int? id)
        {
            var obj = _db.Fees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Fees.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
