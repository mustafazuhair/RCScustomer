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
    
    public partial class JobTeam
    {
        public System.Guid PKey { get; set; }
        public System.Guid JobKey { get; set; }
        public Nullable<System.DateTime> Addedon { get; set; }
        public System.Guid TeamKey { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> RemovedOn { get; set; }
        public string Remarks { get; set; }
    
        public virtual Job Job { get; set; }
        public virtual Team Team { get; set; }
    }
}