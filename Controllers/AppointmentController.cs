using Microsoft.AspNetCore.Mvc;
using System;

namespace InAndOut.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //string todaysDate = DateTime.Now.ToShortDateString();
            //return Ok(todaysDate);
        }

        public IActionResult Details(int id)
        {
            return Ok("You have entered id = " + id);
        }
        

        //Attribute based routing
        [Route("Blog")]
        [Route("Blog/Index")]
        [Route("Blog/Index/{id?}")]
        public IActionResult AnyActionName(int id)
        {
            return Ok("Index called");
        }
    }
}
