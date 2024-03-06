using NuGet.Versioning;

namespace CashierControl.Models
{
    public class DayReport
    {
        public int Id { get; set; }
        public float? PositiveBoxClosing { get; set; }
        public float? NegativeBoxClosing { get; set; }
        public float? Balance { get; set; }
        public DateTime Date { get; set; }
    }
}
