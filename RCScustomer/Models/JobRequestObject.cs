using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RCScustomer.Models
{
    public class JobRequestObject
    {
        public System.Guid RequestKey { get; set; }
        public Nullable<System.Guid> LocationKey { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        public Nullable<System.Guid> LocationContactKey { get; set; }
        public Nullable<System.Guid> TradeKey { get; set; }

        public Nullable<System.Guid> JobPriorityKey { get; set; }


        [Display(Name = "Job Priority*")]
        [Required(ErrorMessage = "Job Priority is required")]
        public string JobPriority { get; set; }


        [Display(Name = "Service Needed*")]
        [Required(ErrorMessage = "Service Needed is required")]
        public string ServiceNeeded { get; set; }
        public Nullable<decimal> DNEamount { get; set; }
        public string SpecialNote { get; set; }
        public Nullable<System.DateTime> ServiceDate { get; set; }
        public string ServiceByTime { get; set; }
        public string SVCLocationContact { get; set; }
        public string SvcLocationContactPhone { get; set; }
        public Nullable<System.DateTime> EntryDatetime { get; set; }
        public Nullable<bool> IsRequest { get; set; }

        [Display(Name = "Service Location*")]
        [Required(ErrorMessage = "Service Location is required")]
        public string LocationName { get; set; }


        [Display(Name = "Contact*")]
        [Required(ErrorMessage = "Job request Contact is required")]
        public string LocationContactName { get; set; }

        [Display(Name = "Address*")]
        public string LocationContactAddress { get; set; }

        [Display(Name = "City*")]
        public string LocationContactCityName { get; set; }

        [Display(Name = "State*")]
        public string LocationContactStateName { get; set; }

        [Display(Name = "Zip*")]
        public string LocationContactZipCode { get; set; }


        [Display(Name = "Trade*")]
        [Required(ErrorMessage = "Trade Name is required")]
        public string TradeName { get; set; }

        public string mess { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual Location Location { get; set; }
        public virtual LocationContact LocationContact { get; set; }
        public virtual Trade Trade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobRequestAttachments> JobRequestAttachments { get; set; }
    }
}