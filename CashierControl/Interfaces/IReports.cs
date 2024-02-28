

using CashierControl.Models;

namespace CashierControl.Interfaces
{
    public interface IReports
    {
        Report Calc(Report report);
        IEnumerable<Report> GetReports();
        Report GetReport(int id);
        void Delete(Report report);
        void DeleteById(int id);
    }
}
