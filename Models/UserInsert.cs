using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_JobSearch.Models
{
    public class checkBoxListHelper
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class checkBoxListHelperskills
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }

    public class UserInsert
    {


        public List<checkBoxListHelperskills> MyFavoriteSkills { get; set; }
        public string[] selectedSkills { get; set; }



        [Required(ErrorMessage = "Enter the name")]
        public string uname { set; get; }
        [Range(18, 50, ErrorMessage = "Enter the age")]
        public int uage { set; get; }
       [Required(ErrorMessage = "Enter the address")]
        public string uaddress { set; get; }

       [Required(ErrorMessage = "Enter the phone")]
       [RegularExpression(@"^(\d{10})$", ErrorMessage = "enter valid number")]
        public string uphone { set; get; }
      [EmailAddress(ErrorMessage = "Enter the valid email id")]
        public string uemail { set; get; }
        public string Qual { get; set; }

        public List<checkBoxListHelper> MyFavoriteQual { get; set; }
        public string[] selectedQual { get; set; }

        [Required(ErrorMessage = "Enter the experience")]
        public string experience { set; get; }
      
        public string skills { set; get; }
        
        public string photo { set; get; }

        public string resume { set; get; }
       
        public string username { set; get; }
        
        public string pass { set; get; }
      // [Compare("pass", ErrorMessage = "password mismatch")]
        public string cpassword { set; get; }

        public string usermsg { set; get; }
    }
}