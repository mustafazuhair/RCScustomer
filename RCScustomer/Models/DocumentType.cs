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
    
    public partial class DocumentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentType()
        {
            this.CustomerAttachments = new HashSet<CustomerAttachments>();
            this.LocationAttachement = new HashSet<LocationAttachement>();
            this.VendorAttachement = new HashSet<VendorAttachement>();
            this.JobRequestAttachments = new HashSet<JobRequestAttachments>();
            this.JobFile = new HashSet<JobFile>();
        }
    
        public System.Guid ID { get; set; }
        public string TName { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> CompanyKey { get; set; }
        public Nullable<int> DocumentForID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerAttachments> CustomerAttachments { get; set; }
        public virtual DocumentFor DocumentFor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LocationAttachement> LocationAttachement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorAttachement> VendorAttachement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobRequestAttachments> JobRequestAttachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobFile> JobFile { get; set; }
    }
}
