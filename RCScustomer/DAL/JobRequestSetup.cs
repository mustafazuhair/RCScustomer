using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RCScustomer.Models;

namespace RCScustomer.DAL
{
    public class JobRequestSetup
    {
        private RCSdbEntities db = new RCSdbEntities();
        internal DataReturn SaveMainData(JobRequestObject obj)
        {
            DataReturn model = new DataReturn();
            try
            {
                JobRequest _job = new JobRequest();
                _job.RequestKey = Guid.NewGuid();
                _job.LocationKey = obj.LocationKey;
                _job.CustomerKey = GlobalClass.LoginUser.CustomerKey;
                _job.LocationContactKey = obj.LocationContactKey;
                _job.TradeKey = obj.TradeKey;
                _job.JobPriorityKey = obj.JobPriorityKey;
                _job.ServiceNeeded = obj.ServiceNeeded;
                _job.DNEamount = obj.DNEamount;
                _job.SpecialNote = obj.SpecialNote;
                _job.ServiceDate = obj.ServiceDate;
                _job.ServiceByTime = obj.ServiceByTime;
                _job.SVCLocationContact = obj.SVCLocationContact;
                _job.SvcLocationContactPhone = obj.SvcLocationContactPhone;
                _job.EntryDatetime = DateTime.Now;
                _job.IsRequest =true;
                db.JobRequest.Add(_job);
                db.SaveChanges();
                model.flag = 1;
                model.key = _job.RequestKey;
                model.mess = "Data has been saved successfully.";

            }
            catch (Exception ex)
            {
                model.flag = 0;
                model.mess = ex.Message.ToString();
            }
            return model;
        }

        internal List<JobRequestObject> GetAllJobRequestForThisCustomer()
        {
            List<JobRequestObject> docTypeList = new List<JobRequestObject>();
            var temp = from j in db.JobRequest
                       where j.CustomerKey == GlobalClass.CustomerDetail.CustomerKey
                       select new JobRequestObject
                       {
                           RequestKey = j.RequestKey,
                           LocationKey = j.LocationKey,
                           LocationName = j.Location.Lname,
                           CustomerKey = j.CustomerKey,
                           LocationContactKey = j.LocationContactKey,
                           LocationContactName = j.LocationContact.Cname,
                           LocationContactAddress = j.Location.Address,
                           LocationContactCityName = j.Location.CityList.CityName,
                           LocationContactStateName = j.Location.StateList.StateName,
                           LocationContactZipCode = j.Location.ZIPcode,
                           TradeKey = j.TradeKey,
                           TradeName = j.Trade.TName,
                           JobPriorityKey = j.JobPriorityKey,
                           JobPriority = j.JobType.TName,
                           ServiceNeeded = j.ServiceNeeded,
                           DNEamount = j.DNEamount,
                           SpecialNote = j.SpecialNote,
                           ServiceDate = j.ServiceDate,
                           ServiceByTime = j.ServiceByTime,
                           SVCLocationContact = j.SVCLocationContact,
                           SvcLocationContactPhone = j.SvcLocationContactPhone,
                           EntryDatetime = j.EntryDatetime,
                           RequestStatus = j.IsRequest == true ? "Request" : "Job Added",
                           IsRequest=j.IsRequest
                       };
            docTypeList = temp.OrderByDescending(m=>m.EntryDatetime).ToList();

            return docTypeList;
        }

        internal List<DocumentTypeObject> GetAllDocumntType()
        {
            List<DocumentTypeObject> docTypeList = new List<DocumentTypeObject>();
            var temp = from p in db.DocumentType
                       select new DocumentTypeObject
                       {

                           ID = p.ID,
                           TName = p.TName,
                           CompanyKey = p.CompanyKey,
                           DocumentForID = p.DocumentForID
                       };

                       docTypeList = temp.ToList();

            return docTypeList;
        }

        public JobRequestAttachmentMain GetJobFileAttachmentObjects(Guid id)
        {
            JobRequestAttachmentMain obj = new JobRequestAttachmentMain();
            try
            {
                obj.RequestObj = db.JobRequest.Find(id);
                var temp = from x in db.JobRequestAttachments
                           where x.RequestKey == id 

                           select new JobRequestAttachmentsObject
                           {
                               PKey = x.PKey,
                               RequestKey = x.RequestKey,
                               DocumentTypeKey = x.DocumentTypeKey,
                               DocFile = x.DocFile,
                               Filename = x.Filename,
                               FileType = x.FileType,
                               DocumentName = x.DocumentType.TName

                           };
                obj.JobRequestAttachmentsList = new List<JobRequestAttachmentsObject>();
                obj.JobRequestAttachmentsList = temp.ToList();

            }
            catch (Exception ex)
            {
                string fall = ex.ToString();
            }
            return obj;
        }
        public DataReturn SaveAttachmentInRequest(JobRequestAttachmentMain model)
        {
            DataReturn obj = new DataReturn();
            try
            {

                JobRequestAttachments fj = db.JobRequestAttachments.SingleOrDefault(m => m.RequestKey == model.RequestObj.RequestKey && m.DocumentTypeKey == model.DocumentTypeKey);
                if (fj == null)
                {
                }
                else
                {
                    db.JobRequestAttachments.Remove(fj);
                    db.SaveChanges();
                    db = new RCSdbEntities();
                }
                JobRequestAttachments invoice = new JobRequestAttachments();
                
                invoice.PKey = Guid.NewGuid();
                invoice.RequestKey = (Guid)model.RequestObj.RequestKey;
                invoice.DocumentTypeKey = model.DocumentTypeKey;
               
                invoice.DocFile = model.fileObj.DocFile;
                invoice.Filename = model.fileObj.Filename;
                invoice.FileType = model.fileObj.FileType;

              
                db.JobRequestAttachments.Add(invoice);
                db.SaveChanges();

                obj.flag = 1;
                obj.mess = "Data has been updated successfully.";
            }
            catch (Exception ex)
            {
                obj.mess = ex.ToString();
                obj.flag = 0;
            }
            obj.key = model.RequestObj.RequestKey;
            return obj;
        }
        internal JobRequestObject GetJobrequestDetails(Guid requestKey)
        {
            //JobRequest j = db.JobRequest.Find(requestKey);

            //JobRequestObject model = new JobRequestObject();

            //model.RequestKey = j.RequestKey;
            //model.LocationKey = j.LocationKey;
            //model.LocationName = j.Location.Lname;
            //model.CustomerKey = j.CustomerKey;
            //model.LocationContactKey = j.LocationContactKey;
            //model.LocationContactName = j.LocationContact.Cname;
            //model.LocationContactAddress = j.Location.Address;
            //model.LocationContactCityName = j.Location.CityList.CityName;
            //model.LocationContactStateName = j.Location.StateList.StateName;
            //model.LocationContactZipCode = j.Location.ZIPcode;
            //model.TradeKey = j.TradeKey;
            //model.TradeName = j.Trade.TName;
            //model.JobPriorityKey = j.JobPriorityKey;
            //model.JobPriority = j.JobType.TName;
            //model.ServiceNeeded = j.ServiceNeeded;
            //model.DNEamount = j.DNEamount;
            //model.SpecialNote = j.SpecialNote;
            //model.ServiceDate = j.ServiceDate;
            //model.ServiceByTime = j.ServiceByTime;
            //model.SVCLocationContact = j.SVCLocationContact;
            //model.SvcLocationContactPhone = j.SvcLocationContactPhone;
            //model.EntryDatetime = j.EntryDatetime;
            //return model;
            JobRequest j = db.JobRequest.Find(requestKey);

            JobRequestObject model = new JobRequestObject();

            model.RequestKey = j.RequestKey;
            model.LocationKey = j.LocationKey;
            model.LocationName = j.Location.Lname;
            model.CustomerKey = j.CustomerKey;
            model.CustomerName = j.Customer.Cname;
            model.LocationContactKey = j.LocationContactKey;
            model.LocationContactName = j.LocationContact.Cname;
            model.LocationContactAddress = j.LocationContact.Location.Address;
            model.LocationContactCityName = j.LocationContact.Location.CityList.CityName;
            model.LocationContactStateName = j.LocationContact.Location.StateList.StateName;
            model.LocationContactZipCode = j.LocationContact.Location.ZIPcode;

            model.TradeKey = j.TradeKey;
            model.TradeName = j.Trade.TName;
            model.JobPriorityKey = j.JobPriorityKey;
            model.JobPriority = j.JobType.TName;
            model.ServiceNeeded = j.ServiceNeeded;
            model.DNEamount = j.DNEamount;
            model.SpecialNote = j.SpecialNote;
            model.ServiceDate = j.ServiceDate;
            model.ServiceByTime = j.ServiceByTime;
            model.SVCLocationContact = j.SVCLocationContact;
            model.SvcLocationContactPhone = j.SvcLocationContactPhone;
            model.EntryDatetime = j.EntryDatetime;
            model.JobRequestAttachmentsObjectList = new List<JobRequestAttachmentsObject>();
            model.JobRequestAttachmentsObjectList = GetJobRequestAttachmentList(requestKey);


            return model;
        }

        private List<JobRequestAttachmentsObject> GetJobRequestAttachmentList(Guid requestKey)
        {
            List<JobRequestAttachmentsObject> obj = new List<JobRequestAttachmentsObject>();

            var temp = from x in db.JobRequestAttachments
                       where x.RequestKey == requestKey
                       select new JobRequestAttachmentsObject
                       {

                           PKey = x.PKey,
                           RequestKey = x.RequestKey,
                           DocumentTypeKey = x.DocumentTypeKey,
                           DocFile = x.DocFile,
                           Filename = x.Filename,
                           FileType = x.FileType,
                           DocumentName = x.DocumentType.TName

                       };

            obj = temp.ToList();

            return obj;
        }

        internal DataReturn UpdateMainData(JobRequestObject obj)
        {
            DataReturn model = new DataReturn();
            try
            {
                JobRequest _job = db.JobRequest.Find(obj.RequestKey);
                 
                _job.LocationKey = obj.LocationKey;
                _job.CustomerKey = GlobalClass.LoginUser.CustomerKey;
                _job.LocationContactKey = obj.LocationContactKey;
                _job.TradeKey = obj.TradeKey;
                _job.JobPriorityKey = obj.JobPriorityKey;
                _job.ServiceNeeded = obj.ServiceNeeded;
                _job.DNEamount = obj.DNEamount;
                _job.SpecialNote = obj.SpecialNote;
                _job.ServiceDate = obj.ServiceDate;
                _job.ServiceByTime = obj.ServiceByTime;
                _job.SVCLocationContact = obj.SVCLocationContact;
                _job.SvcLocationContactPhone = obj.SvcLocationContactPhone;
                _job.EntryDatetime = DateTime.Now;
                _job.IsRequest = true;
                db.SaveChanges();
                model.flag = 1;
                model.key = _job.RequestKey;
                model.mess = "Data has been Update successfully.";

            }
            catch (Exception ex)
            {
                model.flag = 0;
                model.mess = ex.Message.ToString();
            }
            return model;
        }
    }
}