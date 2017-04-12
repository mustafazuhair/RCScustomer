using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RCScustomer.Models
{
    public class FileClass
    {
        public string FileFormat { get; set; }
        public byte[] FileContent { get; set; }
    }
    public class RCSMessegeClass
    {
        public List<RCSMessegeMain> mailList { get; set; }
        public RCSMessegeMain mainObj { get; set; }
        public DataReturn Messege { get; set; }
        public Job Job { get; set; }
        [Required(ErrorMessage = "Selecting an option is compusory. ")]
        public Guid? VendorKey { get; set; }
        public string vendorName { get; set; }
    }
    public class RCSMessegeMain
    {
        public Nullable<System.Guid> PKey { get; set; }
        public Nullable<System.Guid> JobKey { get; set; }
        public Nullable<System.Guid> AddedBy { get; set; }
        [Display(Name = "Date and Time")]
        [Required(ErrorMessage = "Date and Time is required")]
        public Nullable<System.DateTime> AddedOn { get; set; }
        [Display(Name = "Activity Description")]
        [Required(ErrorMessage = "Activity Description is required")]
        public string Comment { get; set; }
        public string Staffname { get; set; }
        public string Designation { get; set; }
        public string Title { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string Remarks { get; set; }

        public Guid? VendorKey { get; set; }
        public string vendorName { get; set; }
        public string Jobname { get; set; }
        public bool IsAdmin { get; set; }
        public virtual Job Job { get; set; }
        public virtual StaffList StaffList { get; set; }
    }

    public class RCSExcel
    {
        public Nullable<System.DateTime> AddedOn { get; set; }
        public string Staffname { get; set; }
        public string Designation { get; set; }
        public string Title { get; set; }
        public string Jobname { get; set; }
        public string Comment { get; set; }
        public string Customer { get; set; }
        public string Vendor { get; set; }


    }
}