using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_JobSearch.Models;

namespace MVC_JobSearch.Controllers
{
    public class CompanyRegController : Controller
    {
        MyMVCProjectDBEntities dbobj = new MyMVCProjectDBEntities();
        // GET: CompanyReg
        public ActionResult Insertcompany_Pageload()
        {
            return View();
        }
        public ActionResult Insertcompany_click(CompanyInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_companyReg(regid, clsobj.cname, clsobj.caddress, clsobj.cphone, clsobj.cemail,clsobj.cwebsite,clsobj.location);
                dbobj.sp_loginsert(regid, clsobj.cusername, clsobj.cpass, "company");
                clsobj.companymsg = "successfully inserted";
                return View("Insertcompany_Pageload", clsobj);
            }
            return View("Insertcompany_Pageload", clsobj);
        }
    }
}