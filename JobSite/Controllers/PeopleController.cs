using JobSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSite.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReverseString(WidgetModel wm)
        {
            wm.StringToReverse = new string(Enumerable.Range(1, wm.StringToReverse.Length).Select(i => wm.StringToReverse[wm.StringToReverse.Length - i]).ToArray());
            return View("Index", wm);

            
            //@Html.TextBox("Reverse box", null, new { @class = "Widget-Control" });
        }

    }
}