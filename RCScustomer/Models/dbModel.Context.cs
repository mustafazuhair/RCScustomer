﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RCScustomer.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RCSdbEntities : DbContext
    {
        public RCSdbEntities()
            : base("name=RCSdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CityList> CityList { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyForm> CompanyForm { get; set; }
        public virtual DbSet<CompanyModule> CompanyModule { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAttachments> CustomerAttachments { get; set; }
        public virtual DbSet<CustomerContact> CustomerContact { get; set; }
        public virtual DbSet<CustomerJob> CustomerJob { get; set; }
        public virtual DbSet<CustomerLabor> CustomerLabor { get; set; }
        public virtual DbSet<CustomerLocation> CustomerLocation { get; set; }
        public virtual DbSet<CustomerLogin> CustomerLogin { get; set; }
        public virtual DbSet<CustomerMesseging> CustomerMesseging { get; set; }
        public virtual DbSet<CustomerNote> CustomerNote { get; set; }
        public virtual DbSet<CustomerTradeCharge> CustomerTradeCharge { get; set; }
        public virtual DbSet<CustomerTripCharge> CustomerTripCharge { get; set; }
        public virtual DbSet<DocumentationSetup> DocumentationSetup { get; set; }
        public virtual DbSet<DocumentFor> DocumentFor { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<EmailConfiguration> EmailConfiguration { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<ImageFile> ImageFile { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobAccountManager> JobAccountManager { get; set; }
        public virtual DbSet<JobConfiguration> JobConfiguration { get; set; }
        public virtual DbSet<JobLocation> JobLocation { get; set; }
        public virtual DbSet<JobSalesInvoice> JobSalesInvoice { get; set; }
        public virtual DbSet<JobSalesInvoiceDetail> JobSalesInvoiceDetail { get; set; }
        public virtual DbSet<JobSignOff> JobSignOff { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<JobStatusUsergroup> JobStatusUsergroup { get; set; }
        public virtual DbSet<JobTeam> JobTeam { get; set; }
        public virtual DbSet<JobTechnician> JobTechnician { get; set; }
        public virtual DbSet<JobType> JobType { get; set; }
        public virtual DbSet<JobVendor> JobVendor { get; set; }
        public virtual DbSet<JobWorkOrder> JobWorkOrder { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationAttachement> LocationAttachement { get; set; }
        public virtual DbSet<LocationContact> LocationContact { get; set; }
        public virtual DbSet<LocationNotes> LocationNotes { get; set; }
        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<RCSmesseging> RCSmesseging { get; set; }
        public virtual DbSet<SalesChargeType> SalesChargeType { get; set; }
        public virtual DbSet<SalesStatus> SalesStatus { get; set; }
        public virtual DbSet<StaffList> StaffList { get; set; }
        public virtual DbSet<StateList> StateList { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamMember> TeamMember { get; set; }
        public virtual DbSet<Trade> Trade { get; set; }
        public virtual DbSet<Usergroup> Usergroup { get; set; }
        public virtual DbSet<UserGroupForm> UserGroupForm { get; set; }
        public virtual DbSet<UserGroupModule> UserGroupModule { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<VendorAttachement> VendorAttachement { get; set; }
        public virtual DbSet<VendorContact> VendorContact { get; set; }
        public virtual DbSet<VendorMesseging> VendorMesseging { get; set; }
        public virtual DbSet<VendorNotes> VendorNotes { get; set; }
        public virtual DbSet<VendorTrade> VendorTrade { get; set; }
        public virtual DbSet<VendorTradeCharge> VendorTradeCharge { get; set; }
        public virtual DbSet<ZIPList> ZIPList { get; set; }
        public virtual DbSet<CustomerContactMesseging> CustomerContactMesseging { get; set; }
        public virtual DbSet<JobRequest> JobRequest { get; set; }
        public virtual DbSet<JobRequestAttachments> JobRequestAttachments { get; set; }
        public virtual DbSet<GridTitle> GridTitle { get; set; }
        public virtual DbSet<GridTitleDetail> GridTitleDetail { get; set; }
        public virtual DbSet<JobEmail> JobEmail { get; set; }
        public virtual DbSet<JobFile> JobFile { get; set; }
        public virtual DbSet<JobSalesInvoiceEstimateStatus> JobSalesInvoiceEstimateStatus { get; set; }
    }
}
