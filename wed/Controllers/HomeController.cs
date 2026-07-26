using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using wed.Models;

namespace wed.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
