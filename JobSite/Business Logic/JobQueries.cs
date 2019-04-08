using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using JobSite.Models;

namespace JobSite.Business_Logic
{
    public class JobQueries
    {

        public string GetCitysWithTheMostJobs(DbSet<Job> jobs)
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

        public bool JobHasBeenAdded(DbSet<Job> jobs, string companyName)
        {
            return jobs.Any(c => c.Company.ToLower() == companyName.ToLower()) ?  true: false;

        }

        public string TestMethod( string output)
        {
            return "Hallo";
        }

        public string NumberOfJobsAppliedFor(DbSet<Job> jobs)
        {

            return jobs.Count().ToString();
        }

        public string MethodCaller(string methodName)
        {
            MethodInfo theMethod = this.GetType().GetMethod(methodName);
           var result = theMethod.Invoke(this, new object[] { methodName });
            return result.ToString();
        }
    }
}