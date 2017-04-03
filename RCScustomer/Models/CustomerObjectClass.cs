using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RCScustomer.Models
{
    public class TradeChargeClass
    {
        public Nullable<System.Guid> Pkey { get; set; }
        public System.Guid CustomerKey { get; set; }
        [Display(Name = "Trade Name")]
        [Required(ErrorMessage = "Trade is required")]
        public Nullable<System.Guid> TradeKey { get; set; }
        [Display(Name = "Sales Charge Type")]
        [Required(ErrorMessage = "Charge Type is required")]
        public Nullable<System.Guid> SalesChargeTypeKey { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> Don { get; set; }
        public Nullable<System.Guid> Dby { get; set; }
        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required")]
        public Nullable<decimal> Amt { get; set; }


        public string ChargeName { get; set; }
        public string ActiveType { get; set; }
        public string TradeName { get; set; }
        public List<TradeChargeClass> TradeList { get; set; }
    }
    public class CustomerObjectClass
    {
        public CustomerClass CustomerObj { get; set; }
        public ContactClass ContactObj { get; set; }
        public List<ContactClass> ContactList { get; set; }
        public List<TradeChargeClass> TradeList { get; set; }
        public TripChargeClass TripObject { get; set; }
        public List<LaborChargeClass> LaborChargeList { get; set; }
        public List<CustomerJobClass> JobList { get; set; }
        public CustomerAttachClass AttachmentObj { get; set; }
        public List<CustomerAttachClass> AttachmentList { get; set; }
        public List<CustomerLocationClass> ServiLocationList { get; set; }
        public CustomerNoteClass NoteObj { get; set; }
        public List<CustomerNoteClass> NoteList { get; set; }
        public DataReturn Messege { get; set; }
        [Display(Name = "Select Attachment Type")]
        public Nullable<System.Guid> AttachementType { get; set; }
    }
    public class CustomerNoteClass
    {
        public Nullable<System.Guid> NoteKey { get; set; }
        public Nullable<System.Guid> VendorKey { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        public Nullable<System.Guid> LocationKey { get; set; }
        public Nullable<System.Guid> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedOn { get; set; }
        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "title is required")]
        public string Title { get; set; }
        public string StaffName { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string Remarks { get; set; }
        public string status { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual StaffList StaffList { get; set; }
    }

    public class CustomerAttachClass
    {
        public Nullable<System.Guid> AttachementKey { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        public Nullable<System.Guid> LocationKey { get; set; }
        public Nullable<System.Guid> VendorKey { get; set; }
        public Nullable<System.Guid> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedOn { get; set; }
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public string Staffname { get; set; }
        public string DocTypeName { get; set; }
        public byte[] AttFile { get; set; }
        public string FileType { get; set; }
        public Nullable<System.Guid> AttachementType { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string Remarks { get; set; }
        public string status { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual StaffList StaffList { get; set; }
    }
    public class CustomerLocationClass
    {
        public Guid? LocationKey { get; set; }
        public Guid? CustomerKey { get; set; }
        public string Businessname { get; set; }
        public string ContactPerson { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }
    public class CustomerJobClass
    {
        public Guid? JobKey { get; set; }
        public Guid? LocationKey { get; set; }
        public Guid? VendorKey { get; set; }
        public DateTime? JobDate { get; set; }
        public string JobName { get; set; }
        public string PO { get; set; }
        public string ServiceLocation { get; set; }
        public string VendorName { get; set; }
        public string CustomerName { get; set; }
        public string TradeName { get; set; }
        public string Status { get; set; }
    }
    public class LaborChargeClass
    {
        public System.Guid Labor { get; set; }
        public System.Guid CustomerKey { get; set; }
        public Nullable<System.Guid> TradeKey { get; set; }
        [Display(Name = "Standard")]
        [Required(ErrorMessage = "setting Standard labor charge is required")]
        public Nullable<decimal> Standard { get; set; }
        [Display(Name = "emergency")]
        [Required(ErrorMessage = "setting emergency labor charge is required")]
        public Nullable<decimal> Emergency { get; set; }
        [Display(Name = "holiday")]
        [Required(ErrorMessage = "setting holiday labor charge is required")]
        public Nullable<decimal> Holiday { get; set; }

        [Display(Name = "Trade")]
        [Required(ErrorMessage = "setting holiday labor charge is required")]
        public string TradeName { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Trade Trade { get; set; }
    }
    public class TripChargeClass
    {
        public Nullable<System.Guid> TripKey { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        [Display(Name = "Standard*")]
        [Required(ErrorMessage = "setting Standard trip charge is required")]
        public Nullable<decimal> Standard { get; set; }
        [Display(Name = "emergency*")]
        [Required(ErrorMessage = "setting emergency trip charge is required")]
        public Nullable<decimal> Emergency { get; set; }
        [Display(Name = "holiday*")]
        [Required(ErrorMessage = "setting holiday trip charge is required")]
        public Nullable<decimal> Holiday { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string mess { get; set; }

    }
    public class ContactClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContactClass()
        {
            this.Job = new HashSet<Job>();
        }

        public Nullable<System.Guid> ContactKey { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        public Nullable<System.Guid> LocationKey { get; set; }
        public Nullable<System.Guid> VendorKey { get; set; }
        [Display(Name = "Name*")]
        [Required(ErrorMessage = "Name is required")]
        public string Cname { get; set; }
        [Display(Name = "Title*")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Display(Name = "Phone No*")]
        [Required(ErrorMessage = "Phone Number is required")]
        public string Phone { get; set; }
        [Display(Name = "EXT")]
        public string PhoneEXT { get; set; }
        [Display(Name = "Fax")]
        public string FAX { get; set; }
        [Display(Name = "ALT mPhone")]
        public string ALTPhone { get; set; }
        [Display(Name = "EXT")]
        public string ALTPhoneEXT { get; set; }
        [Display(Name = "email")]
        [Required(ErrorMessage = "email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Display(Name = "Default Contact?")]
        [Required(ErrorMessage = "setting default is required")]
        public bool IsDefault { get; set; }
        public string status { get; set; }
        public string defaultstatus { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> CompanyKey { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Job> Job { get; set; }
    }
    public class CustomerClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerClass()
        {
            this.CustomerAttachments = new HashSet<CustomerAttachments>();
            this.CustomerContact = new HashSet<CustomerContact>();
            this.CustomerLabor = new HashSet<CustomerLabor>();
            this.CustomerLocation = new HashSet<CustomerLocation>();
            this.CustomerNote = new HashSet<CustomerNote>();
            this.CustomerTripCharge = new HashSet<CustomerTripCharge>();
            this.Job = new HashSet<Job>();
        }
        public System.Guid CustomerKey { get; set; }
        [Display(Name = "Name*")]
        [Required(ErrorMessage = "Name is required")]
        public string Cname { get; set; }
        [Display(Name = "Address*")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Display(Name = "IVR Phone*")]
        [Required(ErrorMessage = "IVR Phone is required")]
        public string IVRPhone { get; set; }
        [Display(Name = "IVR PIN*")]
        [Required(ErrorMessage = "IVR PIN is required")]
        public string IVRPin { get; set; }
        [Display(Name = "IVR Instruction")]
        public string IVRinstruction { get; set; }
        [Required(ErrorMessage = "City is required")]
        public Nullable<int> CityKey { get; set; }
        [Required(ErrorMessage = "State is required")]
        public Nullable<int> StateCode { get; set; }
        [Required(ErrorMessage = "ZIP code is required")]
        [Display(Name = "ZIP code*")]
        public string ZIPcode { get; set; }
        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State*")]
        public string StateName { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.Guid> CompanyKey { get; set; }

        public virtual CityList CityList { get; set; }
        public virtual Customer Customer1 { get; set; }
        public virtual Customer Customer2 { get; set; }
        public virtual StateList StateList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerAttachments> CustomerAttachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerContact> CustomerContact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerLabor> CustomerLabor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerLocation> CustomerLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerNote> CustomerNote { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerTripCharge> CustomerTripCharge { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Job> Job { get; set; }
    }

    public class CustomerListClass
    {
        public Guid CustomerKey { get; set; }
        public string CustomerName { get; set; }
        public string PrimaryContact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? isdelete { get; set; }

    }
    public class DataReturn
    {
        public int flag { get; set; }
        public Guid? key { get; set; }
        public string mess { get; set; }
    }
}