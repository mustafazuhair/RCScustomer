using RCScustomer.DAL;
using RCScustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCScustomer.Controllers
{
    public class JobDetailsController : Controller
    {

        private RCSdbEntities db = new RCSdbEntities();

        private ManageJobSetup manage = new ManageJobSetup();
        // GET: JobDetails
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewJobDetails(Guid id)
        {


            if (GlobalClass.SystemSession)
            {
                ViewBag.mess = "Job Profile";
                JobClass model = new JobClass();
                model = manage.FillMainJob(id);
                ViewBag.JobTypeKey = new SelectList(db.JobType.Where(m => m.IsDelete == false).OrderBy(m => m.TName), "ID", "TName", model.JobTypeKey);
                var jobStatuslist = (from x in db.JobStatus
                                     join y in db.JobStatusUsergroup on x.ID equals y.JobStatusID
                                     where x.IsDelete == false
                                     select x);
                ViewBag.JobStatusKey = new SelectList(jobStatuslist.ToList(), "ID", "TName", model.JobStatusKey);



                // Main Team List
                List<SelectListItem> listSelectListItems = new List<SelectListItem>();
                foreach (Team city in db.Team.Where(m => m.IsDelete == false).OrderBy(m => m.TName))
                {
                    SelectListItem selectList = new SelectListItem()
                    {
                        Text = city.TName,
                        Value = city.ID.ToString(),
                    };
                    listSelectListItems.Add(selectList);
                }

                List<SelectListItem> existListSelectListItems = new List<SelectListItem>();
                if (model.ToTeamKey != null)

                {

                    foreach (var item in listSelectListItems)
                    {
                        foreach (var toitem in model.ToTeamKey)
                        {
                            if (item.Value == toitem.ToString())
                            {
                                existListSelectListItems.Add(item);
                            }
                        }
                    }


                }

                // Final From List
                List<SelectListItem> fromlistSelectListItems = new List<SelectListItem>();
                fromlistSelectListItems = listSelectListItems.Where(o => !existListSelectListItems.Contains(o)).ToList();

                // Final To List
                List<SelectListItem> tolistSelectListItems = new List<SelectListItem>();
                tolistSelectListItems = listSelectListItems.Where(o => existListSelectListItems.Contains(o)).ToList();


                model.FromTeamKeyList = fromlistSelectListItems; // Assign From Team  List
                model.ToTeamKeyList = tolistSelectListItems;



                return View(model);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
    }
}