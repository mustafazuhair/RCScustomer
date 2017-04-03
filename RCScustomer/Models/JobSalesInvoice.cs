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
    
    public partial class JobSalesInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobSalesInvoice()
        {
            this.JobSalesInvoiceDetail = new HashSet<JobSalesInvoiceDetail>();
        }
    
        public System.Guid InvoiceKey { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public string Remark { get; set; }
        public Nullable<System.Guid> JobKey { get; set; }
        public Nullable<bool> IsEstimate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.Guid> SalesStatusKey { get; set; }
        public Nullable<bool> EstimatesSent { get; set; }
        public Nullable<bool> InvoiceSent { get; set; }
    
        public virtual Job Job { get; set; }
        public virtual SalesStatus SalesStatus { get; set; }
        public virtual StaffList StaffList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobSalesInvoiceDetail> JobSalesInvoiceDetail { get; set; }
    }
}
