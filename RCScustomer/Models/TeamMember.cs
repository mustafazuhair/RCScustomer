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
    
    public partial class TeamMember
    {
        public System.Guid DetaillKey { get; set; }
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> PersonnelKey { get; set; }
        public Nullable<bool> IsAccountManager { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual StaffList StaffList { get; set; }
        public virtual Team Team { get; set; }
    }
}
