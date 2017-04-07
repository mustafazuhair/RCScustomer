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
                model.mess = "Data has been saved successfully.";
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