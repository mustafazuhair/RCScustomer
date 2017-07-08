using RCScustomer.DAL;
using RCScustomer.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
             
                ViewBag.mess = " ";

                model = setup.GetJobFileAttachmentObjects(id);

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
        public ActionResult Index(HttpPostedFileBase file, JobRequestAttachmentMain model)
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = "";
                model.fileObj = new JobRequestAttachmentsObject();
                model.fileObj.RequestKey = model.RequestObj.RequestKey;
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
                        model.fileObj.FileType = file.ContentType;
                        model.fileObj.Filename = file.FileName;
                        model.fileObj.DocFile = data;
                        DataReturn dt = setup.SaveAttachmentInRequest(model);
                        ViewBag.mess = dt.mess;
                    }
                }


                model = setup.GetJobFileAttachmentObjects(model.RequestObj.RequestKey);

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