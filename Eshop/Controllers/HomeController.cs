using Eshop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace Eshop.Controllers
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
            string Message = $"Home/Index pagevisitedat{DateTime.UtcNow.ToLongTimeString()}";

            _logger.LogInformation("Messagedisplayed: {Message}", Message);
            _logger.LogInformation("This is the home page");
            return View("Index");
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