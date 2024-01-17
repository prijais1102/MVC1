using Microsoft.AspNetCore.Mvc;

namespace MVCDemo.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index1()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index3()
        {
            return View();
        }

    }
}
