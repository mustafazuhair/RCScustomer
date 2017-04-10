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

        public DataReturn SaveMainData(JobClass obj)
        {
            DataReturn model = new DataReturn();
            try
            {
                Job _job = new Job();
                _job.JobKey = Guid.NewGuid();
                _job.JobName = obj.JobName;
                _job.CustomerKey = obj.CustomerKey;
                _job.CContactKey = obj.CContactKey;
                _job.CustomerDNE = obj.CustomerDNE;
                _job.JobTypeKey = obj.JobTypeKey;
                _job.TradeKey = obj.TradeKey;
                _job.EntryDate = obj.EntryDate;
                _job.JobStatusKey = obj.JobStatusKey;
                _job.PO = obj.PO;
                _job.Description = obj.Description;
                _job.IVRTrackingNo = obj.IVRTrackingNo;
                _job.IVRPin = obj.IVRPin;
                _job.ScheduleDate = obj.ScheduleDate;
                _job.ReturnScheduleDate = obj.ReturnScheduleDate;
                _job.LocationKey = obj.LocationKey;
                _job.LocationContactKey = obj.LocationContactKey;
                db.Job.Add(_job);
                db.SaveChanges();

                model.key = _job.JobKey;
                if (obj.ToTeamKey.Count() > 0)
                {
                    foreach (var item in obj.ToTeamKey)
                    {
                        db = new RCSdbEntities();
                        JobTeam team = new JobTeam();
                        team.Addedon = System.DateTime.Now;
                        team.IsDelete = false;
                        team.JobKey = (Guid)model.key;
                        team.PKey = Guid.NewGuid();
                        team.TeamKey = Guid.Parse(item.ToString());
                        team.Remarks = "";
                        db.JobTeam.Add(team);
                        db.SaveChanges();
                        var mem = db.TeamMember.Where(m => m.IsDelete == false).ToList();
                        if (mem.Count() > 0)
                        {
                            foreach (var mitem in mem)
                            {
                                db = new RCSdbEntities();
                                JobAccountManager m = new JobAccountManager();
                                m.Addedon = System.DateTime.Now;
                                m.IsDelete = false;
                                m.JobKey = (Guid)model.key;
                                m.PKey = Guid.NewGuid();
                                m.PersonnelKey = mitem.PersonnelKey;
                                team.Remarks = "";
                                db.JobAccountManager.Add(m);
                                db.SaveChanges();
                            }

                        }
                    }
                }
                model.flag = 1;
                model.mess = "Data has been saved successfully.";
            }
            catch (Exception ex)
            {
                model.flag = 0;
                model.mess = ex.Message.ToString();
            }
            return model;
        }

        public DataReturn UpdateJobMainData(JobClass obj)
        {
            DataReturn model = new DataReturn();
            try
            {
                Job _job = db.Job.Find(obj.JobKey);

                _job.JobName = obj.JobName;
                _job.CustomerKey = obj.CustomerKey;
                _job.CContactKey = obj.CContactKey;
                _job.CustomerDNE = obj.CustomerDNE;
                _job.JobTypeKey = obj.JobTypeKey;
                _job.TradeKey = obj.TradeKey;
                _job.EntryDate = obj.EntryDate;
                _job.JobStatusKey = obj.JobStatusKey;
                _job.PO = obj.PO;
                _job.Description = obj.Description;
                _job.IVRTrackingNo = obj.IVRTrackingNo;
                _job.IVRPin = obj.IVRPin;
                _job.ScheduleDate = obj.ScheduleDate;
                _job.ReturnScheduleDate = obj.ReturnScheduleDate;
                _job.LocationKey = obj.LocationKey;
                _job.LocationContactKey = obj.LocationContactKey;
                db.SaveChanges();

                model.key = _job.JobKey;

                // Delete Existing Job Team

                using (var db = new RCSdbEntities())
                {
                    var JobTeams = db.JobTeam.Where(f => f.JobKey == model.key).ToList();
                    JobTeams.ForEach(a => a.IsDelete = true);
                    db.SaveChanges();
                }



                // Delete Existing Accout Manager

                using (var db = new RCSdbEntities())
                {
                    var JobAccountManager = db.JobAccountManager.Where(f => f.JobKey == model.key).ToList();
                    JobAccountManager.ForEach(a => a.IsDelete = true);
                    db.SaveChanges();
                }



                if (obj.ToTeamKey.Count() > 0)
                {
                    foreach (var item in obj.ToTeamKey)
                    {
                        db = new RCSdbEntities();
                        JobTeam team = new JobTeam();
                        team.Addedon = System.DateTime.Now;
                        team.IsDelete = false;
                        team.JobKey = (Guid)model.key;
                        team.PKey = Guid.NewGuid();
                        team.TeamKey = Guid.Parse(item.ToString());
                        team.Remarks = "";
                        db.JobTeam.Add(team);
                        db.SaveChanges();
                        var mem = db.TeamMember.Where(m => m.IsDelete == false).ToList();
                        if (mem.Count() > 0)
                        {
                            foreach (var mitem in mem)
                            {
                                db = new RCSdbEntities();
                                JobAccountManager m = new JobAccountManager();
                                m.Addedon = System.DateTime.Now;
                                m.IsDelete = false;
                                m.JobKey = (Guid)model.key;
                                m.PKey = Guid.NewGuid();
                                m.PersonnelKey = mitem.PersonnelKey;
                                team.Remarks = "";
                                db.JobAccountManager.Add(m);
                                db.SaveChanges();
                            }

                        }
                    }
                }
                model.flag = 1;
                model.mess = "Data has been saved successfully.";
            }
            catch (Exception ex)
            {
                model.flag = 0;
                model.mess = ex.Message.ToString();
            }
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

            if (jobEntity.CustomerContact != null)
            {
                _job.CustomerContactName = jobEntity.CustomerContact.Cname;
            }
            else
            {
                _job.CustomerContactName = "";
            }


            _job.CustomerDNE = jobEntity.CustomerDNE;
            _job.JobTypeKey = jobEntity.JobTypeKey;
            _job.TradeKey = jobEntity.TradeKey;
            _job.TradeName = jobEntity.Trade.TName;
            _job.EntryDate = jobEntity.EntryDate;
            _job.JobStatusKey = jobEntity.JobStatusKey;
            _job.PO = jobEntity.PO;
            _job.Description = jobEntity.Description;
            _job.IVRTrackingNo = jobEntity.IVRTrackingNo;
            _job.IVRPin = jobEntity.IVRPin;
            _job.ScheduleDate = jobEntity.ScheduleDate;
            _job.ReturnScheduleDate = jobEntity.ReturnScheduleDate;
            _job.LocationKey = jobEntity.LocationKey;
            _job.LocationName = jobEntity.Location.Lname;
            _job.LocationContactKey = jobEntity.LocationContactKey;
            _job.LocationContactName = jobEntity.LocationContact.Cname;
            _job.LocationContactAddress = jobEntity.Location.Address;
            _job.LocationContactCityName = jobEntity.Location.CityList.CityName;
            _job.LocationContactStateName = jobEntity.Location.StateList.StateName;
            _job.LocationContactZipCode = jobEntity.Location.ZIPcode;


            List<System.Guid> _teamList = new List<System.Guid>();

            List<JobTeam> _JobTeamEntity = db.JobTeam.Where(m => m.JobKey == id && m.IsDelete == false).ToList();

            foreach (JobTeam item in _JobTeamEntity)
            {
                _teamList.Add(item.TeamKey);
            }

            _job.ToTeamKey = _teamList.AsEnumerable();

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