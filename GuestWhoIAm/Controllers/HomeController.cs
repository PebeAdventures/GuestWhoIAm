using GuestWhoIAm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GuestWhoIAm.Controllers
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
        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Redirect()
        {
            return RedirectToAction("Privacy");
        }
        [Route("test")]
        public IActionResult Query() { return View(); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}