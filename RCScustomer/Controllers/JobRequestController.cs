using RCScustomer.DAL;
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
        private RCSdbEntities db = new RCSdbEntities();
        private JobRequestSetup manage = new JobRequestSetup();
        // GET: JobRequest
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.JobPriorityKey = new SelectList(db.JobType.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName");
                return View();
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobRequestObject model)
        {


            if (GlobalClass.SystemSession)
            {
                DataReturn data = manage.SaveMainData(model);
                ViewBag.mess = data.mess;
                if (data.flag == 1)
                    return RedirectToAction("EditJobRequest", new { id = data.key });

                else
                {
                    return View(model);
                }
                
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }



        public ActionResult EditJobRequest( Guid id)
        {
            if (GlobalClass.SystemSession)
            {
                JobRequestObject model = new JobRequestObject();
                model = manage.GetJobrequestDetails(id);
                ViewBag.JobPriorityKey = new SelectList(db.JobType.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName");
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJobRequest(JobRequestObject model)
        {
            if (GlobalClass.SystemSession)
            {
                //JobRequestObject model = new JobRequestObject();
                //model = manage.GetJobrequestDetails(id);
                //ViewBag.JobPriorityKey = new SelectList(db.JobType.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName");
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