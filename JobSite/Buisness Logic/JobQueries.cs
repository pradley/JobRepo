using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using JobSite.Models;

namespace JobSite.Buisness_Logic
{
    public class JobQueries
    {

        internal string GetCitysWithTheMostJobs(DbSet<Job> jobs)
        {
            //When time permits I would to refactor this query to be more flexible by taking a variable from the user and returning the city with the most x
            var sb = new StringBuilder();

            //Get citys with the most jobs
            var citys = jobs.GroupBy(g => g.City)
                .Where(w => w.Count() > 1);


            // Get the highest groups 
            var answers= citys
                .Where(x => x.Count() == citys
                .Max(z => z.Count()));


            
            //Build a string of the answer 
            foreach (var answer in answers)
            {
                sb.Append(answer.Key);
                sb.Append(",");
            }

            //Remove the trailing comma 
           
            sb.Remove(sb.ToString().Length-1, 1);

             
            return sb.ToString();
        }

        internal bool JobHasBeenAdded(DbSet<Job> jobs, string companyName)
        {
            if (jobs.Any(c => c.Company.ToLower() == companyName.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        internal string NumberOfJobsAppliedFor(DbSet<Job> jobs)
        {

            return jobs.Count().ToString();
        }
    }
}