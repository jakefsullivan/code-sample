using CodingExercise.Models;
using CodingExercise.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodingExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var homeService = new HomeService();
            var users = await homeService.GetUsersAsync();

            return View(new IndexViewModel
            {
                Users = users,
            });
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