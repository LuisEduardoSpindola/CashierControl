using CashierControl.Areas.Identity.Data;
using CashierControl.Interfaces;
using CashierControl.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CashierControl.Controllers
{
    public class MainController : Controller
    {
        public IReports _reportsServices { get; set; }
        public UserManager<Cashier> _user {  get; set; }

        public MainController(IReports reportsServices, UserManager<Cashier> user)
        {
            _reportsServices = reportsServices;
            _user = user;
        }

        [Authorize(Roles = "PurpleClient")]
        public IActionResult Index()
        {
            var result = _reportsServices.GetReports();
            return View(result);
        }

        [Authorize(Roles = "PurpleClient")]
        public IActionResult Calc() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calc(Report report)
        {
            if (report != null) 
            {
                var user = _user.GetUserAsync(User).Result;
                report.SellerName = user.Name;
                report.DateTime = DateTime.Now;
                _reportsServices.Calc(report);
                
                return RedirectToAction("Index");
            }
            else 
            {
                throw new Exception("O valor não pode ser nulo");
            }
            
        }
    }
}

