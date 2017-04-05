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
    
    public partial class VendorContact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VendorContact()
        {
            this.JobVendor = new HashSet<JobVendor>();
        }
    
        public System.Guid ContactKey { get; set; }
        public System.Guid VendorKey { get; set; }
        public string Cname { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string PhoneEXT { get; set; }
        public string FAX { get; set; }
        public string ALTPhone { get; set; }
        public string ALTPhoneEXT { get; set; }
        public string Email { get; set; }
        public bool IsDefault { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> CompanyKey { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobVendor> JobVendor { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}