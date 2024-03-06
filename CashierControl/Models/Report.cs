namespace CashierControl.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string SellerId { get; set; }
        public string SellerName { get; set; }
        public string Operation {  get; set; }
        public DateTime DateTime { get; set; }

        // BankSlips
        public float? BankSlipValue { get; set; }
        public float? ClientAmount { get; set; }
        public float? Transshipment { get; set; }

        // CashOutflow
        public float? CashOutflow { get; set; }

        // Box Opening
        public float? BoxOpen { get; set; }

        // Deposit value
        public float? DepositValue { get; set; }

        // Variables to calc BoxClosing
        public float? DinamicPositiveBoxClosing { get; set; }
        public float? DinamicNegativeBoxClosing { get; set; }
        
        // Delete Status
        public bool Status { get; set; }
    }
}
