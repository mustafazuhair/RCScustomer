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
    
    public partial class Supplier
    {
        public System.Guid SupplierKey { get; set; }
        public string SupplierID { get; set; }
        public string SName { get; set; }
        public string SAddress { get; set; }
        public string SPhone { get; set; }
        public string SMobile { get; set; }
        public string SEmail { get; set; }
        public string RepresentedBy { get; set; }
        public string Title { get; set; }
        public string ContactCell { get; set; }
        public string ContactEmail { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<int> StateCode { get; set; }
        public Nullable<int> CityKey { get; set; }
        public Nullable<long> ZIPKey { get; set; }
        public string Remarks { get; set; }
    
        public virtual CityList CityList { get; set; }
        public virtual StateList StateList { get; set; }
        public virtual ZIPList ZIPList { get; set; }
    }
}