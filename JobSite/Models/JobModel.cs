using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSite.Models
{
    public class JobModel
    {
        public List<Job> Jobs { get; set; }
        public int Pages => Jobs.Count % 2 == 0 ? Jobs.Count / 10 : Convert.ToInt32(Math.Ceiling(Jobs.Count / 10M));
    }
}