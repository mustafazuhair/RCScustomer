using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RCScustomer.Models;
using RCScustomer.DAL;
namespace RCScustomer.Controllers
{
    public class DropdownUtilityController : Controller
    {
        // GET: DropdownUtility
        private RCSdbEntities db = new RCSdbEntities();

        // GET: DropdownUtility
       
      
       
        public ActionResult GetTrade(string query)
        {
            var users = (from u in db.Trade

                         where u.TName.ToUpper().Contains(query.ToUpper())

                         && u.IsDelete == false
                         orderby u.TName
                         select new
                         {
                             label = u.TName,
                             value = u.ID

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomer(string query)
        {
            var users = (from u in db.Customer

                         where u.Cname.ToUpper().Contains(query.ToUpper())

                         && u.IsDelete == false
                         orderby u.Cname
                         select new
                         {
                             label = u.Cname,
                             value = u.CustomerKey

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCustomerName(string query)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var users = (from u in db.Customer

                         where u.Cname.ToUpper().Contains(query.ToUpper())

                         && u.IsDelete == false
                         orderby u.Cname
                         select new
                         {
                             label = u.Cname,
                             value = u.CustomerKey,
                             CustomerName = u.Cname,
                             CustomeAddress = u.Address,
                             CPhone = u.CustomerContact,
                             CEmail = "",
                             RepresentedBy = "",
                             Title = "",

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStaff(string query)
        {
            var users = (from u in db.StaffList

                         where u.PName.ToUpper().Contains(query.ToUpper())

                         && u.IsDelete == false
                         orderby u.PName
                         select new
                         {
                             label = u.PName,
                             value = u.PersonnelKey,
                             Designation = u.Designation,
                             EmailAddress = u.Mail
                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStateName(string query)
        {
            var users = (from u in db.StateList

                         where (u.StateCode.ToUpper().Contains(query.ToUpper()) || u.StateName.ToUpper().Contains(query.ToUpper()))

                         && u.IsDelete == false
                         orderby u.StateName
                         select new
                         {
                             label = u.StateName + "( " + u.StateCode + " )",
                             value = u.PKey

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCityName(string query, int StateKey)
        {
            var users = (from u in db.CityList

                         where u.CityName.ToUpper().Contains(query.ToUpper()) && u.StateList.IsDelete == false
                         && u.IsDelete == false && u.StateCode == StateKey
                         orderby u.CityName
                         select new
                         {
                             label = u.CityName,
                             value = u.CityKey

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetZipcode(string query, int dKey)
        {
            var users = (from u in db.ZIPList

                         where u.ZIP.ToUpper().Contains(query.ToUpper()) && u.CityList.IsDelete == false
                         && u.IsDelete == false && u.CityKey == dKey
                         orderby u.ZIP
                         select new
                         {
                             label = u.ZIP,
                             value = u.ZipKey

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCustomerContactName(string query, Guid CustomerKey)
        {
            var users = (from u in db.CustomerContact

                         where u.Cname.ToUpper().Contains(query.ToUpper()) && u.IsDelete == false
                         && u.IsDelete == false && u.CustomerKey == CustomerKey
                         orderby u.Cname
                         select new
                         {
                             label = u.Cname,
                             value = u.ContactKey,
                             CustomerContactName = u.Cname,
                             CContactKey = u.ContactKey

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTradeName(string query, Guid CustomerKey)
        {
            var users = (from u in db.CustomerLabor

                         where u.CustomerKey == CustomerKey && u.Trade.TName.ToUpper().Contains(query.ToUpper()) && u.Standard > 0

                         && u.IsDelete == false
                         orderby u.Trade.TName
                         select new
                         {
                             label = u.Trade.TName,
                             value = u.Trade.ID

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetJobStatusName(string query)
        {
            var users = (from u in db.JobStatus

                         where u.TName.ToUpper().Contains(query.ToUpper())

                         && u.IsDelete == false
                         orderby u.TName
                         select new
                         {
                             label = u.TName,
                             value = u.ID,
                             JobStatusName = u.TName,
                             JobStatusKey = u.ID

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }


      

       

       

        public ActionResult GetCityStateName(string query, int CityKey)
        {
            var users = (from u in db.StateList
                         join r in db.CityList on u.PKey equals r.StateCode
                         //  join l in db.CityList on u.CityKey = l.CityKey

                         where u.StateName.ToUpper().Contains(query.ToUpper()) && u.IsDelete == false
                         && u.IsDelete == false && r.CityKey == CityKey
                         orderby r.CityName
                         select new
                         {
                             label = u.StateName + "( " + u.StateCode + " )",
                             value = u.PKey

                         }).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }



     


       

    }
}