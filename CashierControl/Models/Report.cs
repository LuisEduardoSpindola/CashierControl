using System.ComponentModel.DataAnnotations;

namespace CashierControl.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string SellerId { get; set; }

        [Display(Name = "Vendedor")]
        public string SellerName { get; set; }

        [Display(Name = "Operação")]
        public string Operation {  get; set; }

        [Display(Name = "Data")]
        public DateTime DateTime { get; set; }

        // BankSlips
        [Display(Name = "Valor do boleto")]
        public float? BankSlipValue { get; set; }

        [Display(Name = "Valor pago pelo cliente")]
        public float? ClientAmount { get; set; }

        [Display(Name = "Troco")]
        public float? Transshipment { get; set; }

        // CashOutflow
        [Display(Name = "Saque")]
        public float? CashOutflow { get; set; }

        // Box Opening
        [Display(Name = "Valor de Abertura")]
        public float? BoxOpen { get; set; }

        // Deposit value
        [Display(Name = "Valor do depósito")]
        public float? DepositValue { get; set; }

        // Delete Status
        public bool Status { get; set; }
    }
}
