using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobSite.Business_Logic;
using JobSite.Examples.ReplaceConstructorWithFactoryMethod;
using JobSite.Models;

namespace JobSite.Controllers
{
    public class JobsController : Controller
    {
        private JobContext jobContext = new JobContext();
     
        private SortFactory sortFactory;

        private JobQueries jobQueries;

        public JobsController()
        {
             jobQueries = new JobQueries(jobContext);
        }

        // GET: Jobs
        public ActionResult Index()
        {
            var poodle = Dog.Create("Poodle");
            poodle.Bark();

            return View(jobContext.Jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = jobContext.Jobs.Find(id);
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
            if (!ModelState.IsValid) return RedirectToAction("Index");
         
            if (jobQueries.JobHasBeenAdded(job.Company)) return Content("This Job has already been added");

            jobContext.Jobs.Add(job);
            jobContext.SaveChanges();

            return View(job);
        }

        [HttpPost]
        public ActionResult OrderBy(string key, string order)
        {

            sortFactory = new SortFactory(jobContext.Jobs,order);

            var sortMethod = sortFactory.GetSortMethod(key);

            var result = sortMethod();

            

           return Json(result);
    
        }

        //[HttpPost]
        //public ActionResult JobExists(string companyName)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        if (jobQueries.JobHasBeenAdded(jobContext.Jobs, companyName))
        //        {
        //            return Json("Yes");
        //        }
        //        else
        //        {
        //            return Json("No");
        //        }
              
        //    }
        //    return View();
        //}

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = jobContext.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [HttpPost]
        public ActionResult JobQuery(string methodName,string param)
        {
            return Json(jobQueries.MethodCaller(methodName,param), "text/plain");
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
                jobContext.Entry(job).State = EntityState.Modified;
                jobContext.SaveChanges();
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
            Job job = jobContext.Jobs.Find(id);
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
            Job job = jobContext.Jobs.Find(id);
            jobContext.Jobs.Remove(job);
            jobContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                jobContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
