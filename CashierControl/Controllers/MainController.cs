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

            // Converta as datas para o formato apropriado (opcional dependendo do formato usado pelo seu banco de dados)
            DateTime? parsedStartDate = string.IsNullOrEmpty(startDate) ? (DateTime?)null : DateTime.Parse(startDate);
            DateTime? parsedEndDate = string.IsNullOrEmpty(endDate) ? (DateTime?)null : DateTime.Parse(endDate);

            // Obtenha todos os relatórios do usuário
            var reports = _reportsServices.GetReports().Where(c => c.SellerId == sessionId && c.Status == true);

            // Aplicar filtro por data, se fornecido
            if (parsedStartDate != null && parsedEndDate != null)
            {
                reports = reports.Where(r => r.DateTime >= parsedStartDate && r.DateTime <= parsedEndDate);
            }

            List<Report> filteredReports = reports.ToList();

            // Passar as datas de volta para a view
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

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

