using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class InvoiceModel
    {
        public bool AllowIPNPayment { get; set; }
        public bool AllowOnlinePayment { get; set; }
        public bool AllowOnlineCreditCardPayment { get; set; }
        public bool AllowOnlineACHPayment { get; set; }
        public string domain { get; set; }
        public bool sparse { get; set; }
        public string Id { get; set; }
        public string SyncToken { get; set; }
        public MetaData MetaData { get; set; }
        public List<CustomField> CustomField { get; set; }
        public string DocNumber { get; set; }
        public string TxnDate { get; set; }
        public CurrencyRef CurrencyRef { get; set; }
        public List<LinkedTxn> LinkedTxn { get; set; }
        public List<Line> Line { get; set; }
        public TxnTaxDetail TxnTaxDetail { get; set; }
        public CustomerRefInvoice CustomerRef { get; set; }
        public BillAddrV2 BillAddr { get; set; }
        public bool FreeFormAddress { get; set; }
        public ShipFromAddr ShipFromAddr { get; set; }
        public string DueDate { get; set; }
        public double TotalAmt { get; set; }
        public bool ApplyTaxAfterDiscount { get; set; }
        public string PrintStatus { get; set; }
        public string EmailStatus { get; set; }
        public double Balance { get; set; }
        public ShipAddr ShipAddr { get; set; }
        public CustomerMemo CustomerMemo { get; set; }
        public SalesTermRef SalesTermRef { get; set; }
        public BillEmail BillEmail { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; }
    }
}