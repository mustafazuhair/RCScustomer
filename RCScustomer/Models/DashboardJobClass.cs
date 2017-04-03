using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCScustomer.Models
{
    public class DashboardClass
    {
        public List<DashboardJobClass> FirstGrid { get; set; }
        public DashboardJobClass MainObj { get; set; }
        public Customer CustomerObj { get; set; }
    }
    public class DashboardJobClass
    {
        public string CustomerName { get; set; }
        public string JobName { get; set; }
        public string TradeName { get; set; }
        public string ServiceLocation { get; set; }
        public string Status { get; set; }
        public string EnteredDate { get; set; }
        public string ScheduledDate { get; set; }
        public string AccountManager { get; set; }
        public bool? IsEstimate { get; set; }
        public string estimateStatus { get; set; }
        public Guid? JobStatusKey { get; set; }
        public SelectList JobStatusList { get; set; }

        public Guid? CustomerKey { get; set; }
        public Guid? JobKey { get; set; }
        public Guid? LocationKey { get; set; }
        public Guid? InvoiceKey { get; set; }
        public DateTime? EDate { get; set; }
        public DateTime? SDate { get; set; }

    }
}