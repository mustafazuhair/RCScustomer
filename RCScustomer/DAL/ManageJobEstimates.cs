﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RCScustomer.Models;

namespace RCScustomer.DAL
{
    public class ManageJobEstimates
    {
        private RCSdbEntities db = new RCSdbEntities();
        public List<EstimateClass> GetAllJobEstimatesForThisCustomer()
        {
            List<EstimateClass> model = new List<EstimateClass>();
            var temp = (from m in db.JobSalesInvoice
                        where m.IsEstimate == true && m.IsActive == true && m.Job.CustomerKey==GlobalClass.LoginUser.CustomerKey
                        select new EstimateClass
                        {
                            LocationName = m.Job.Location.Lname,
                            TradeName = m.Job.Trade.TName,
                            Jobname = m.Job.JobName,
                            SalesStatusName = m.SalesStatus.TName,
                            EntryDate = m.CreatedDate,
                            InvoiceKey = m.InvoiceKey
                        });
            temp = temp.OrderByDescending(m=>m.EntryDate);
            model = temp.ToList();
            return model;
        }
        public PreviewSalesInvoiceClass FillSalesInvoiceOrEstimateDataForPreview(Guid id)
        {
            PreviewSalesInvoiceClass obj = new PreviewSalesInvoiceClass();
            obj.InvoiceDetailList = new List<JobSalesInvoiceClass>();
            obj.config = new CustomerInvoiceConfigurationClass();
            try
            {

                JobSalesInvoice invoice = db.JobSalesInvoice.Find(id);
                Job job = db.Job.Find(invoice.JobKey);
                DocumentationSetup doc = db.DocumentationSetup.FirstOrDefault(m => m.CompanyKey == GlobalClass.Company.CompanyKey && m.IsDelete == false);
                Location loca = db.Location.Find(job.LocationKey);
                Customer custom = db.Customer.Find(job.CustomerKey);
                CustomerContact contact = db.CustomerContact.SingleOrDefault(m => m.CustomerKey == job.CustomerKey && m.IsDefault == true && m.IsDelete == false);
                obj.CContact = contact;
                obj.EstimateObj = new EstimateClass();
                JobSalesInvoiceEstimateStatus est=db.JobSalesInvoiceEstimateStatus.FirstOrDefault(m=>m.InvoiceKey==id);
                #region Sales Estimate
                if (est == null)
                {
                    obj.EstimateObj.IsNew = true;
                    obj.EstimateObj.Remark = "";
                    obj.EstimateObj.Accept = false;
                    obj.EstimateObj.Decline = false;
                    obj.EstimateObj.Resubmit = false;
                    obj.EstimateObj.InvoiceKey = id;
                }
                else
                {
                    obj.EstimateObj.IsNew = false;
                    obj.EstimateObj.Remark = est.Remark;
                    obj.EstimateObj.Accept = est.Accept;
                    obj.EstimateObj.Decline = est.Decline;
                    obj.EstimateObj.Resubmit = est.Resubmit;
                    obj.EstimateObj.InvoiceKey = id;
                    obj.EstimateObj.Pkey = est.Pkey;
                }
                #endregion


                #region Invoice Config
                JobConfiguration jc = db.JobConfiguration.SingleOrDefault(m => m.JobKey == invoice.JobKey);
                obj.JobStatusKey = job.JobStatusKey;

                if (jc == null)
                {

                    obj.config.JobKey = job.JobKey;

                    obj.config.CustomerKey = job.CustomerKey;
                    obj.config.CContactKey = job.CContactKey;
                    obj.config.JobName = job.JobName;
                    obj.config.ServiceLocationDetail = loca.Lname + " , " + loca.Address + " , " + loca.ZIPcode + " , " + loca.CityList.CityName + " , " + loca.StateList.StateName;
                    obj.config.CustomerDetail = custom.Cname + " , " + custom.Address + " ,( " + custom.IVRPhone + ") , " + custom.ZIPcode + " , " + custom.CityList.CityName + " , " + custom.StateList.StateName;
                    obj.config.ContactDetail = contact.Cname;
                    obj.config.IsCustomerPOVisible = false;
                    obj.config.IsClientPOVisible = false;
                    obj.config.IsInvoiceDetailVisible = false;
                    obj.config.WorkProposedTitle = job.JobName;
                    obj.config.IsWorkProposedTitleVisible = false;
                    obj.config.IsCustomerNameVisible = false;
                    obj.config.CustomerSign = custom.Cname;
                    obj.config.CustomerPO = custom.ZIPcode;
                    obj.config.CustomerName = custom.Cname;
                    obj.config.IsCustomerDetailVisible = false;
                    obj.config.JobDate = job.ScheduleDate.Value.ToShortDateString();
                    obj.config.IsCustomerSignVisible = false;
                    obj.config.IsDateVisible = false;
                    obj.config.IsServiceLicationVisible = false;
                }
                else
                {
                    obj.config.ConfigKey = jc.ConfigKey;
                    obj.config.JobKey = jc.JobKey;
                    obj.config.CustomerKey = jc.CustomerKey;
                    obj.config.CContactKey = jc.CContactKey;
                    obj.config.JobName = job.JobName;
                    obj.config.ServiceLocationDetail = loca.Lname + " , " + loca.Address + " , " + loca.ZIPcode + " , " + loca.CityList.CityName + " , " + loca.StateList.StateName;
                    obj.config.CustomerDetail = custom.Cname + " , " + custom.Address + " ,( " + custom.IVRPhone + ") , " + loca.ZIPcode + " , " + custom.CityList.CityName + " , " + custom.StateList.StateName;
                    obj.config.ContactDetail = contact.Cname;
                    obj.config.IsCustomerPOVisible = jc.IsCustomerPOVisible;
                    obj.config.IsClientPOVisible = jc.IsClientPOVisible;
                    obj.config.IsInvoiceDetailVisible = jc.IsInvoiceDetailVisible;
                    obj.config.WorkProposedTitle = jc.WorkProposedTitle;
                    obj.config.IsWorkProposedTitleVisible = jc.IsWorkProposedTitleVisible;
                    obj.config.IsCustomerNameVisible = jc.IsCustomerNameVisible;
                    obj.config.CustomerSign = jc.CustomerSign;
                    obj.config.CustomerPO = custom.ZIPcode;
                    obj.config.CustomerName = custom.Cname;
                    obj.config.IsCustomerDetailVisible = jc.IsCustomerDetailVisible;
                    obj.config.JobDate = job.ScheduleDate.Value.ToShortDateString();
                    obj.config.IsCustomerSignVisible = jc.IsCustomerSignVisible;
                    obj.config.IsDateVisible = jc.IsDateVisible;
                    obj.config.IsServiceLicationVisible = jc.IsServiceLicationVisible;
                }
                #endregion

                obj.Estimatestatus = "ESTIMATE"; 
                obj.ServiceLocation = loca;
                obj.Customer = custom;
                obj.LocationCity = loca.CityList.CityName;
                obj.locationState = loca.StateList.StateName;
                obj.CustomerCity = custom.CityList.CityName;
                obj.CustomerState = custom.StateList.StateName;
                obj.InvoiceKey = id;
                obj.Total = 0;

                obj.CreatedDate = invoice.CreatedDate;
                obj.CreatedBy = invoice.CreatedBy;
                obj.Remark = doc.QuoteConfiguration;
                obj.JobKey = invoice.JobKey;
                obj.IsEstimate = invoice.IsEstimate;
                obj.InvoiceKey = id;
                obj.JobName = job.JobName;
                var temp = from x in db.JobSalesInvoiceDetail where x.InvoiceKey == id select x;
                if (temp.Count() > 0)
                {
                    foreach (var item in temp)
                    {
                        JobSalesInvoiceClass t = new JobSalesInvoiceClass();
                        t.Description = item.Description;
                        t.DetailKey = item.DetailKey;
                        t.Rate = item.Rate;
                        t.Qty = item.Qty;
                        t.Amt = item.Amt;
                        t.IsNew = false;
                        t.ChargeTypeKey = item.ChargeTypeKey;
                        t.ChargeTypeName = item.SalesChargeType.TName;
                        t.InvoiceKey = item.InvoiceKey;
                        obj.InvoiceDetailList.Add(t);
                        obj.Total = obj.Total + t.Amt;
                    }
                }
            }
            catch (Exception ex)
            {
                string fall = ex.ToString();
            }
            return obj;
        }
    }
}