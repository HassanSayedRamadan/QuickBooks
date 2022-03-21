using Intuit.Ipp.Core;
using Intuit.Ipp.Data;
using Intuit.Ipp.QueryFilter;
using Intuit.Ipp.Security;
using Newtonsoft.Json;
using QuickBooksOnlineAPIs.Controllers.API;
using QuickBooksOnlineAPIs.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;

namespace QuickBooksOnlineAPIs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Account()
        {
            ViewBag.Message = "Account page.";

            var AccountObj = new Models.Account();

            return View(AccountObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAccount(Models.Account AccountObj)
        {
            if (!ModelState.IsValid)
            {
                return View("Account", AccountObj);
            }
            var APICallerObj = new APICaller();

            //Call API
            string httpWebRequest = ConfigurationManager.AppSettings["SandboxBaseURL"] + "/v3/company/" + ConfigurationManager.AppSettings["CompanyID"] + "/account?minorversion=" + ConfigurationManager.AppSettings["minorversion"];
            APICallerObj.PostApiCallService(AccountObj, httpWebRequest);
            return View("Index");
        }


        public ActionResult Customer()
        {
            ViewBag.Message = "Customer page.";

            var CustomerObj = new Models.Customer();
            CustomerObj.BillAddr = new BillAddr();
            CustomerObj.PrimaryEmailAddr = new PrimaryEmailAddr();
            CustomerObj.PrimaryPhone = new PrimaryPhone();


            return View(CustomerObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(Models.Customer CustomerObj)
        {
            if (!ModelState.IsValid)
            {
                return View("Customer", CustomerObj);
            }
            var APICallerObj = new APICaller();

            //Call API
            string httpWebRequest = ConfigurationManager.AppSettings["SandboxBaseURL"] + "/v3/company/" + ConfigurationManager.AppSettings["CompanyID"] + "/customer?minorversion=" + ConfigurationManager.AppSettings["minorversion"];
            APICallerObj.PostApiCallService(CustomerObj, httpWebRequest);
            return RedirectToAction("Index");
        }

        public ActionResult Invoice()
        {
            ViewBag.Message = "Invoice page.";
            return View();
        }

        public ActionResult NewInvoice()
        {
            ViewBag.Message = "New Invoice page.";
            var APICallerObj = new APICaller();

            var InvoiceObj = new Models.InvoiceCustomer();
            InvoiceObj.Line = new List<Models.Line>();
            var LineObj = new Models.Line();
            LineObj.SalesItemLineDetail = new Models.SalesItemLineDetail();
            LineObj.SalesItemLineDetail.ItemRef = new ItemRef();
            InvoiceObj.Line.Add(LineObj);
            string query = "select * from Customer Where Active = true";
            var CustomerResponseObj = JsonConvert.DeserializeObject<CustomerResponse>(APICallerObj.Query(query));

            InvoiceObj.Customers = CustomerResponseObj.QueryResponse.Customer;

            return View(InvoiceObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInvoice(Models.InvoiceCustomer InvoiceObj)
        {
            if (!ModelState.IsValid)
            {
                return View("Invoice", InvoiceObj);
            }

            //Call API
            var InvoiceReq = new Models.Invoice();
            InvoiceReq.Line = new List<Models.Line>();
            var LineObj = new Models.Line();
            LineObj.SalesItemLineDetail = new Models.SalesItemLineDetail();
            LineObj.SalesItemLineDetail.ItemRef = new ItemRef();
            LineObj.SalesItemLineDetail.ItemRef.name = InvoiceObj.Line[0].SalesItemLineDetail.ItemRef.name;
            LineObj.SalesItemLineDetail.ItemRef.value = InvoiceObj.Line[0].SalesItemLineDetail.ItemRef.value;
            LineObj.Amount = InvoiceObj.Line[0].Amount;
            LineObj.DetailType = InvoiceObj.Line[0].DetailType;

            InvoiceReq.Line.Add(LineObj);
            InvoiceReq.CustomerRef = new CustomerRef();
            InvoiceReq.CustomerRef.value = InvoiceObj.CustomerID;

            string httpWebRequest = ConfigurationManager.AppSettings["SandboxBaseURL"] + "/v3/company/" + ConfigurationManager.AppSettings["CompanyID"] + "/invoice?minorversion=" + ConfigurationManager.AppSettings["minorversion"];
            var APICallerObj = new APICaller();

            APICallerObj.PostApiCallService(InvoiceReq, httpWebRequest);
            return View("Index");
        }


        public ActionResult Payment()
        {
            ViewBag.Message = "Payment page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPayment(Models.PaymentCustomer PaymentObj)
        {
            if (!ModelState.IsValid)
            {
                return View("Payment", PaymentObj);
            }

            //Call API
            var PaymentReq = new Models.Payment();

            PaymentReq.CustomerRef = new CustomerRef();
            PaymentReq.CustomerRef.value = PaymentObj.CustomerID;
            PaymentReq.TotalAmt = PaymentObj.TotalAmt;

            string httpWebRequest = ConfigurationManager.AppSettings["SandboxBaseURL"] + "/v3/company/" + ConfigurationManager.AppSettings["CompanyID"] + "/payment?minorversion=" + ConfigurationManager.AppSettings["minorversion"];
            var APICallerObj = new APICaller();
            APICallerObj.PostApiCallService(PaymentReq, httpWebRequest);
            return View("Index");
        }

        public ActionResult NewPayment()
        {
            ViewBag.Message = "New Payment page.";

            var APICallerObj = new APICaller();

            var PaymentObj = new PaymentCustomer();
            string query = "select * from Customer Where Active = true";
            var CustomerResponseObj = JsonConvert.DeserializeObject<CustomerResponse>(APICallerObj.Query(query));

            PaymentObj.Customers = CustomerResponseObj.QueryResponse.Customer;

            return View(PaymentObj);
        }

        public ActionResult EditInvoice(string Id)
        {
            ViewBag.Message = "Edit Invoice page.";
            var APICallerObj = new APICaller();

            var InvoiceObj = new Models.InvoiceCustomer();
            InvoiceObj.Line = new List<Models.Line>();
            var LineObj = new Models.Line();
            LineObj.SalesItemLineDetail = new Models.SalesItemLineDetail();
            LineObj.SalesItemLineDetail.ItemRef = new ItemRef();
            InvoiceObj.Line.Add(LineObj);
            string query = "select * from Customer";
            var CustomerResponseObj = JsonConvert.DeserializeObject<CustomerResponse>(APICallerObj.Query(query));

            InvoiceObj.Customers = CustomerResponseObj.QueryResponse.Customer;

            return View(InvoiceObj);
        }

        public ActionResult EditPayment(string Id)
        {
            ViewBag.Message = "Edit Payment page.";
            var APICallerObj = new APICaller();

            var PaymentObj = new Models.PaymentCustomer();
            string query = "select * from Customer";
            var CustomerResponseObj = JsonConvert.DeserializeObject<CustomerResponse>(APICallerObj.Query(query));

            PaymentObj.Customers = CustomerResponseObj.QueryResponse.Customer;

            return View(PaymentObj);
        }
    }
}