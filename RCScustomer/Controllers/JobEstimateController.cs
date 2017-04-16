using RCScustomer.DAL;
using RCScustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace RCScustomer.Controllers
{
    public class JobEstimateController : Controller
    {
        // GET: JobEstimate
        private RCSdbEntities db = new RCSdbEntities();
        private ManageJobEstimates manage = new ManageJobEstimates();
        // GET: JobEstimate
        public ActionResult Index()
        {
            if (GlobalClass.SystemSession)
            {
               List<EstimateClass> model = new List<EstimateClass>();
                
                model = manage.GetAllJobEstimatesForThisCustomer();
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
        public ActionResult ViewEstimates(Guid id)
        {
            if (GlobalClass.SystemSession)
            {
                PreviewSalesInvoiceClass model = new PreviewSalesInvoiceClass();
                model.InvoiceDetailList = new List<JobSalesInvoiceClass>();
                model = manage.FillSalesInvoiceOrEstimateDataForPreview(id);
                ViewBag.mess = "";
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
    }
}