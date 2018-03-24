using JobSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobSite.Business_Logic
{
    public class SortFactory
    {
        public Dictionary<string, Func<IOrderedQueryable>> strategyRepository;


        private SortMethods sorter;

  
 

        public SortFactory(DbSet<Job> jobsTable, string order)
        {
            sorter = new SortMethods(jobsTable,order);
           
            strategyRepository = new Dictionary<string, Func<IOrderedQueryable>>()
            {
                { "Company",sorter.SortByCompany},
            };
        }



        public Func<IOrderedQueryable> GetSortMethod(string key)
        {
            //TODO Change this to try get value 
            if (string.IsNullOrWhiteSpace(key))
            {
                return sorter.SortByCompany;
            }
           
            return strategyRepository[key];
        }






    }
}