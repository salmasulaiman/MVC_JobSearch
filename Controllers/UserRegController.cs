using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_JobSearch.Models;

namespace MVC_JobSearch.Controllers
{
    public class UserRegController : Controller
    {
        MyMVCProjectDBEntities dbobj = new MyMVCProjectDBEntities();
        // GET: UserReg
        public ActionResult Insertuser_Pageload()
        {

            UserInsert user = new UserInsert();
            user.MyFavoriteQual = getQualificationData();
            user.MyFavoriteSkills = getSkillsData();

            return View(user);
        }
        public List<checkBoxListHelper> getQualificationData()
        {
            List<checkBoxListHelper> sts = new List<checkBoxListHelper>()
            { new checkBoxListHelper{Value="SSLC",Text="SSLC",IsChecked=true},
            new checkBoxListHelper{Value="PLUS TWO",Text="PLUS TWO",IsChecked=false},
            new checkBoxListHelper{Value="BCA",Text="BCA",IsChecked=false},
            new checkBoxListHelper{Value="MCA",Text="MCA",IsChecked=false},
            new checkBoxListHelper{Value="BTECH",Text="BTECH",IsChecked=false},
            new checkBoxListHelper{Value="MTECH",Text="MTECH",IsChecked=false}


            };
            return sts;
        }
        public List<checkBoxListHelperskills> getSkillsData()
        {
            List<checkBoxListHelperskills> sts = new List<checkBoxListHelperskills>()
            { new checkBoxListHelperskills{Value="ASP.NET",Text="ASP.NET",IsChecked=true},
            new checkBoxListHelperskills{Value="SQL",Text="SQL",IsChecked=false},
            new checkBoxListHelperskills{Value="HTML",Text="HTML",IsChecked=false},
            new checkBoxListHelperskills{Value="CSS",Text="CSS",IsChecked=false},
            new checkBoxListHelperskills{Value="BOOTSTRAP",Text="BOOTSTRAP",IsChecked=false},
            new checkBoxListHelperskills{Value="JAVASCRIPT",Text="JAVASCRIPT",IsChecked=false}


            };
            return sts;
        }

        public ActionResult Insertuser_click(UserInsert clsobj, HttpPostedFileBase file1, HttpPostedFileBase file2)
        {
            if (ModelState.IsValid)
            {
            
                if (file1.ContentLength > 0)
                {
                    string pname = Path.GetFileName(file1.FileName);
                    var s = Server.MapPath("~/Photos");
                    string p = Path.Combine(s, pname);
                    file1.SaveAs(p);

                    var fpath = Path.Combine("~\\Photos", pname);
                    clsobj.photo = fpath;//set

                }
                if (file2.ContentLength > 0)
                {
                    string pname = Path.GetFileName(file2.FileName);
                    var s = Server.MapPath("~/Resume");
                    string p = Path.Combine(s, pname);
                    file2.SaveAs(p);

                    var fpath = Path.Combine("~\\Resume", pname);
                    clsobj.resume = fpath;//set

                }
                var quid = string.Join(",", clsobj.selectedQual);
                clsobj.Qual = quid;//set

                clsobj.MyFavoriteQual = getQualificationData();//get


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



                var skill = string.Join(",", clsobj.selectedSkills);
                clsobj.skills = skill;

                clsobj.MyFavoriteSkills = getSkillsData();


                dbobj.sp_userReg(regid, clsobj.uname, clsobj.uage, clsobj.uaddress, clsobj.uphone, clsobj.uemail, clsobj.Qual, clsobj.experience, clsobj.skills,clsobj.photo,clsobj.resume); ;
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "user");
                clsobj.usermsg = "successfully inserted";
                return View("Insertuser_Pageload", clsobj);
            }
            else
            {

                clsobj.MyFavoriteQual = getQualificationData();
                clsobj.MyFavoriteSkills = getSkillsData();
            }
            return View("Insertuser_Pageload", clsobj);








        }
    }
}