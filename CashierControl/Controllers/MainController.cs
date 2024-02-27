using Microsoft.AspNetCore.Mvc;

namespace CashierControl.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calc() 
        {
            return View();
        }
    }
}

