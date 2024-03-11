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
        public IActionResult Index(string startDate, string endDate)
        {
            var user = _user.GetUserAsync(User).Result;
            string sessionId = user.Id;

            DateTime? parsedStartDate = string.IsNullOrEmpty(startDate) ? (DateTime?)null : DateTime.Parse(startDate);
            DateTime? parsedEndDate = string.IsNullOrEmpty(endDate) ? (DateTime?)null : DateTime.Parse(endDate);

            var reports = _reportsServices.GetReports().Where(c => c.SellerId == sessionId && c.Status == true);

            if (parsedStartDate != null && parsedEndDate != null)
            {
                reports = reports.Where(r => r.DateTime >= parsedStartDate && r.DateTime <= parsedEndDate);
            }

            List<Report> filteredReports = reports.ToList();

            // Calculate sums for each type of value
            float bankSlipSum = filteredReports.Where(r => r.Operation == "Pagamento").Sum(r => r.BankSlipValue ?? 0);
            float cashOutflowSum = filteredReports.Where(r => r.Operation == "Saque").Sum(r => r.CashOutflow ?? 0);
            float boxOpenSum = filteredReports.Where(r => r.Operation == "Abertura de caixa").Sum(r => r.BoxOpen ?? 0);
            float depositSum = filteredReports.Where(r => r.Operation == "Deposito").Sum(r => r.DepositValue ?? 0);

            // Pass the sums to the view
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.BankSlipSum = bankSlipSum;
            ViewBag.CashOutflowSum = cashOutflowSum;
            ViewBag.BoxOpenSum = boxOpenSum;
            ViewBag.DepositSum = depositSum;

            return View(filteredReports);
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

