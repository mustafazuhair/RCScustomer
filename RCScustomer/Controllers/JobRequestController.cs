using RCScustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCScustomer.Controllers
{
    public class JobRequestController : Controller
    {
        // GET: JobRequest
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            if (GlobalClass.SystemSession)
            {

                 

                return View();
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
    }
}