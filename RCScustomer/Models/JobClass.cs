using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RCScustomer.Models
{
    public class JobClass
    {
        [Required(ErrorMessage = "Customer is required")]
        public Nullable<System.Guid> CustomerKey { get; set; }

        [Display(Name = "Customer Name*")]
        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }
        [Display(Name = "Customer Job Status")]
        [Required(ErrorMessage = "Customer Job Status is required")]
        public string CustomerJobStatus { get; set; }

        [Display(Name = "Service Location*")]
        [Required(ErrorMessage = "Service Location is required")]
        public string LocationName { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public Nullable<System.Guid> LocationKey { get; set; }

        [Display(Name = "Job Name*")]
        [Required(ErrorMessage = "Job Name is required")]
        public string JobName { get; set; }

        [Required(ErrorMessage = "Job Type is required")]
        public Nullable<System.Guid> JobTypeKey { get; set; }

        [Display(Name = "PO*")]
        [Required(ErrorMessage = "PO is required")]
        public string PO { get; set; }

       

        [Display(Name = "IVR Tracking No*")]
        [Required(ErrorMessage = "IVR Tracking No is required")]
        public string IVRTrackingNo { get; set; }

        [Required(ErrorMessage = "Customer Contact is required")]
        public Nullable<System.Guid> CContactKey { get; set; }

        [Display(Name = "Contact*")]
        [Required(ErrorMessage = "Customer Contact is required")]
        public string CustomerContactName { get; set; }

        [Display(Name = "DNE*")]
        [Required(ErrorMessage = "CustomerDNE is required")]
        public string CustomerDNE { get; set; }

        [Required(ErrorMessage = "Trade is required")]
        public Nullable<System.Guid> TradeKey { get; set; }

        [Display(Name = "Trade*")]
        [Required(ErrorMessage = "Trade Name is required")]
        public string TradeName { get; set; }

        [Required(ErrorMessage = "Job Status is required")]
        public Nullable<System.Guid> JobStatusKey { get; set; }

        [Display(Name = "Job Status*")]
        public string JobStatusName { get; set; }
        [Display(Name = "Job Priority*")]
        public string Priority { get; set; }


      
        [Display(Name = "Entry Date*")]
        public string EntryDate { get; set; }

        [Display(Name = "IVR Pin*")]
        [Required(ErrorMessage = "IVRPin is required")]
        public string IVRPin { get; set; }

       
        [Display(Name = "Initial Site Visit Schedule Date*")]       
        public string ScheduleDate { get; set; }

      
        [Display(Name = "Return Site Visit Schedule Date*")]      
        public string ReturnScheduleDate { get; set; }

        [Display(Name = "Contact*")]
        public string LocationContactName { get; set; }

        [Required(ErrorMessage = "Location Contact is required")]
        public Nullable<System.Guid> LocationContactKey { get; set; }

        [Display(Name = "Address*")]
        public string LocationContactAddress { get; set; }

        [Display(Name = "City*")]
        public string LocationContactCityName { get; set; }

        [Display(Name = "State*")]
        public string LocationContactStateName { get; set; }

        [Display(Name = "Zip*")]
        public string LocationContactZipCode { get; set; }
        [Display(Name = "Name")]
        public string RCSManager { get; set; }
        [Display(Name = "Email")]
        public string RCSEmail { get; set; }
        [Display(Name = "PHONE")]
        public string RCSPhone { get; set; }
        [Display(Name = "EXT")]
        public string RCSEXT { get; set; }
        [Display(Name = "Service Needed / Job Description")]
        public string Description { get; set; }
        public string mess { get; set; }
        public System.Guid JobKey { get; set; }
        
        public IEnumerable<System.Guid> FromTeamKey { get; set; }
        public IEnumerable<SelectListItem> FromTeamKeyList { get; set; }

        [Required(ErrorMessage = "Assign Team is required")]
        public IEnumerable<System.Guid> ToTeamKey { get; set; }
        public IEnumerable<SelectListItem> ToTeamKeyList { get; set; }

        public string CheckIn { get; set; }

        public string CheckOut { get; set; }

        [Display(Name = "Name")]
        public string RCSAccountManagerName { get; set; }

        [Display(Name = "Email")]
        public string RCSAccountManagerEmail { get; set; }

        [Display(Name = "Phone")]
        public string RCSAccountManagerPhone { get; set; }

        [Display(Name = "Ext")]
        public string RCSAccountManagerExt { get; set; }

    }

    public class JobFileClass
    {

        public Nullable<System.Guid> FileKey { get; set; }
        public Nullable<System.Guid> JobKey { get; set; }
        [Display(Name = "Document Type :")]
        public Nullable<System.Guid> DocumentTypeKey { get; set; }
        public Nullable<System.Guid> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedOn { get; set; }
        [Display(Name = "Comments : ")]
        public string Comment { get; set; }
        [Display(Name = "Attachment(s):")]
        public string Title { get; set; }
        public string Remarks { get; set; }
        public byte[] FileContent { get; set; }
        public string FileType { get; set; }
        public Nullable<bool> IsDelete { get; set; }

        public string DocumentTypeName { get; set; }
        public string JobName { get; set; }
        public string Staffname { get; set; }

        public List<JobFileClass> Joblist { get; set; }
    }
}