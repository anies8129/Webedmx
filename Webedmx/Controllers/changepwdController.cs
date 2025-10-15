using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webedmx.Models;

namespace Webedmx.Controllers
{

    public class changepwdController : Controller
    {
        mvcnormalEntities dbobj = new mvcnormalEntities();
        // GET: changepwd
        public ActionResult pwd_load()
        {
            var getdata= dbobj.sp_selectpwd(Session["uname"].ToString()).FirstOrDefault();
            return View(new changepwd
            {
                oldpassword = getdata
            });
        }
        public ActionResult pwd_click(changepwd obj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_pwdchange(Session["uname"].ToString(), obj.oldpassword,obj.newpassword,op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    obj.msg = "password changed";
                    return View("pwd_load", obj);
                }
                else
                {
                    obj.msg = "invalid password";
                    return View("pwd_load", obj);
                }
            }
            return View("pwd_load", obj);
        }
    }
}