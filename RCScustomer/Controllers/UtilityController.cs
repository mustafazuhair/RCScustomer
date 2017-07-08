using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RCScustomer.Models;
using Newtonsoft.Json;
using RCScustomer.DAL;

namespace RCScustomer.Controllers
{
    public class UtilityController : Controller
    {
        // GET: Utility
        private RCSdbEntities db = new RCSdbEntities();
        public ActionResult LoadCustomerMessege(Guid SelectID)
        {
            ManageJobSetup cd = new ManageJobSetup();

            JsonResult result = new JsonResult();
            CustomerNoteClass obj = new CustomerNoteClass();
            obj = cd.FillCustomer_sNotes(SelectID);
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult UpdateJobStatus(Guid JobStatusKey, Guid JobKey)
        {
            JsonResult result = new JsonResult();
            int x = 0;
            try
            {
                Job job = db.Job.Find(JobKey);
                job.JobStatusKey = JobStatusKey;
                db.SaveChanges();
                x = 1;
            }
            catch (Exception ex)
            {
                string sgh = ex.ToString();
            }
            result.Data = x;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult GeVendorName(Guid VendorKey)
        {
            JsonResult result = new JsonResult();

            result.Data = db.Vendor.Find(VendorKey).Vname;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult GetStateName(int Dis)
        {
            JsonResult result = new JsonResult();

            result.Data = db.StateList.Find(Dis).StateName;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
       
        public ActionResult FillChargeRatesForJobs(Guid ChargeTypeKey, Guid TradeKey, Guid JobKey)
        {
            JsonResult result = new JsonResult();
            Job job = db.Job.Find(JobKey);
            decimal temp = (decimal)db.CustomerTradeCharge.Where(x => x.TradeKey == TradeKey && x.IsActive == true && x.SalesChargeTypeKey == ChargeTypeKey && x.CustomerKey == job.CustomerKey).Select(m => m.Amt).DefaultIfEmpty(0).Sum();

            result.Data = temp;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }  

        public ActionResult LoadCustomerNotes(Guid SelectID)
        {
            ManageCustomerSetup cd = new ManageCustomerSetup();

            JsonResult result = new JsonResult();
            CustomerNoteClass obj = new CustomerNoteClass();
            obj = cd.FillCustomerNotes(SelectID);
            result.Data = obj;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
       
        public ActionResult GetZIPcode(int Dis)
        {
            JsonResult result = new JsonResult();

            result.Data = db.ZIPList.Find(Dis).ZIP;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult GetCityName(int Dis)
        {
            JsonResult result = new JsonResult();

            result.Data = db.CityList.Find(Dis).CityName;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public ActionResult CheckUsername(string user, Guid key)
        {
            JsonResult result = new JsonResult();
            var temp = from x in db.StaffList where x.Username == user && x.PersonnelKey != key select x;
            if (temp.Count() > 0) result.Data = 99;
            else
                result.Data = 1;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult CheckPassword(string user, Guid key)
        {
            JsonResult result = new JsonResult();
            var temp = from x in db.StaffList where x.Password == user && x.PersonnelKey != key select x;
            if (temp.Count() > 0) result.Data = 99;
            else
                result.Data = 1;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult CheckUsernameCreate(string user)
        {
            JsonResult result = new JsonResult();
            var temp = from x in db.StaffList where x.Username == user select x;
            if (temp.Count() > 0) result.Data = 99;
            else
                result.Data = 1;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
        public ActionResult CheckCustomerCreate(string user)
        {
            JsonResult result = new JsonResult();
            var temp = from x in db.CustomerLogin where x.Username == user && x.UserKey!=GlobalClass.UserDetail.UserKey select x;
            if (temp.Count() > 0) result.Data = 99;
            else
                result.Data = 1;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }
}