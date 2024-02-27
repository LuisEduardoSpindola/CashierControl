namespace CashierControl.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string SellerName { get; set; }
        public float BankSlipValue {  get; set; }
        public float ClientAmount { get; set;}
        public string Operation {  get; set; }
        public DateTime DateTime { get; set; }
    }
}
