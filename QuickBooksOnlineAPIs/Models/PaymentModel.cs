using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class PaymentModel
    {
        public CustomerRefInvoice CustomerRef { get; set; }
        public double TotalAmt { get; set; }
        public double UnappliedAmt { get; set; }
        public bool ProcessPayment { get; set; }
        public string domain { get; set; }
        public bool sparse { get; set; }
        public string Id { get; set; }
        public string SyncToken { get; set; }
        public MetaData MetaData { get; set; }
        public string TxnDate { get; set; }
        public CurrencyRef CurrencyRef { get; set; }
        public string PrivateNote { get; set; }
        public List<PaymentLine> Line { get; set; }
        public DepositToAccountRef DepositToAccountRef { get; set; }
        public PaymentMethodRef PaymentMethodRef { get; set; }
        public string PaymentRefNum { get; set; }
        public List<LinkedTxn2> LinkedTxn { get; set; }
    }
}