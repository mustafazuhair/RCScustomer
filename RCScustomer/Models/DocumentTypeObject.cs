using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCScustomer.Models
{
    public class DocumentTypeObject
    {
        public System.Guid ID { get; set; }
        public string TName { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> CompanyKey { get; set; }
        public Nullable<int> DocumentForID { get; set; }
    }
}