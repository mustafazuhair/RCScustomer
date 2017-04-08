using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCScustomer.Models
{
    public class JobRequestAttachmentMain
    {
        public List<JobRequestAttachmentsObject> JobRequestAttachmentsList { get; set; }
        public List<DocumentTypeObject> DocumentTypeObjectList { get; set; }
    }
}