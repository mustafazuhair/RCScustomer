using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RCScustomer.Models
{
    public class JobSalesInvoiceClass
    {

        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public string Remark { get; set; }
        public Nullable<System.Guid> JobKey { get; set; }
        public Nullable<bool> IsEstimate { get; set; }
        public string Estimatestatus { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Guid? TradeKey { get; set; }
        public int? InvoiceType { get; set; }

        public Guid? DetailKey { get; set; }
        public Guid? InvoiceKey { get; set; }
        [Required(ErrorMessage = "Sales Status is required")]
        [Display(Name = "Sales status")]
        public Nullable<System.Guid> SalesStatusKey { get; set; }
        [Display(Name = "Charge Type")]
        public Nullable<System.Guid> ChargeTypeKey { get; set; }
        [Display(Name = "Rate")]
        public Nullable<decimal> Rate { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string JobName { get; set; }
        public string ChargeTypeName { get; set; }
        public string StatusName { get; set; }
        public string StaffName { get; set; }
        [Display(Name = "Quantity")]
        public Nullable<decimal> Qty { get; set; }
        [Display(Name = "Amount")]
        public Nullable<decimal> Amt { get; set; }

        public bool? IsNew { get; set; }

        public List<JobSalesInvoiceClass> InvoiceDetailList { get; set; }
    }


    public class PreviewSalesInvoiceClass
    {
        public CustomerInvoiceConfigurationClass config = new CustomerInvoiceConfigurationClass();

        public DataReturn datareturn { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
       
        public string Remark { get; set; }
        [Required(ErrorMessage = "Please Select one.")]
        public int EstimateStatus { get; set; }
        public decimal? Total { get; set; }
        public Nullable<System.Guid> JobKey { get; set; }
        public Nullable<System.Guid> JobStatusKey { get; set; }
        public Nullable<bool> IsEstimate { get; set; }
        public string Estimate_status { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Guid? TradeKey { get; set; }
        public int? InvoiceType { get; set; }


        public Guid? InvoiceKey { get; set; }

        public string SalesStatusName { get; set; }
        public string LocationCity { get; set; }
        public string locationState { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string EmailStatus { get; set; }
        public Nullable<bool> EstimatesSent { get; set; }
        public Nullable<bool> InvoiceSent { get; set; }

        public string JobName { get; set; }
        public Customer Customer { get; set; }
        public CustomerContact CContact { get; set; }
        public string StatusName { get; set; }
        public Location ServiceLocation { get; set; }
        public EstimateClass EstimateObj { get; set; }

        public List<JobSalesInvoiceClass> InvoiceDetailList { get; set; }
    }
    public class EstimateClass
    {
        public bool? IsNew { get; set; }
        public System.Guid Pkey { get; set; }
        public System.Guid InvoiceKey { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        public Nullable<System.Guid> SalesStatusKey { get; set; }
        public Nullable<System.Guid> JobKey { get; set; }
        [Required(ErrorMessage = "Note is Compulsory.")]
        public string Remark { get; set; }
        public string InvoiceNo { get; set; }
        public string ViewRemark { get; set; }
        public Nullable<bool> Accept { get; set; }
        public Nullable<bool> Decline { get; set; }
        public Nullable<bool> Resubmit { get; set; }

        public string LocationName { get; set; }
        public string TradeName { get; set; }
        public string Jobname { get; set; }
        public DateTime? EntryDate { get; set; }
        public string SalesStatusName { get; set; }
    }

    public class CustomerInvoiceConfigurationClass
    {
        public System.Guid ConfigKey { get; set; }
        public Nullable<System.Guid> JobKey { get; set; }
        public Nullable<System.Guid> CustomerKey { get; set; }
        public Nullable<System.Guid> CContactKey { get; set; }
        [Display(Name = "Job Name")]
        public string JobName { get; set; }
        [Display(Name = "Service Location")]
        public string ServiceLocationDetail { get; set; }
        [Display(Name = "Customer PO")]
        public string CustomerPO { get; set; }
        [Display(Name = "Customer")]
        public string CustomerDetail { get; set; }
        [Display(Name = "Client Contact")]
        public string ContactDetail { get; set; }
        [Display(Name = "Hidden")]
        [Required(ErrorMessage = "Please select an option")]
        public Nullable<bool> IsCustomerPOVisible { get; set; }
        [Display(Name = "Hidden")]
        [Required(ErrorMessage = "Please select an option")]
        public Nullable<bool> IsClientPOVisible { get; set; }
        [Display(Name = "Hidden")]
        [Required(ErrorMessage = "Please select an option")]
        public Nullable<bool> IsCustomerDetailVisible { get; set; }
        [Display(Name = "Invoice Detail Hidden?")]
        [Required(ErrorMessage = "Please select an option")]
        public Nullable<bool> IsInvoiceDetailVisible { get; set; }
        [Display(Name = "Work Proposed Title")]
        public string WorkProposedTitle { get; set; }
        [Display(Name = "Hidden")]
        [Required(ErrorMessage = "Please select an option")]
        public Nullable<bool> IsWorkProposedTitleVisible { get; set; }
        [Display(Name = "Hidden")]
        [Required(ErrorMessage = "Please select an option")]
        public Nullable<bool> IsCustomerNameVisible { get; set; }
        [Display(Name = "Customer Sign")]
        public string CustomerSign { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Date")]
        public string JobDate { get; set; }
        [Display(Name = "Hidden")]
        [Required(ErrorMessage = "Please select an option")]
        public Nullable<bool> IsCustomerSignVisible { get; set; }
        [Display(Name = "Hidden")]
        [Required(ErrorMessage = "Please select an option")]
        public Nullable<bool> IsDateVisible { get; set; }
        [Display(Name = "Hidden")]
        [Required(ErrorMessage = "Please select an option")]
        public Nullable<bool> IsServiceLicationVisible { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerContact CustomerContact { get; set; }
        public virtual Job Job { get; set; }
    }
}