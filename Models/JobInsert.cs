using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_JobSearch.Models
{
    public class checkBoxListHelperskill
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class JobInsert
    {
        public List<checkBoxListHelperskill> MyFavoriteSkill { get; set; }
        public string[] selectedSkill { get; set; }

        public string jobtitle { set; get; }
        public string jobexp { set; get; }
        public string jobskills { set; get; }
        public int vaccancy { set; get; }
        public string date { set; get; }
      
        public string msg { set; get; }

    }
}