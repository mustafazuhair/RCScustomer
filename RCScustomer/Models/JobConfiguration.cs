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
    
    public partial class JobConfiguration
    {
        public System.Guid ConfigKey { get; set; }
        public Nullable<System.Guid> JobKey { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        public Nullable<System.Guid> CContactKey { get; set; }
        public Nullable<bool> IsCustomerPOVisible { get; set; }
        public Nullable<bool> IsClientPOVisible { get; set; }
        public Nullable<bool> IsInvoiceDetailVisible { get; set; }
        public string WorkProposedTitle { get; set; }
        public Nullable<bool> IsWorkProposedTitleVisible { get; set; }
        public Nullable<bool> IsCustomerNameVisible { get; set; }
        public string CustomerSign { get; set; }
        public Nullable<bool> IsCustomerSignVisible { get; set; }
        public Nullable<bool> IsDateVisible { get; set; }
        public Nullable<bool> IsServiceLicationVisible { get; set; }
        public Nullable<bool> IsCustomerDetailVisible { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual CustomerContact CustomerContact { get; set; }
        public virtual Job Job { get; set; }
    }
}
