using Microsoft.AspNetCore.Mvc;

namespace biydaalt.Controllers
{
    public class Home1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
