using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_JobSearch.Models
{
    public class CompanyInsert
    {
        [Required(ErrorMessage = "Enter the name")]
        public string cname { set; get; }
        [Required(ErrorMessage = "Enter the address")]
        public string caddress { set; get; }
        [Required(ErrorMessage = "Enter the phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "enter valid number")]
        public string cphone { set; get; }
        [EmailAddress(ErrorMessage = "Enter the valid email id")]
        public string cemail { set; get; }
        [Required(ErrorMessage = "Enter the company website")]
        public string cwebsite { set; get; }
        [Required(ErrorMessage = "Enter the company location")]
        public string location { set; get; }

        [Required(ErrorMessage = "Enter the username")]
        public string cusername { set; get; }
        [Required(ErrorMessage = "Enter password")]
        public string cpass { set; get; }
        [Compare("cpass", ErrorMessage = "password mismatch")]
        public string ccpassword { set; get; }

        public string companymsg { set; get; }
    }
}