using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCScustomer.Models
{
    public class EstimateClass
    {
        public System.Guid Pkey { get; set; }
        public System.Guid InvoiceKey { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        public Nullable<System.Guid> SalesStatusKey { get; set; }
        public Nullable<System.Guid> JobKey { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> Accept { get; set; }
        public Nullable<bool> Decline { get; set; }
        public Nullable<bool> Resubmit { get; set; }

        public string LocationName { get; set; }
        public string TradeName { get; set; }
        public string Jobname { get; set; }
        public string EntryDate { get; set; }
        public string SalesStatus { get; set; }
    }
}