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
    
    public partial class JobRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobRequest()
        {
            this.JobRequestAttachments = new HashSet<JobRequestAttachments>();
        }
    
        public System.Guid RequestKey { get; set; }
        public Nullable<System.Guid> LocationKey { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        public Nullable<System.Guid> LocationContactKey { get; set; }
        public Nullable<System.Guid> TradeKey { get; set; }
        public Nullable<System.Guid> JobPriorityKey { get; set; }
        public string ServiceNeeded { get; set; }
        public Nullable<decimal> DNEamount { get; set; }
        public string SpecialNote { get; set; }
        public Nullable<System.DateTime> ServiceDate { get; set; }
        public string ServiceByTime { get; set; }
        public string SVCLocationContact { get; set; }
        public string SvcLocationContactPhone { get; set; }
        public Nullable<System.DateTime> EntryDatetime { get; set; }
        public Nullable<bool> IsRequest { get; set; }
        public Nullable<System.Guid> CContactKey { get; set; }
        public Nullable<bool> Isviewed { get; set; }
        public string ServiceNeededByOrOn { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual Location Location { get; set; }
        public virtual LocationContact LocationContact { get; set; }
        public virtual Trade Trade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobRequestAttachments> JobRequestAttachments { get; set; }
        public virtual CustomerContact CustomerContact { get; set; }
    }
}
