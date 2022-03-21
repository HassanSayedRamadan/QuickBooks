using Intuit.Ipp.OAuth2PlatformClient;
using Newtonsoft.Json;
using QuickBooksOnlineAPIs.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace QuickBooksOnlineAPIs.Controllers.API
{
    [System.Web.Http.RoutePrefix("api/QuickBooks")]
    public class QuickBooksController : ApiController
    {
        [System.Web.Http.HttpGet, System.Web.Http.Route("GetInvoices")]
        public IEnumerable<InvoiceTable> GetInvoices()
        {
            var APICallerObj = new APICaller();

            string query = "select * from Invoice";
            var InvoiceResponseObj = JsonConvert.DeserializeObject<InvoiceResponse>(APICallerObj.Query(query));

            var InvoiceTableList = new List<InvoiceTable>();

            foreach (var InvoiceTableItem in InvoiceResponseObj.QueryResponse.Invoice)
            {
                var InvoiceTableObj = new InvoiceTable();

                InvoiceTableObj.DocNumber = InvoiceTableItem.DocNumber;
                InvoiceTableObj.Balance = InvoiceTableItem.CurrencyRef.value + " " + InvoiceTableItem.Balance;
                InvoiceTableObj.DueDate = InvoiceTableItem.DueDate;
                InvoiceTableObj.Date = InvoiceTableItem.TxnDate;
                InvoiceTableObj.CustomerName = InvoiceTableItem.CustomerRef.name;
                InvoiceTableObj.Total = InvoiceTableItem.CurrencyRef.value + " " + InvoiceTableItem.TotalAmt;
                InvoiceTableObj.Id = InvoiceTableItem.Id;

                InvoiceTableList.Add(InvoiceTableObj);
            }
            return InvoiceTableList;
        }

        [System.Web.Http.HttpGet, System.Web.Http.Route("GetPayments")]
        public IEnumerable<PaymentTable> GetPayments()
        {
            var APICallerObj = new APICaller();
            string query = "select * from Payment";
            var PaymentResponseObj = JsonConvert.DeserializeObject<PaymentResponse>(APICallerObj.Query(query));

            var PaymentTableList = new List<PaymentTable>();

            foreach (var PaymentTableItem in PaymentResponseObj.QueryResponse.Payment)
            {
                var PaymentTableObj = new PaymentTable();

                PaymentTableObj.Date = PaymentTableItem.TxnDate;
                PaymentTableObj.CustomerName = PaymentTableItem.CustomerRef.name;
                PaymentTableObj.Total = PaymentTableItem.CurrencyRef.value + " " + PaymentTableItem.TotalAmt;
                PaymentTableObj.Id = PaymentTableItem.Id;
                PaymentTableObj.Delete = true;

                if (PaymentTableItem.LinkedTxn != null)
                {
                    for (int i = 0; i < PaymentTableItem.LinkedTxn.Count; i++)
                    {
                        if (PaymentTableItem.LinkedTxn[i].TxnType == "Deposit")
                        {
                            PaymentTableObj.Delete = false;
                            break;
                        }
                    }
                }

                PaymentTableList.Add(PaymentTableObj);
            }
            return PaymentTableList;
        }


        [System.Web.Http.HttpDelete, System.Web.Http.Route("DeleteInvoice/{InvoiceId:int}")]
        public void DeleteInvoice(int InvoiceId)
        {
            var APICallerObj = new APICaller();

            string query = "select * from Invoice Where Id = '" + InvoiceId + "'";
            var InvoiceResponseObj = JsonConvert.DeserializeObject<InvoiceResponse>(APICallerObj.Query(query));

            var InvoiceDeleteReq = new InvoiceDeleteReq()
            {
                SyncToken = InvoiceResponseObj.QueryResponse.Invoice[0].SyncToken,
                Id = InvoiceResponseObj.QueryResponse.Invoice[0].Id
            };

            string httpWebRequest = ConfigurationManager.AppSettings["SandboxBaseURL"] + "/v3/company/" + ConfigurationManager.AppSettings["CompanyID"] + "/invoice?operation=delete&minorversion=" + ConfigurationManager.AppSettings["minorversion"];

            APICallerObj.PostApiCallService(InvoiceDeleteReq, httpWebRequest);
        }

        [System.Web.Http.HttpDelete, System.Web.Http.Route("DeletePayment/{PaymentId:int}")]
        public void DeletePayment(int PaymentId)
        {
            var APICallerObj = new APICaller();

            string query = "select * from Payment Where Id = '" + PaymentId + "'";
            var PaymentResponseObj = JsonConvert.DeserializeObject<PaymentResponse>(APICallerObj.Query(query));

            var PaymentDeleteReq = new PaymentDeleteReq()
            {
                SyncToken = PaymentResponseObj.QueryResponse.Payment[0].SyncToken,
                Id = PaymentResponseObj.QueryResponse.Payment[0].Id
            };

            string httpWebRequest = ConfigurationManager.AppSettings["SandboxBaseURL"] + "/v3/company/" + ConfigurationManager.AppSettings["CompanyID"] + "/payment?operation=delete&minorversion=" + ConfigurationManager.AppSettings["minorversion"];

            APICallerObj.PostApiCallService(PaymentDeleteReq, httpWebRequest);
        }


    }
}
