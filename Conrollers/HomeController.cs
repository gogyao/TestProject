using Microsoft.AspNetCore.Mvc;

namespace Test.Conrollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
