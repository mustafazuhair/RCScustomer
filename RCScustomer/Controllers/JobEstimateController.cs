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
        // GET: JobRequest
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
    }
}