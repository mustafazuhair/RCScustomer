using RCScustomer.DAL;
using RCScustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCScustomer.Controllers
{
    public class JobRequestFileController : Controller
    {
        private RCSdbEntities db = new RCSdbEntities();
        JobRequestSetup setup = new JobRequestSetup();
        // GET: JobRequestFile
        public ActionResult Index(Guid id)
        {
            if (GlobalClass.SystemSession)
            {
                JobRequestAttachmentMain model = new JobRequestAttachmentMain();
                //model.JobRequestAttachmentsList
                //JobRequestAttachments job = db.JobRequestAttachments.Find(id);

                //model = setup.GetJobFileAttachments(id);
                //model.JobKey = id;
                //model.JobName = job.JobName;
                //ViewBag.mess = " ";

                model.DocumentTypeObjectList = setup.GetAllDocumntType();

              //  ViewBag.DocumentTypeKey = new SelectList(db.DocumentType.Where(m => m.DocumentForID == 2 && m.IsDelete == false && m.CompanyKey == GlobalClass.Company.CompanyKey).OrderBy(m => m.TName), "ID", "TName");

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