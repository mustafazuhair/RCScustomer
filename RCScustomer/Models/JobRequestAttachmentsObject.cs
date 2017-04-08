using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCScustomer.Models
{
    public class JobRequestAttachmentsObject
    {
        public System.Guid PKey { get; set; }
        public System.Guid RequestKey { get; set; }
        public Nullable<System.Guid> DocumentTypeKey { get; set; }
        public byte[] DocFile { get; set; }
        public string FileType { get; set; }
        public string Filename { get; set; }
        public string DocumentName { get; set; }
    }
}