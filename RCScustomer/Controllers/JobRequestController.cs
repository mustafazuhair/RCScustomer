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
    public class JobRequestController : Controller
    {
        private RCSdbEntities db = new RCSdbEntities();
        private JobRequestSetup manage = new JobRequestSetup();
        // GET: JobRequest
        public ActionResult Index()
        {
            if (GlobalClass.SystemSession)
            {
                DashBoardJobRequest model = new DashBoardJobRequest();
                model.JobRequestList = new List<JobRequestObject>();
                model.JobRequestList = manage.GetAllJobRequestForThisCustomer();
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }
        public ActionResult Details(Guid id)
        {
            if (GlobalClass.SystemSession)
            {
                JobRequestObject model = new JobRequestObject();
              
                model = manage.GetJobrequestDetails(id);
                ViewBag.JobPriorityKey = new SelectList(db.JobType.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName",model.JobPriorityKey);
             
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }
       

        public ActionResult Create()
        {
            if (GlobalClass.SystemSession)
            {
                Guid PriorityKey = Guid.Parse("98611896-68b9-42ae-b429-644069ae8587");
                ViewBag.JobPriorityKey = new SelectList(db.JobType.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName", PriorityKey);
                ViewBag.TradeKey = new SelectList(db.Trade.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName");
                return View();
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobRequestObject model,string Save, string Close,string Next,string SaveCloseTab1,string Cancel, string Cancel1)
        {


            if (GlobalClass.SystemSession)
            {

                if (!string.IsNullOrEmpty(Cancel)) return RedirectToAction("Index", "Home");
                if (!string.IsNullOrEmpty(Cancel1)) return RedirectToAction("Index", "Home");
                if (ModelState.IsValid)
                {
                    
                   
                        DataReturn data = manage.SaveMainData(model);
                        ViewBag.mess = data.mess;
                        if (data.flag == 1)
                        {
                            if (!string.IsNullOrEmpty(Save)) return RedirectToAction("EditJobRequest", new { id = data.key });
                            else if (!string.IsNullOrEmpty(SaveCloseTab1)) return RedirectToAction("EditJobRequest", new { id = data.key });
                            else if (!string.IsNullOrEmpty(Next)) return RedirectToAction("Index", "JobRequestFile", new { id = data.key });
                            else return RedirectToAction("Index", "Home");
                        }
                    
                }
                ViewBag.JobPriorityKey = new SelectList(db.JobType.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName",model.JobPriorityKey);
                ViewBag.TradeKey = new SelectList(db.Trade.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName",model.TradeKey);
                return View(model);

            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }



        public ActionResult EditJobRequest( Guid id)
        {
            if (GlobalClass.SystemSession)
            {
               
                JobRequestObject model = new JobRequestObject();
                model = manage.GetJobrequestDetails(id);
                ViewBag.JobPriorityKey = new SelectList(db.JobType.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName",model.JobPriorityKey);
                ViewBag.TradeKey = new SelectList(db.Trade.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName", model.TradeKey);
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJobRequest(JobRequestObject model, string Save, string Close)
        {
            if (GlobalClass.SystemSession)
            {
                if (ModelState.IsValid)
                {
                    DataReturn data = manage.UpdateMainData(model);
                    ViewBag.mess = data.mess;
                    if (data.flag == 1)
                        if (!string.IsNullOrEmpty(Save)) model = manage.GetJobrequestDetails(model.RequestKey);
                        else return RedirectToAction("Index", "Home");
                   
                }
                ViewBag.JobPriorityKey = new SelectList(db.JobType.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName",model.JobPriorityKey);
                ViewBag.TradeKey = new SelectList(db.Trade.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName", model.TradeKey);
                return View(model);
               
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }

        public ActionResult Delete(Guid id)
        {
            if (GlobalClass.SystemSession)
            {
                
                    var Jobrq = db.JobRequestAttachments.Where(f => f.RequestKey == id).ToList();
                db.JobRequestAttachments.RemoveRange(Jobrq);
                db.SaveChanges();
                db = new RCSdbEntities();
                JobRequest obj = db.JobRequest.Find(id);
                    db.JobRequest.Remove(obj);
                    db.SaveChanges();
              
                return RedirectToAction("Index");
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
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