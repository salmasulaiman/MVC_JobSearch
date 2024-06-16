using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_JobSearch.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;



namespace MVC_JobSearch.Controllers
{
    public class SearchJobController : Controller
    {
        MyMVCProjectDBEntities dbobj = new MyMVCProjectDBEntities();
        // GET: SearchJob
        public ActionResult searchjob_Pageload()
        {
            return View(GetData());
        }
        private JobSearch GetData()
        {
            var joblist = new JobSearch();
            List<string> lst = new List<string>();
            var job = dbobj.Jobs.ToList();
            foreach (var e in job)
            {
                var jobcls = new jsearch();
                jobcls.job_id = e.J_Id;
                jobcls.jobtitle = e.JTitle;
                jobcls.company_Id = e.C_Id;
                jobcls.skills = e.JSkills;
                jobcls.experience = e.JExperience;
                jobcls.job_Status = e.Status;
                jobcls.last_Date = e.Date;

                joblist.selectjob.Add(jobcls);

                var s = jobcls.skills;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
            }
            return joblist;
        }
        public ActionResult searchjob_click(JobSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.experience))
            {
                qry += " and JExperience like '%" + clsobj.insertse.experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.skills))
            {
                qry += " and JSkills like '%" + clsobj.insertse.skills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.jobtitle))
            {
                qry += " and JTitle like '%" + clsobj.insertse.jobtitle + "%'";
            }
            return View("searchjob_Pageload", getdata1(clsobj, qry));
        }
        private JobSearch getdata1(JobSearch clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while (dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.company_Id = Convert.ToInt32(dr["C_Id"].ToString());
                    jobcls.jobtitle = dr["JTitle"].ToString();
                    jobcls.skills = dr["JSkills"].ToString();
                    jobcls.experience = dr["JExperience"].ToString();
                    jobcls.job_Status = dr["Status"].ToString();
                    jobcls.last_Date = dr["Date"].ToString();

                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;


            }
        }




    }
}