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
            var user = _user.GetUserAsync(User).Result;
            string sessionId = user.Id;

            List<Report> Reports = _reportsServices.GetReports().Where(c => c.SellerId == sessionId).ToList();
            return View(Reports);
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
                report.SellerId = user.Id;
                report.DateTime = DateTime.Now;
                report.Status = true;
                _reportsServices.Calc(report);

                
                return RedirectToAction("Index");
            }
            else 
            {
                throw new Exception("O valor não pode ser nulo");
            }
            
        }


        [Authorize(Roles = "PurpleClient")]
        public IActionResult Delete(int id)
        {
            var report = _reportsServices.GetReport(id);
            report.Status = false;
            _reportsServices.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

