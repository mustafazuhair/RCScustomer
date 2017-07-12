
using RCScustomer.DAL;
using RCScustomer.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RCScustomer.ExcelConvertor;
using System.IO;

namespace RCScustomer.Controllers
{
    public class JobDetailsController : Controller
    {

        private RCSdbEntities db = new RCSdbEntities();

        private ManageJobSetup manage = new ManageJobSetup();
        private ExcelUtility excelutility = new ExcelUtility();
        // GET: JobDetails
        public ActionResult DownloadCustomerCommunication(Guid id)
        {
            List<RCSExcel> mainlist = new List<RCSExcel>();
            Job job = db.Job.Find(id);

            mainlist = manage.CustomerCommunicationForDownload(id);
            DataTable dt = excelutility.ConvertToDataTable(mainlist);
          
            FileClass file = new FileClass();
            file = excelutility.WriteDataTableToExcel(dt, job.JobName, "Customer Communication");
            if (file.FileContent != null)
                return File(file.FileContent, "application/vnd.ms-excel");
            else
            {
                ImageFile faoimagefile = db.ImageFile.Single(f => f.ImageFileKey == 1);
                return File(faoimagefile.FileContent, faoimagefile.FileType);
            }
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewJobDetails(Guid id)
        {


            if (GlobalClass.SystemSession)
            {
               
                JobClass model = new JobClass();
                model = manage.FillMainJob(id);
                ViewBag.mess = "MY RCS JOB "+model.JobName;
                ViewBag.mesg = "THE FOLLOWING ARE READONLY INFORMATION PERTAINING TO THE JOB - " + model.JobName;
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }

        public ActionResult NotesandActivity(Guid id)
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = " ";
               
                RCSMessegeClass model = new RCSMessegeClass();             
                model = manage.LoadCustomerMessegingData(id);
                ViewBag.mess = "MY RCS JOB " + model.Job.JobName+" - Activities.";
                ViewBag.title = "Activities Related to JOB - " + model.Job.JobName;
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
        public ActionResult NotesandActivity(RCSMessegeClass model, string save, string savenEmail)
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = "MY RCS JOB " + model.Job.JobName + " - Activities.";
                ViewBag.title = "Activities Related to JOB - " + model.Job.JobName;

                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(save))
                    {
                        if (model.mainObj.PKey == null || model.mainObj.PKey == Guid.Empty)
                        {
                            DataReturn data = manage.SaveCustomermessegingData(model);
                            ViewBag.mess = data.mess;
                            model = manage.LoadCustomerMessegingData((Guid)model.mainObj.JobKey);
                        }
                        else
                        {
                            DataReturn data = manage.UpdateCustomermessegingData(model);
                            ViewBag.mess = data.mess;
                            model = manage.LoadCustomerMessegingData((Guid)model.mainObj.JobKey);
                        }
                    }
                    if (!string.IsNullOrEmpty(savenEmail))
                    {
                        //DataReturn data = manage.SaveCustomermessegingData(model);
                        //CustomerMesseging lastObj = db.CustomerMesseging.Find(data.key);
                        //bool f = Mail.SendEmailToCustomerForJobUpdate(lastObj);
                        //ViewBag.mess = data.mess;
                        //model = manage.LoadCustomerMessegingData((Guid)model.mainObj.JobKey);
                    }

                }

                model = manage.LoadCustomerMessegingData((Guid)model.mainObj.JobKey);
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }


        public ActionResult FilesandAttachments(Guid id)
        {
            if (GlobalClass.SystemSession)
            {
                JobFileClass model = new JobFileClass();
                Job job = db.Job.Find(id);

                model = manage.GetJobFileAttachments(id);
                model.JobKey = id;
                model.JobName = job.JobName;
                ViewBag.mess = " ";

                ViewBag.DocumentTypeKey = new SelectList(db.DocumentType.Where(m => m.DocumentForID == 6 && m.IsDelete == false && m.CompanyKey == GlobalClass.Company.CompanyKey).OrderBy(m => m.TName), "ID", "TName");

                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }
        [HttpPost]
        public ActionResult FilesandAttachments(HttpPostedFileBase file, JobFileClass model)
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = "";
                Job job = db.Job.Find(model.JobKey);
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        byte[] data = null;
                        using (Stream inputStream = file.InputStream)
                        {
                            MemoryStream memoryStream = inputStream as MemoryStream;
                            if (memoryStream == null)
                            {
                                memoryStream = new MemoryStream();
                                inputStream.CopyTo(memoryStream);
                            }
                            data = memoryStream.ToArray();
                        }
                        model.FileType = file.ContentType;
                        model.Title = file.FileName;
                        model.FileContent = data;
                        DataReturn dt = manage.SaveAttachmentInJobFile(model);
                        ViewBag.mess = dt.mess;
                    }
                }


                model = new JobFileClass();
                model = manage.GetJobFileAttachments((Guid)job.JobKey);
                model.JobKey = job.JobKey;
                model.JobName = job.JobName;

                ViewBag.DocumentTypeKey = new SelectList(db.DocumentType.Where(m => m.DocumentForID == 6 && m.IsDelete == false && m.CompanyKey == GlobalClass.Company.CompanyKey).OrderBy(m => m.TName), "ID", "TName");

                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }
    }
}