using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_JobSearch.Models;

namespace MVC_JobSearch.Controllers
{
    public class ApplyJobController : Controller
    {
        MyMVCProjectDBEntities dbobj = new MyMVCProjectDBEntities();
        // GET: Application
        public ActionResult Application_Pageload(int cid, int jid)
        {
            TempData["cid"] = cid;
            TempData["jid"] = jid;
            return View();
        }
        public ActionResult Application_click(ApplyInsert clsobj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file.ContentLength > 0)
                {
                    string pname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Resume");
                    string p = Path.Combine(s, pname);
                    file.SaveAs(p);

                    var fpath = Path.Combine("~\\Resume", pname);
                    clsobj.resume = fpath;//set

                }


                string dt = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("yyyy-MM-dd");
                dbobj.sp_applicationInsert(Convert.ToInt32(Session["uid"]), Convert.ToInt32(TempData["jid"]), Convert.ToInt32(TempData["cid"]), clsobj.resume, dt, "applied"); ;

                clsobj.applymsg = "successfully inserted";
                return View("Application_Pageload", clsobj);
            }

            return View("Application_Pageload", clsobj);


        }
    }

}