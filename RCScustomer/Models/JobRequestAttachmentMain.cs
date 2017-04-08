using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCScustomer.Models
{
    public class JobRequestAttachmentMain
    {
        public List<JobRequestAttachmentsObject> JobRequestAttachmentsList { get; set; }
        public JobRequestAttachmentsObject fileObj { get; set; }
        public JobRequest RequestObj { get; set; }
        public Guid? DocumentTypeKey { get; set; }
    }
}