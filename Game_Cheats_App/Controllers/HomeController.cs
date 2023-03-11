using Game_Cheats_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Game_Cheats_App.Controllers
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
            ViewBag.HomeMsg = "“GameCheats is dedicated to displaying cheats, walkthroughs, and \r\ntactics for video games. The database is user generated, but moderated by our editors. We offer this information as a \r\nservice. Use this information at your peril. We accept no responsibility for consequences of your using our information.”";
            return View();
            
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