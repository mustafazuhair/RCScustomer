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

        [Required(ErrorMessage = "Job Priority is required")]
        public Nullable<System.Guid> JobPriorityKey { get; set; }
        public string RequestStatus { get; set; }

        [Display(Name = "Job Priority*")]
        
        public string JobPriority { get; set; }


        [Display(Name = "Service Needed*")]
        [Required(ErrorMessage = "Service Needed is required")]
        public string ServiceNeeded { get; set; }



        [Display(Name = "DNE Amount")]
        public Nullable<decimal> DNEamount { get; set; }

        [Display(Name = "Service Date")]
        public Nullable<System.DateTime> ServiceDate { get; set; }

        [Display(Name = "Service By Time")]
        public string ServiceByTime { get; set; }

        [Display(Name = "Special Note")]
        public string SpecialNote { get; set; }

        [Display(Name = "SVC Location Contact")]
        public string SVCLocationContact { get; set; }

        [Display(Name = "Svc Location Contact Phone")]
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

        public string CustomerName { get; set; }


        



        public virtual ICollection<JobRequestAttachments> JobRequestAttachments { get; set; }
        public List<JobRequestAttachmentsObject> JobRequestAttachmentsObjectList { get; internal set; }
    }
}