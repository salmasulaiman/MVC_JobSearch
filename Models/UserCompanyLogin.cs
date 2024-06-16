using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_JobSearch.Models
{
    public class UserCompanyLogin
    {

        [Required(ErrorMessage = "Enter the username")]
        public string username { set; get; }
        [Required(ErrorMessage = "Enter password")]
        public string pass { set; get; }
        public string logtype { set; get; }
        public string msg { set; get; }

    }
}