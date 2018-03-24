using JobSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobSite.Business_Logic
{
    public class SortMethods 
    {
        private DbSet<Job> jobsTable;
        private string sortOrder;

      public SortMethods(DbSet<Job> dbSet, string order)
        {
            jobsTable = dbSet;

            sortOrder = order;

        }

        public IOrderedQueryable SortByCompany()
        {
            if (sortOrder== "ascending")
            {
                return jobsTable.OrderBy(c => c.Company);
            }
            else
            {
                return jobsTable.OrderByDescending(c => c.Company);
            }

        }
    }
}