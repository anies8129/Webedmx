using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webedmx.Models;
namespace Webedmx.Controllers
{
    public class logindbController : Controller
    {
        mvcnormalEntities dbobj = new mvcnormalEntities();
        // GET: logindb
        public ActionResult Login_pageload()
        {
            return View();
        }
        public ActionResult Login_click(logincls objcls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(objcls.uname, objcls.password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    Session["uname"] = objcls.uname;
                    return RedirectToAction("Home");
                }
                else
                {
                    ModelState.Clear();
                    objcls.msg = "invalid login";
                    return View("Login_pageload", objcls);

                }
            }
            return View("Login_pageload", objcls); 
        }
        public ActionResult Home()
        {
            return View();
        }
    }
}