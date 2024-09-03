using Microsoft.AspNetCore.Mvc;
using Recipe_App.Models;
using System.Diagnostics;

namespace Recipe_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUS()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        /*public IActionResult Dashboard()
        {
            return View();
        }*/
        public IActionResult Dashboard()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View();
        }

        public IActionResult Eat_Health()
        {
            return View();
        }

        public IActionResult Fitness()
        {
            return View();
        }

        public IActionResult Health()
        {
            return View();
        }

        public IActionResult Health_Main()
        {
            return View();
        }
        public IActionResult importance()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult signUP()
        {
            return View();
        }
        public IActionResult Store()
        {
            return View();
        }
        public IActionResult Visualizations()
        {
            return View();
        }

        public IActionResult BreakFast()
        {
            return View();
        }

        public IActionResult Lunch()
        {
            return View();
        }

        public IActionResult Snacks()
        {
            return View();
        }

        public IActionResult Beverages()
        {
            return View();
        }

        public IActionResult AddRating()
        {
            return View();
        }

        public IActionResult AddDifficulty()
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
