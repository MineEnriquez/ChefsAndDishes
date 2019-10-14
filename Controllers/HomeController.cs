using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext dbContext;
        private readonly IChefRepository _chefRepository;
        public HomeController(IChefRepository chefRepository, AppDbContext context)
        {
            _chefRepository = chefRepository;
            dbContext = context;
        }
        public IActionResult Index()
        {
            // IndexViewModel chefsInfo = new IndexViewModel();
            // chefsInfo.AllChefs = dbContext.Chefs.ToList();
            // return View(chefsInfo);
            var model = _chefRepository.GetAllChef();
            return View(model);

        }

        [Route("Dishes")]
        [HttpGet]
        public IActionResult Dishes()
        {

            var dishesInfoWithChef = dbContext.Dishes.Include(dish => dish.Creator);
             
            return View("Dishes", dishesInfoWithChef.ToList());
        }

        [Route("New")]
        [HttpGet]
        public IActionResult New()
        {
            return View("New");
        }


        [Route("New")]
        [HttpPost]
        public IActionResult NewChefSave(Chef newChef)
        {

            if(ModelState.IsValid)
            {

                _chefRepository.Add(newChef);
                return RedirectToAction("Index");
            }
            else
            {
                // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
                return View("New");
            }
        }

        [Route("Dishes/New")]
        [HttpGet]
        public IActionResult NewDish()
        {
            ViewBag.Chefs = dbContext.Chefs;
            return View("NewDish");
        }
       [Route("Dishes/New")]
        [HttpPost]
        public IActionResult NewDishSave(Dish dish)
        {
            if(ModelState.IsValid)
            {

                // _chefRepository.Add(newChef);
                dbContext.Dishes.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
                return View("Dishes/New");
            }
        }

        public IActionResult DetailsChef(int? id)
        {
            /// THIS NEEDS  A LOT OF MORE WORK - CHECK THE TUTORIAL. https://youtu.be/qJmEI2LtXIY?t=654

            Chef chef = _chefRepository.GetChef(id ?? 1);
            return View(chef);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
