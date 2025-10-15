using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webedmx.Models
{
    public class stclass
    {
        public int sid { get; set; }
        public string sname { get; set; }
    }
    public class checkboxlisthelper
    {
        public string value { get; set; }
        public string text { get; set; }
        public bool ischecked { get; set; }
    }
    public class insercls
    {
        public int sid { get; set; }
        public string sname { get; set; }

        public List<checkboxlisthelper> myfavoritequal { get; set; }
        public string[] selectedqual { get; set; }

       // [Required (ErrorMessage ="enter the name")]
        public  string name { get; set; }
       // [Range(18,50,ErrorMessage ="enter the age")]
        public int age { get; set; }
      //  [Required(ErrorMessage = "enter the address")]

        public string address { get; set; }
      //  [EmailAddress(ErrorMessage ="enter valid email")]
        public string email { get; set; }
        public string photo { get; set; }
        public string gender { get; set; }
        public string qual { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }
      //  [Compare("pwd",ErrorMessage ="password missmatch")]
        public string cpassword { get; set; }
        public string msg { get; set; }

    }
}