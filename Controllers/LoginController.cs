using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_JobSearch.Models;

namespace MVC_JobSearch.Controllers
{
    public class LoginController : Controller
    {
        MyMVCProjectDBEntities dbobj = new MyMVCProjectDBEntities();
        // GET: Login
        
        public ActionResult Login_pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult CompanyHome()
        {
            return View();
        }
        public ActionResult Login_Click(UserCompanyLogin objcls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(objcls.username, objcls.pass, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_loginId(objcls.username, objcls.pass).FirstOrDefault();
                    Session["uid"] = uid;
                    var lt = dbobj.sp_loginType(objcls.username, objcls.pass).FirstOrDefault();
                    if (lt == "user")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "company")
                    {
                       return RedirectToAction("CompanyHome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    objcls.msg = "Invalid login";
                    return View("Login_pageload", objcls);
                }
            }
            return View("Login_pageload", objcls);
        }
    }
}