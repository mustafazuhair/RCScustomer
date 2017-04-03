using System;
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
    public class ManageCustomerSetup
    {
        private RCSdbEntities db = new RCSdbEntities();
        public CustomerNoteClass FillCustomerNotes(Guid id)
        {
            CustomerNoteClass obj = new CustomerNoteClass();
            CustomerNote cust = db.CustomerNote.Find(id);
            obj.CustomerKey = cust.CustomerKey;
            obj.NoteKey = cust.NoteKey;
            obj.Comment = cust.Comment;
            obj.AddedBy = cust.AddedBy;
            obj.AddedOn = cust.AddedOn;
            obj.Title = cust.Title;
            obj.IsDelete = cust.IsDelete;

            return obj;
        }
    }
}