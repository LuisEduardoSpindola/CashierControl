using CashierControl.Areas.Identity.Data;
using CashierControl.Interfaces;
using CashierControl.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CashierControl.Repositories
{
    public class ReportRepositories : IReports
    {
        public CashierControlContext _controlContext { get; set; }

        public ReportRepositories(CashierControlContext controlContext)
        {
            _controlContext = controlContext;   
        }

        public Report Calc(Report report)
        {
            _controlContext.Reports.Add(report);
            _controlContext.SaveChanges();
            return report;
        }

        public IEnumerable<Report> GetReports()
        {
            return _controlContext.Reports.ToList();
        }

        public Report GetReport(int id)
        {
            var result = _controlContext.Reports.FirstOrDefault(r => r.Id == id);
            if (id == null) 
            {
                throw new Exception("Não encontrado");
            }
            return result;
        }

        public void Delete(Report report)
        {
            report.Status = false;
            _controlContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var result = GetReport(id);
            Delete(result);
        }

        public void SaveChanges() 
        {
            SaveChanges();
        }
    }
}
