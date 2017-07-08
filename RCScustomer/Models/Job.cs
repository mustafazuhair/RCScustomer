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
    
    public partial class Job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job()
        {
            this.CustomerMesseging = new HashSet<CustomerMesseging>();
            this.JobAccountManager = new HashSet<JobAccountManager>();
            this.JobConfiguration = new HashSet<JobConfiguration>();
            this.JobLocation = new HashSet<JobLocation>();
            this.JobSalesInvoice = new HashSet<JobSalesInvoice>();
            this.JobSalesInvoiceDetail = new HashSet<JobSalesInvoiceDetail>();
            this.JobSignOff = new HashSet<JobSignOff>();
            this.JobTeam = new HashSet<JobTeam>();
            this.JobVendor = new HashSet<JobVendor>();
            this.JobWorkOrder = new HashSet<JobWorkOrder>();
            this.JobTechnician = new HashSet<JobTechnician>();
            this.RCSmesseging = new HashSet<RCSmesseging>();
            this.VendorMesseging = new HashSet<VendorMesseging>();
            this.CustomerContactMesseging = new HashSet<CustomerContactMesseging>();
            this.JobFile = new HashSet<JobFile>();
            this.JobSalesInvoiceEstimateStatus = new HashSet<JobSalesInvoiceEstimateStatus>();
        }
    
        public System.Guid JobKey { get; set; }
        public string JobName { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        public Nullable<System.Guid> CContactKey { get; set; }
        public string CustomerDNE { get; set; }
        public Nullable<System.Guid> JobTypeKey { get; set; }
        public Nullable<System.Guid> TradeKey { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.Guid> JobStatusKey { get; set; }
        public string PO { get; set; }
        public string Description { get; set; }
        public string IVRTrackingNo { get; set; }
        public string IVRPin { get; set; }
        public Nullable<System.DateTime> ScheduleDate { get; set; }
        public Nullable<System.DateTime> ReturnScheduleDate { get; set; }
        public Nullable<System.Guid> LocationKey { get; set; }
        public Nullable<System.Guid> LocationContactKey { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string VendorDNE { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public string RevCustomerDNE { get; set; }
        public string RevVendorDNE { get; set; }
        public Nullable<bool> Invoiced { get; set; }
        public Nullable<bool> Estimates { get; set; }
        public Nullable<bool> WorkOrder { get; set; }
        public Nullable<bool> VBill { get; set; }
        public string PayableStatus { get; set; }
        public string ReceivableStatus { get; set; }
        public Nullable<System.Guid> AccountingStatusKey { get; set; }
        public Nullable<System.Guid> CustomerJobStatusKey { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual CustomerContact CustomerContact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerMesseging> CustomerMesseging { get; set; }
        public virtual JobStatus JobStatus { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual Location Location { get; set; }
        public virtual LocationContact LocationContact { get; set; }
        public virtual Trade Trade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobAccountManager> JobAccountManager { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobConfiguration> JobConfiguration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobLocation> JobLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobSalesInvoice> JobSalesInvoice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobSalesInvoiceDetail> JobSalesInvoiceDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobSignOff> JobSignOff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobTeam> JobTeam { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobVendor> JobVendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobWorkOrder> JobWorkOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobTechnician> JobTechnician { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RCSmesseging> RCSmesseging { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorMesseging> VendorMesseging { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerContactMesseging> CustomerContactMesseging { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobFile> JobFile { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobSalesInvoiceEstimateStatus> JobSalesInvoiceEstimateStatus { get; set; }
        public virtual CustomerJobStatus CustomerJobStatus { get; set; }
    }
}
