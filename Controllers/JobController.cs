using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_JobSearch.Models;

namespace MVC_JobSearch.Controllers
{
    public class JobController : Controller
    {
        MyMVCProjectDBEntities dbobj = new MyMVCProjectDBEntities();
        // GET: Job
        public ActionResult Job_Pageload()
        {
            JobInsert user = new JobInsert();
            
            user.MyFavoriteSkill = getSkillData();

            return View(user);
           
        }
        public List<checkBoxListHelperskill> getSkillData()
        {
            List<checkBoxListHelperskill> sts = new List<checkBoxListHelperskill>()
            { new checkBoxListHelperskill{Value="ASP.NET",Text="ASP.NET",IsChecked=true},
            new checkBoxListHelperskill{Value="SQL",Text="SQL",IsChecked=false},
            new checkBoxListHelperskill{Value="HTML",Text="HTML",IsChecked=false},
            new checkBoxListHelperskill{Value="CSS",Text="CSS",IsChecked=false},
            new checkBoxListHelperskill{Value="BOOTSTRAP",Text="BOOTSTRAP",IsChecked=false},
            new checkBoxListHelperskill{Value="JAVASCRIPT",Text="JAVASCRIPT",IsChecked=false}


            };
            return sts;
        }

        public ActionResult job_Click(JobInsert clsobj)
        {

            if (ModelState.IsValid)
            {
                var skill = string.Join(",", clsobj.selectedSkill);
                clsobj.jobskills = skill;

                clsobj.MyFavoriteSkill = getSkillData();

                int getid = Convert.ToInt32(Session["uid"]);
                dbobj.sp_jobinsert(getid,clsobj.jobtitle,clsobj.jobexp,clsobj.jobskills,clsobj.vaccancy,clsobj.date,"available");
            
                clsobj.msg = "successfully inserted";
                return View("Job_Pageload", clsobj);
            }
            return View("Job_Pageload", clsobj);
        }
    }
}