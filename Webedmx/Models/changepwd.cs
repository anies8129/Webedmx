using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webedmx.Models
{
    public class changepwd
    {
        public string oldpassword { set; get; }
        [Required(ErrorMessage ="enter password")]
        public string newpassword { set; get; }
        [Compare("newpasssword",ErrorMessage = "password missmatch")]
        public string confirmpassword { set; get; }
        public string msg { set; get; }


    }
}