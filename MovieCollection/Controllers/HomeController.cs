using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
       

        private MovieFormContext FormContext { get; set; }


        public HomeController(MovieFormContext someName)
        {
            FormContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = FormContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieForm ar)
        {
            if (ModelState.IsValid)
            {
                FormContext.Add(ar);
                FormContext.SaveChanges();
                return View("Confirmation", ar);
            }

            else
            {
                ViewBag.Categories = FormContext.Categories.ToList();
                return View();
            }
        }

        public IActionResult MovieList()
        {
            var applications =FormContext.Responses.Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();

            return View(applications);


        }


        [HttpGet]
        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = FormContext.Categories.ToList();
            

            var application = FormContext.Responses.SingleOrDefault(x => x.MovieID == movieid);

            return View("MovieForm", application);
        }
        [HttpPost]
        public IActionResult Edit(MovieForm blah)
        {
            FormContext.Update(blah);
            FormContext.SaveChanges();

            return RedirectToAction("MovieList");

        }


        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var application = FormContext.Responses.SingleOrDefault(x => x.MovieID == movieid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(MovieForm ar)
        {
            FormContext.Responses.Remove(ar);
            FormContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


       
        
    }
}
