using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace SampleApplication.Controllers
{
    public class ReturnTypeController : Controller
    {

        public IWebHostEnvironment _IhostingEnvironment { get; set; }

        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="IhostingEnvironment"></param>
        public ReturnTypeController(IWebHostEnvironment IhostingEnvironment)
        {
            _IhostingEnvironment = IhostingEnvironment;
        }


        #region :: Status Code Results ::

        /// <summary>
        /// This is a StatusCodeResult. When executed, it will produce an empty Status200OK response.
        /// </summary>
        /// <returns></returns>
        public IActionResult OkResult()
        {
            return Ok();
        }

        /// <summary>
        /// returns a Created (201) response with a Location header. 
        /// This indicates the request has been fulfilled and has resulted 
        /// in one or more new resources being created.
        /// </summary>
        /// <returns></returns>
        public IActionResult CreatedResult()
        {
            return Created("http://example.org/myitem", new { name = "newitem" });
        }

        /// <summary>
        /// Result returns 204 status code
        /// </summary>
        /// <returns></returns>
        public IActionResult NoContentResult()
        {
            return NoContent();
        }

        /// <summary>
        /// An ObjectResult, when executed, will produce a Bad Request (400) response. 
        /// It indicates a bad request by the user. 
        /// It does not take any argument.
        /// </summary>
        /// <returns></returns>
        public IActionResult BadRequestResult()
        {
            return BadRequest();
        }

        /// <summary>
        /// UnauthorizedResult returns 401 status code, it's difference to
        /// ChallengeResult is that it just returns an status code and doesn’t
        /// do anything else. 
        /// In contrast with it's counterpart that has many options for 
        /// redirecting the user and options related to asp.net core identity.
        /// </summary>
        /// <returns></returns>
        public IActionResult UnauthorizedResult()
        {
            return Unauthorized();
        }

        /// <summary>
        /// Represents a StatusCodeResult that when executed, will produce 
        /// a Not Found (404) response.
        /// </summary>
        /// <returns></returns>
        public IActionResult NotFoundResult()
        {
            return NotFound();
        }

        /// <summary>
        /// This action result returns 415 status code, which means server cannot 
        /// continue to process the request with the given payload. 
        /// It's doing this by inspecting the Content-Type or Content-Encoding 
        /// of the current request or inspecting the incoming data directly.
        /// </summary>
        /// <returns></returns>
        public IActionResult UnsupportedMediaTypeResult()
        {
            return new UnsupportedMediaTypeResult();
        }

        #endregion


        #region :: Status Code with Object Results ::

        /// <summary>
        /// An ObjectResult, when executed, performs content negotiation, 
        /// formats the entity body, and will produce a Status200OK response
        /// if negotiation and formatting succeed.
        /// </summary>
        /// <returns></returns>
        public IActionResult OkObjectResult()
        {
            var result = new OkObjectResult(new
            { message = "200 OK", currentDate = DateTime.Now });
            return result;
        }

        /// <summary>
        /// CreatedAtActionResult that returns a Created (201) response with a Location header.
        /// </summary>
        /// <returns></returns>
        public IActionResult CreatedObjectResult()
        {
            var result = new CreatedAtActionResult("createdobjectresult",
                "statuscodeobjects", "",
                new { message = "201 Created", currentDate = DateTime.Now });
            return result;
        }

        /// <summary>
        /// This is similar to BadRequestResult, with the difference that 
        /// it can pass an object or a ModelStateDictionary containing the 
        /// details regarding the error.
        /// </summary>
        /// <returns></returns>
        public IActionResult BadRequestObjectResult()
        {
            var result = new BadRequestObjectResult(new
            { message = "400 Bad Request", currentDate = DateTime.Now });
            return result;
        }

        /// <summary>
        /// This is similar to NotFoundResult, with the difference being that 
        /// you can pass an object with the 404 response.
        /// </summary>
        /// <returns></returns>
        public IActionResult NotFoundObjectResult()
        {
            var result = new NotFoundObjectResult(new
            { message = "404 Not Found", currentDate = DateTime.Now });
            return result;
        }


        #endregion


        #region :: Redirect Result ::

        /// <summary>
        /// Redirect to specified string URL with permanent 301 property set to false
        /// </summary>
        /// <returns></returns>
        public IActionResult RedirectResult()
        {
            return Redirect("https://www.google.com");
        }

        /// <summary>
        /// Redirect to specified URL is it's local URL (also relative), 
        /// if not it will throws an exception, permanent 301 property set to false
        /// </summary>
        /// <returns></returns>
        public IActionResult LocalRedirectResult()
        {
            return LocalRedirect("/redirects/target");
        }


        /// <summary>
        /// RedirectToActionResult can redirect us to an action. 
        /// It takes in the action name, controller name, and route value.
        /// </summary>
        /// <returns></returns>
        public IActionResult RedirectToActionResult()
        {
            return RedirectToAction("target", "Appointment");
        }


        #endregion


        #region :: File Result ::


        /// <summary>
        /// Returns the file content as pdf content.
        /// </summary>
        /// <returns></returns>
        public IActionResult FileResult()
        {
            return File("~/downloads/pdf-sample.pdf", "application/pdf");
        }

        /// <summary>
        /// Return the file as an array of bytes as you see in FileContentActionResult.
        /// </summary>
        /// <returns></returns>
        public IActionResult FileContentResult()
        {
            //Get the byte array for the document
            var pdfBytes = System.IO.File.ReadAllBytes
                ("wwwroot/downloads/pdf-sample.pdf");

            //FileContentResult needs a byte array and returns a file
            //with the specified content type.
            return new FileContentResult(pdfBytes, "application/pdf");
        }

        /// <summary>
        /// Use VirtualFileResult if you want to read a file form 
        /// a virtual address and return it
        /// </summary>
        /// <returns></returns>
        public IActionResult VirtualFileResult()
        {
            //Paths given to the VirtualFileResult are relative
            //to the wwwroot folder.
            return new VirtualFileResult
                ("/downloads/pdf-sample.pdf", "application/pdf");
        }

        /// <summary>
        /// Use PhysicalFileResult to read a file from a physical address and return it
        /// </summary>
        /// <returns></returns>
        public IActionResult PhysicalFileResult()
        {
            return new PhysicalFileResult(_IhostingEnvironment.ContentRootPath
                + "/wwwroot/downloads/pdf-sample.pdf", "application/pdf");
        }


        #endregion

        #region :: Content Result ::


        /// <summary>
        /// It renders a specified view to the response stream.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Renders a specifed partial view to the response stream.
        /// </summary>
        /// <returns></returns>
        public IActionResult PartialViewResult()
        {
            return PartialView();
        }

        /// <summary>
        /// Return JsonResult (JavaScript Object Notation result)
        /// </summary>
        /// <returns></returns>
        public IActionResult JsonResult()
        {
            return Json(new
            {
                message = "This is a JSON result.",
                date = DateTime.Now
            });
        }

        /// <summary>
        /// It display the response stream without requiring a view
        /// </summary>
        /// <returns></returns>
        public IActionResult ContentResult()
        {
            return Content("Here's the ContentResult message.");
        }


        #endregion

    }
}