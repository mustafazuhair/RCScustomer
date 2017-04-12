using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RCScustomer.Models;
using System.IO;
using System;

namespace RCScustomer.Controllers
{
    public class ShowImageController : Controller
    {
        // GET: ShowImage
        private RCSdbEntities db = new RCSdbEntities();
        public ActionResult GetJobFileAttachement(Guid id)
        {

            JobFile obj = db.JobFile.Find(id);

            if (obj.FileContent != null)
            {

                return File(obj.FileContent, obj.FileType);
            }
            else
            {
                ImageFile faoimagefile = db.ImageFile.Single(f => f.ImageFileKey == 1);
                return File(faoimagefile.FileContent, faoimagefile.FileType);
            }
        }
        public ActionResult GetJobRequestFileAttachement(Guid id)
        {

            JobRequestAttachments obj = db.JobRequestAttachments.Find(id);

            if (obj.DocFile != null)
                return File(obj.DocFile, obj.FileType);
            else
            {
                ImageFile faoimagefile = db.ImageFile.Single(f => f.ImageFileKey == 1);
                return File(faoimagefile.FileContent, faoimagefile.FileType);
            }
        }


        public ActionResult GetCustomerFileAttachement(Guid id)
        {

            CustomerAttachments obj = db.CustomerAttachments.Find(id);

            if (obj.AttFile != null)
                return File(obj.AttFile, obj.FileType);
            else
            {
                ImageFile faoimagefile = db.ImageFile.Single(f => f.ImageFileKey == 1);
                return File(faoimagefile.FileContent, faoimagefile.FileType);
            }
        }
        public ActionResult GetCompanyLogo(Guid id)
        {

            Company obj = db.Company.SingleOrDefault(m => m.CompanyKey == id);

            if (obj.Logo != null)
                return File(obj.Logo, obj.LogoType);
            else
            {
                ImageFile faoimagefile = db.ImageFile.Single(f => f.ImageFileKey == 1);
                return File(faoimagefile.FileContent, faoimagefile.FileType);
            }
        }
        public ActionResult GetImageLogo(int id)
        {

            ImageFile faoimagefile = db.ImageFile.Single(f => f.ImageFileKey == id);
            return File(faoimagefile.FileContent, faoimagefile.FileType);

        }
        public ActionResult GetUserPic(Guid id)
        {

            StaffList obj = db.StaffList.SingleOrDefault(m => m.PersonnelKey == id);

            if (obj.Pic != null)
                return File(obj.Pic, obj.PicType);
            else
            {
                ImageFile faoimagefile = db.ImageFile.Single(f => f.ImageFileKey == 1);
                return File(faoimagefile.FileContent, faoimagefile.FileType);
            }
        }
        public ActionResult GetEmailPic(Guid id)
        {

            EmailConfiguration obj = db.EmailConfiguration.SingleOrDefault(m => m.ID == id);

            if (obj.Logo != null)
                return File(obj.Logo, obj.LogoType);
            else
            {
                ImageFile faoimagefile = db.ImageFile.Single(f => f.ImageFileKey == 1);
                return File(faoimagefile.FileContent, faoimagefile.FileType);
            }
        }
    }
}