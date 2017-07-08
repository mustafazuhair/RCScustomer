//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RCScustomer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobWorkOrder
    {
        public System.Guid WorkOrderKey { get; set; }
        public Nullable<System.Guid> LocationKey { get; set; }
        public Nullable<System.Guid> JobKey { get; set; }
        public Nullable<System.Guid> VendorKey { get; set; }
        public Nullable<bool> IsCustomerJobNameHidden { get; set; }
        public Nullable<bool> IsJobPriorityHidden { get; set; }
        public Nullable<bool> IsDNEHidden { get; set; }
        public Nullable<bool> IsEntryDateHidden { get; set; }
        public Nullable<bool> IsIVRTrackingNo { get; set; }
        public Nullable<bool> IsIVRPin { get; set; }
        public Nullable<bool> IsManagerHidden { get; set; }
        public string ManagerName { get; set; }
        public string CF1 { get; set; }
        public string CF2 { get; set; }
        public string CF3 { get; set; }
        public Nullable<bool> IsCF1 { get; set; }
        public Nullable<bool> IsCF2 { get; set; }
        public Nullable<bool> IsCF3 { get; set; }
        public string ServiceRequest { get; set; }
        public Nullable<bool> IsServiceRequest { get; set; }
        public string IVRinstruction { get; set; }
        public Nullable<bool> IsIVRinstruction { get; set; }
        public string VendorPrintName { get; set; }
        public Nullable<bool> IsVendorPrint { get; set; }
        public string VendorSign { get; set; }
        public Nullable<bool> IsVendorSign { get; set; }
        public Nullable<System.DateTime> DateSigned { get; set; }
        public Nullable<bool> IsDateSign { get; set; }
        public string IVRPhone { get; set; }
        public Nullable<bool> IsIVRPhone { get; set; }
        public Nullable<bool> EmailSent { get; set; }
        public string WorkOrderNo { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<bool> IsLocation { get; set; }
        public Nullable<bool> IsVendor { get; set; }
        public Nullable<bool> IsVisitDate { get; set; }
        public Nullable<bool> IsReturnDate { get; set; }
        public Nullable<bool> IsVendorPh { get; set; }
        public Nullable<bool> IsLocationPh { get; set; }
    
        public virtual Job Job { get; set; }
        public virtual Location Location { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
