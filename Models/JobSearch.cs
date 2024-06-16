using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_JobSearch.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();
        }
        public jsearch insertse { set; get; }
        public List<jsearch> selectjob { set; get; }
    }

    public class jsearch
    {
        public int job_id { get; set; }
        public int company_Id { get; set; }

        public string jobtitle { get; set; }

        public string skills { get; set; }

        public string experience { get; set; }
        public string job_Status { get; set; }
        public string last_Date { get; set; }
        public string jobmsg { get; set; }

    }

}
