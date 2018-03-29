using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobSite.Business_Logic;
using JobSite.Models;

namespace JobSite.Controllers
{
    public class JobsController : Controller
    {
        private CentralDBEntities1 db = new CentralDBEntities1();
        private JobQueries jobQ = new JobQueries();
        private SortFactory sortFactory;
 

     

        // GET: Jobs
        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //TODO [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create([Bind(Include = "JobID,Company,Role,Language,Distcance,Date,City")] Job job)
        {
            if (ModelState.IsValid)
            {

                if (jobQ.JobHasBeenAdded(db.Jobs, job.Company))
                {
                    return Content("This Job has already been added");
                }
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        [HttpPost]
        public ActionResult OrderBy(string key, string order)
        {

            sortFactory = new SortFactory(db.Jobs,order);

            var sortMethod = sortFactory.GetSortMethod(key);

            var result = sortMethod();

            

           return Json(result);
    
        }

        [HttpPost]
        public ActionResult JobExists(string companyName)
        {
            if (ModelState.IsValid)
            {

                if (jobQ.JobHasBeenAdded(db.Jobs, companyName))
                {
                    return Json("Yes");
                }
                else
                {
                    return Json("No");
                }
              
            }
            return View();
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        public ActionResult GetCitysWithTheMostJobs()
        {
            return Content(jobQ.GetCitysWithTheMostJobs(db.Jobs),"text/plain");
        }

        public ActionResult NumberOfJobsAppliedFor()
        {
            return Content(jobQ.NumberOfJobsAppliedFor(db.Jobs), "text/plain");
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobID,Company,Role,Language,Distcance,Date,City")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        public ActionResult Analytics()
        {
            return PartialView("Analytics");
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
