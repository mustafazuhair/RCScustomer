using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RCScustomer.Models;
using System.IO;
namespace RCScustomer.Controllers
{
    public class AssignAccessController : Controller
    {
        // GET: AssignAccess
        private RCSdbEntities db = new RCSdbEntities();
        public CustomerLoginClass LoadCustomerLogin(Guid id)
        {
            CustomerLoginClass model = new CustomerLoginClass();
            try
            {
                model.ContactObj = db.CustomerContact.Find(id);
                model.Username = GlobalClass.UserDetail.Username;
                model.UserKey = GlobalClass.UserDetail.UserKey;
               

            }
            catch (Exception ex)
            {

                string str = ex.Message.ToString();

            }
            return model;
        }
        public ActionResult ChangePass()
        {
            if (GlobalClass.SystemSession)
            {
                CustomerLoginClass model = new CustomerLoginClass();
                ViewBag.mess = "";
                model = LoadCustomerLogin(GlobalClass.LoginUser.ContactKey);
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }
        [HttpPost]
        public ActionResult ChangePass(CustomerLoginClass model, string Save)
        {
            if (GlobalClass.SystemSession)
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(Save))
                    {
                        DataReturn obj = AddUserToLogin(model);
                        ViewBag.mess = obj.mess;
                    }
                   
                }
                model = LoadCustomerLogin(GlobalClass.LoginUser.ContactKey);
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "Home", "Logout"));
            }
        }
        public DataReturn AddUserToLogin(CustomerLoginClass model)
        {
            DataReturn xx = new DataReturn();
            try
            {
               
                    CustomerLogin obj = db.CustomerLogin.Find(model.UserKey);
                    obj.Username = model.Username;
                    obj.Password = model.Password;
                    db.SaveChanges();

                GlobalClass.UserDetail = obj;
                xx.key = model.ContactObj.CustomerKey;
                xx.mess = "Data is Saved Successfully";
                xx.flag = 1;


            }
            catch (Exception ex)
            {

                xx.mess = ex.Message.ToString();
                xx.flag = 0;
            }
            return xx;
        }

       
    }
}