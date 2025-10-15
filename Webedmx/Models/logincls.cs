using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webedmx.Models
{
    public class logincls
    {
        [Required(ErrorMessage ="enter the user name")]
        public string uname { set; get; }
        [Required(ErrorMessage = "enter the password")]
        public string password { set; get;}
        public string msg { set; get; }


    }
}