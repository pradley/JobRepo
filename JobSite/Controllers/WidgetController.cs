using JobSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSite.Buisness_Logic;

namespace JobSite.Controllers
{
    public class WidgetController : Controller
    {
        WigetUtility utility = new WigetUtility();
        // GET: Widget
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReverseString(string input)
        {
            ViewData["result"] = utility.ReverseString(input);
            return View("Index");
        }

        [HttpPost]
        public ActionResult SumEvenNumbers(string list)
        {
            ViewData["total"] = utility.SumEvenNumbers(list);
            ViewData["labelid"] = "fixed";
          
            return View("Index");
        }
    }
}