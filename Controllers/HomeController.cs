using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Chefs = dbContext.Chefs.Include( c => c.CreatedDishes);
            return View();
        }


        [HttpGet("new")]
        public IActionResult NewChef()
        {
            // Views form to input chef
            return View("new");
        }


        [HttpPost("new")]
        public IActionResult AddChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                // Create New Chef in db
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return Redirect("/");
            }
            return View("new");
        }


        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            ViewBag.Dishes = dbContext.Dishes.Include( c => c.Creator);
            return View("dishes");
        }


        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.ViewChefs = dbContext.Chefs;
            return View("addDish");
        }


        [HttpPost("dishes/add")]
        public IActionResult NewDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {

                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("dishes");
            }
            ViewBag.ViewChefs = dbContext.Chefs;
            return View("AddDish");
        }

    
    }
}
