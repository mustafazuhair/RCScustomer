using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RCScustomer.Models;
using RCScustomer.DAL;

using System.Data;
using System.IO;
namespace RCScustomer.Controllers
{
    public class HomeController : Controller
    {
        private RCSdbEntities db = new RCSdbEntities();
        private DashboardSetup setup = new DashboardSetup();
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            try
            {
                CustomerLogin temp = db.CustomerLogin.SingleOrDefault(m=>m.Username==username && m.Password==password);
               
                if (temp == null)
                {
                    Exception e = new Exception("Incorrect user access.");
                    return View("Error", new HandleErrorInfo(e, "Home", "Login"));
                }
                else
                {
                    CustomerContact obj = db.CustomerContact.Find(temp.ContactKey);
                  
                        Customer customer = db.Customer.Find(temp.CustomerKey);
                        GlobalClass.CustomerDetail = customer;
                   
                    GlobalClass.LoginUser = obj;

                    GlobalClass.Company = db.Company.SingleOrDefault(m => m.CompanyKey == obj.CompanyKey);
                  
                    GlobalClass.SystemSession = true;
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (DivideByZeroException e)
            {
                return View("Error", new HandleErrorInfo(e, "Home", "Login"));
            }
        }
        public ActionResult Index()
        {
            if (GlobalClass.SystemSession)
            {
                DashboardClass model = new DashboardClass();
                model.CustomerObj = GlobalClass.CustomerDetail;
               // model.CustomerObj.Address = GlobalClass.CustomerDetail.Address + " " + GlobalClass.CustomerDetail.ZIPcode + " " + GlobalClass.CustomerDetail.CityList.CityName + " " + GlobalClass.CustomerDetail.StateList.StateName;
                model.FirstGrid = new List<DashboardJobClass>();
                model.FirstGrid = setup.FillFirstGrid();
                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}