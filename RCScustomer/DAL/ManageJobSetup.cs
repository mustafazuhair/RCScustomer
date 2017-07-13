using RCScustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCScustomer.DAL
{
    public class ManageJobSetup
    {
        private RCSdbEntities db = new RCSdbEntities();
        public DataReturn SaveAttachmentInJobFile(JobFileClass model)
        {
            DataReturn obj = new DataReturn();
            try
            {

                JobFile fj = db.JobFile.SingleOrDefault(m => m.JobKey == model.JobKey && m.DocumentTypeKey == model.DocumentTypeKey);
                if (fj == null)
                {
                }
                else
                {
                    db.JobFile.Remove(fj);
                    db.SaveChanges();
                    db = new RCSdbEntities();
                }
                JobFile invoice = new JobFile();
                Job job = db.Job.Find(model.JobKey);

                invoice.FileKey = Guid.NewGuid();
                invoice.JobKey = (Guid)model.JobKey;
                invoice.DocumentTypeKey = model.DocumentTypeKey;
                //invoice.AddedBy = GlobalClass.LoginUser.PersonnelKey;
                invoice.AddedOn = System.DateTime.Now;
                if (string.IsNullOrEmpty(model.Comment)) invoice.Comment = "--";
                else invoice.Comment = model.Comment;
                invoice.Title = model.Title;
                invoice.Remarks = db.DocumentType.Find(model.DocumentTypeKey).TName + " is Added by "+GlobalClass.LoginUser.Cname;

                invoice.FileContent = model.FileContent;
                invoice.FileType = model.FileType;
                invoice.IsDelete = false;
                invoice.IsFileNew = true;
                db.JobFile.Add(invoice);
                db.SaveChanges();

                obj.flag = 1;
                obj.mess = "Data has been updated successfully.";
            }
            catch (Exception ex)
            {
                obj.mess = ex.ToString();
                obj.flag = 0;
            }
            obj.key = model.JobKey;
            return obj;
        }
        public JobFileClass GetJobFileAttachments(Guid id)
        {
            JobFileClass obj = new JobFileClass();
            try
            {
                obj.Joblist = new List<JobFileClass>();
                var temp = from x in db.JobFile
                           where x.JobKey == id && x.IsDelete == false

                           select new JobFileClass
                           {
                               FileKey = x.FileKey,
                               JobKey = x.JobKey,
                               JobName = x.Job.JobName,
                               DocumentTypeKey = x.DocumentTypeKey,
                               AddedBy = x.AddedBy,
                               AddedOn = x.AddedOn,
                               Comment = x.Comment,
                               Title = x.Title,
                               Remarks = x.Remarks,
                               IsDelete = x.IsDelete,
                               DocumentTypeName = x.DocumentType.TName

                           };
                obj.Joblist = temp.OrderByDescending(m => m.AddedOn).ToList();

            }
            catch (Exception ex)
            {
                string fall = ex.ToString();
            }
            return obj;
        }
        public List<RCSExcel> CustomerCommunicationForDownload(Guid id)
        {
            List<RCSExcel> mainlist = new List<RCSExcel>();
            try
            {
                Job job = db.Job.Find(id);
                var temp = (from x in db.CustomerMesseging
                            where x.JobKey == id && x.IsDelete == false
                            select new RCSExcel
                            {

                                Jobname = x.Job.JobName,
                                Customer = x.Customer.Cname,
                                AddedOn = x.AddedOn,
                                Comment = x.Comment,
                                Title = x.Title,
                                Designation = x.StaffList.Designation,
                                Staffname = x.StaffList.PName
                            }).OrderByDescending(m => m.AddedOn).ToList();
                if (temp.Count() > 0)
                {
                    mainlist = temp;
                }
                else
                {
                    RCSExcel obj = new RCSExcel();
                    obj.Jobname = "None";
                    obj.AddedOn = System.DateTime.Now;
                    obj.Comment = "--";
                    obj.Customer = "--";
                    obj.Title = "--";
                    obj.Designation = "--";
                    obj.Staffname = "--";
                    mainlist.Add(obj);
                }
                var tempContact = from x in db.CustomerContactMesseging where x.JobKey == id && x.IsDelete == false select x;
                if (tempContact.Count() > 0)
                {
                    foreach (var item in tempContact)
                    {
                        RCSExcel obj = new RCSExcel();
                        obj.Jobname = item.Job.JobName;
                        obj.Customer = item.Customer.Cname;
                        obj.AddedOn = item.AddedOn;
                        obj.Comment = item.Comment;
                        obj.Title = item.Title;
                        obj.Designation = item.CustomerContact.Title;
                        obj.Staffname = item.CustomerContact.Cname;

                        mainlist.Add(obj);
                    }
                }
                mainlist.OrderByDescending(m => m.AddedOn);
            }
            catch (Exception ex)
            {
                string srt = ex.Message.ToString();
            }
            return mainlist;
        }

        public CustomerNoteClass FillCustomer_sNotes(Guid id)
        {
            CustomerNoteClass obj = new CustomerNoteClass();
            CustomerContactMesseging cust = db.CustomerContactMesseging.Find(id);
            obj.NoteKey = cust.PKey;
            obj.Comment = cust.Comment;
            obj.AddedBy = cust.AddedBy;
            obj.AddedOn = cust.AddedOn;
            obj.Title = cust.AddedOn.ToString();
            obj.IsDelete = cust.IsDelete;
            return obj;
        }
        public DataReturn SaveCustomermessegingData(RCSMessegeClass obj)
        {
            DataReturn model = new DataReturn();
            try
            {
                CustomerContactMesseging cust = new CustomerContactMesseging();
                cust.PKey = Guid.NewGuid();

                cust.JobKey = obj.mainObj.JobKey;
                cust.AddedBy = GlobalClass.LoginUser.ContactKey;
                cust.AddedOn = obj.mainObj.AddedOn;
                cust.Comment = obj.mainObj.Comment;
                cust.Title = "Update for Job: " + obj.Job.JobName;
                cust.IsDelete = false;
                cust.Remarks = "";
                cust.CustomerKey = obj.VendorKey;
                cust.IsMessegeNew = true;

                db.CustomerContactMesseging.Add(cust);
                db.SaveChanges();

                model.flag = 1;
                model.mess = "Data has been saved successfully.";
                model.key = cust.PKey;

            }
            catch (Exception ex)
            {
                model.flag = 0;
                model.mess = ex.Message.ToString();
            }
            return model;
        }

        public DataReturn UpdateCustomermessegingData(RCSMessegeClass obj)
        {
            DataReturn model = new DataReturn();
            try
            {
                CustomerContactMesseging cust =db.CustomerContactMesseging.Find(obj.mainObj.PKey);
               
                cust.AddedOn = obj.mainObj.AddedOn;
                cust.Comment = obj.mainObj.Comment;
                cust.IsMessegeNew = true;
                cust.Remarks = "Updated on "+System.DateTime.Now.ToString()+" by "+GlobalClass.LoginUser.Cname;
               
                db.SaveChanges();

                model.flag = 1;
                model.mess = "Data has been saved successfully.";
                model.key = cust.PKey;

            }
            catch (Exception ex)
            {
                model.flag = 0;
                model.mess = ex.Message.ToString();
            }
            return model;
        }
        public List<RCSMessegeMain> LoadCustomerMesseginglist(Guid id)
        {
            List<RCSMessegeMain> model = new List<RCSMessegeMain>();
            try
            {

                var temp = (from x in db.CustomerMesseging
                            where x.JobKey == id && x.IsDelete == false
                            select new RCSMessegeMain
                            {
                                PKey = x.PKey,
                                JobKey = x.JobKey,
                                AddedBy = x.AddedBy,
                                AddedOn = x.AddedOn,
                                Comment = x.Comment,
                                Title = x.Title,
                                Designation = x.StaffList.Designation,
                                Staffname = x.StaffList.PName,
                                vendorName = x.Customer.Cname,
                                VendorKey = x.CustomerKey
                            }).OrderByDescending(m => m.AddedOn).ToList();
                model = temp;

            }
            catch (Exception ex)
            {

                string mess = ex.Message.ToString();

            }
            return model;
        }
        public RCSMessegeClass LoadCustomerMessegingData(Guid id)
        {
            RCSMessegeClass model = new RCSMessegeClass();
            model.Messege = new DataReturn();
            model.Messege.mess = "customer communication Details";
            model.Messege.flag = 1;
            model.mainObj = new RCSMessegeMain();
            model.mainObj.JobKey = id;
            model.Job = db.Job.Find(id);
            model.VendorKey = model.Job.CustomerKey;
            model.mailList = new List<RCSMessegeMain>();
            try
            {
                var temp = (from x in db.CustomerMesseging
                            where x.JobKey == id && x.IsDelete == false
                            select new RCSMessegeMain
                            {
                                PKey = x.PKey,
                                JobKey = x.JobKey,
                                AddedBy = x.AddedBy,
                                AddedOn = x.AddedOn,
                                Comment = x.Comment,
                                Title = x.Title,
                                Designation = x.StaffList.Designation,
                                Staffname = x.StaffList.PName,
                                VendorKey = x.CustomerKey,
                                vendorName = x.Customer.Cname,
                                IsAdmin = true
                            }).OrderByDescending(m => m.AddedOn).ToList();
                model.mailList = temp;
                var tempContact = from x in db.CustomerContactMesseging where x.JobKey == id && x.IsDelete == false select x;
                if (tempContact.Count() > 0)
                {
                    foreach (var item in tempContact)
                    {
                        RCSMessegeMain obj = new RCSMessegeMain();
                        obj.PKey = item.PKey;
                        obj.JobKey = item.JobKey;
                        obj.AddedBy = item.AddedBy;
                        obj.AddedOn = item.AddedOn;
                        obj.Comment = item.Comment.Count() > 50 ? item.Comment.Substring(0, 50) + "...." : item.Comment;
                        obj.Title = item.Title;
                        obj.Designation = item.CustomerContact.Title;
                        obj.Staffname = item.CustomerContact.Cname;
                        obj.VendorKey = item.CustomerKey;
                        obj.vendorName = item.Customer.Cname;
                        obj.IsAdmin = false;
                        model.mailList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {

                model.Messege.mess = ex.Message.ToString();
                model.Messege.flag = 0;
            }
            model.mailList.OrderByDescending(m => m.AddedOn);
            return model;
        }
        internal JobClass FillMainJob(Guid id)
        {
            JobClass _job = new JobClass();
            Job jobEntity = db.Job.Find(id);

            _job.JobKey = jobEntity.JobKey;
            _job.JobName = jobEntity.JobName;
            _job.CustomerKey = jobEntity.CustomerKey;
            _job.CustomerName = jobEntity.Customer.Cname;
            _job.CContactKey = jobEntity.CContactKey;
            if (jobEntity.CustomerJobStatusKey == null) _job.CustomerJobStatus = "";
            else _job.CustomerJobStatus = jobEntity.CustomerJobStatus.TName;
            if (jobEntity.CustomerContact != null)
            {
                _job.CustomerContactName = jobEntity.CustomerContact.Cname;
            }
            else
            {
                _job.CustomerContactName = "";
            }


            _job.CustomerDNE = jobEntity.CustomerDNE;
            _job.Priority = jobEntity.JobType.TName;
            _job.TradeKey = jobEntity.TradeKey;
            _job.TradeName = jobEntity.Trade.TName;
            _job.EntryDate = jobEntity.EntryDate.Value.ToShortDateString();
            _job.JobStatusName = jobEntity.JobStatus.TName;
            _job.PO = jobEntity.PO;
            _job.Description = jobEntity.Description;
            _job.IVRTrackingNo = jobEntity.IVRTrackingNo;
            _job.IVRPin = jobEntity.IVRPin;
            if (jobEntity.ScheduleDate == null) _job.ScheduleDate = "";
            else  _job.ScheduleDate = jobEntity.ScheduleDate.Value.ToShortDateString();
            if (jobEntity.ReturnScheduleDate == null) _job.ReturnScheduleDate = "";
            else _job.ReturnScheduleDate = jobEntity.ReturnScheduleDate.Value.ToShortDateString();
            _job.LocationKey = jobEntity.LocationKey;
            _job.LocationName = jobEntity.Location.Lname;
            _job.LocationContactKey = jobEntity.LocationContactKey;
            _job.LocationContactName = jobEntity.CustomerContact.Cname;
            _job.LocationContactAddress = jobEntity.Location.Address;
            _job.LocationContactCityName = jobEntity.Location.CityList.CityName;
            _job.LocationContactStateName = jobEntity.Location.StateList.StateName;
            _job.LocationContactZipCode = jobEntity.Location.ZIPcode;

           var asd = (from z in db.JobTeam
                      join y in db.TeamMember on z.TeamKey equals y.ID
                      where z.IsDelete == false && y.IsDelete == false && y.IsAccountManager == true && z.JobKey == id
                      select y.StaffList).ToList();
            if (asd == null)
            {
                _job.RCSAccountManagerName = "";
                _job.RCSAccountManagerEmail = "";
                _job.RCSAccountManagerPhone = "";
             
            }
            else
            {
                foreach(var item in asd)
                {
                    _job.RCSAccountManagerName = item.PName;
                    _job.RCSAccountManagerEmail = item.Mail;
                    _job.RCSAccountManagerPhone = item.Mobile;
                  
                }
            }
            return _job;
        }

        
        private string GetVendorPhoneNo(Guid vendorKey)
        {
            string asd = "";
            VendorContact count = db.VendorContact.FirstOrDefault(m => m.VendorKey == vendorKey && m.IsDefault == true && m.IsDelete == false);
            if (count == null) asd = "";
            else
            {
                asd = count.Phone + " - " + count.PhoneEXT;
            }
            return asd;
        }
        private string GetVendorTradeName(Guid vendorKey)
        {
            string asd = "";
            var count = from p in db.VendorTrade
                        where p.VendorKey == vendorKey && p.IsDelete == false
                        select p;
            foreach (var item in count)
            {
                asd = asd + item.Trade.TName + " , ";
            }
            return asd;
        }
        private int GetVendorNoOfTrade(Guid vendorKey)
        {
            int count = (from p in db.VendorTrade
                         where p.VendorKey == vendorKey && p.IsDelete == false
                         select p).Count();

            return count;
        }
         
    }
}