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
        [HttpPost]
        public ActionResult ViewEstimates(PreviewSalesInvoiceClass model)
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = "";
                if (ModelState.IsValid)
                {
                    DataReturn data = new DataReturn();
                    data = manage.SaveEstimateRemarks(model);
                    ViewBag.mess = data.mess;
                    model.EstimateObj.IsNew = false;
                }
                PreviewSalesInvoiceClass obj = new PreviewSalesInvoiceClass();
                obj.InvoiceDetailList = new List<JobSalesInvoiceClass>();
                obj = manage.FillSalesEstimateDataForPreview(model.EstimateObj.InvoiceKey);
                
                obj.EstimateObj = new EstimateClass();
                obj.EstimateObj.InvoiceKey = model.EstimateObj.InvoiceKey;
                obj.EstimateObj.Pkey = model.EstimateObj.Pkey;
                obj.EstimateObj.Remark = model.EstimateObj.Remark;
                obj.EstimateStatus = model.EstimateStatus;
                obj.EstimateObj.IsNew = model.EstimateObj.IsNew;
                obj.EstimateObj.JobKey = model.EstimateObj.JobKey;
                model = obj;
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}