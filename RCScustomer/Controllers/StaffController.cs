using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RCScustomer.Models;
namespace RCScustomer.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        private RCSdbEntities db = new RCSdbEntities();
        public ActionResult Index()
        {
            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = "My Profile";
                CustomerObjectClass model = new CustomerObjectClass();
                CustomerContact contact = db.CustomerContact.Find(GlobalClass.LoginUser.ContactKey);
                model.ContactObj = new ContactClass();
                model.ContactObj.ContactKey = contact.ContactKey;
                model.ContactObj.CustomerKey = contact.CustomerKey;
                model.ContactObj.Cname = contact.Cname;
                model.ContactObj.Title = contact.Title;
                model.ContactObj.Phone = contact.Phone+"( "+contact.PhoneEXT+ " )";
                model.ContactObj.FAX = contact.FAX;
                model.ContactObj.ALTPhone = contact.ALTPhone + "( " + contact.ALTPhoneEXT + " )";
                model.ContactObj.Email = contact.Email;
              
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