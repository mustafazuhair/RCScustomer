using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RCScustomer.Models;

namespace RCScustomer.DAL
{
    public class DashboardSetup
    {
        private RCSdbEntities db = new RCSdbEntities();


        public List<DashboardJobClass> FillFirstGrid()
        {
            List<DashboardJobClass> obj = new List<DashboardJobClass>();
            var temp = from x in db.Job
                      
                       where x.CustomerKey==GlobalClass.CustomerDetail.CustomerKey
                      
                       select new DashboardJobClass
                       {
                           CustomerName = x.Customer.Cname,
                           CustomerKey = x.CustomerKey,
                           JobName = x.JobName,
                           JobKey = x.JobKey,
                           TradeName=x.Trade.TName,
                           LocationKey = x.LocationKey,
                           ServiceLocation = x.Location.Lname,
                           Status = x.JobStatus.TName,
                           EDate = x.EntryDate,
                           SDate = x.ScheduleDate,
                           AccountManager = (from z in db.JobTeam
                                             join y in db.TeamMember on z.TeamKey equals y.ID
                                             where z.IsDelete == false && y.IsDelete == false && y.IsAccountManager == true
                                             select y.StaffList.PName).FirstOrDefault().ToString(),
                       };
            obj = temp.ToList();
            return obj;
        }
    }
}