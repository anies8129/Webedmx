using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webedmx.Models;

namespace Webedmx.Controllers
{
    public class selectallusersController : Controller
    {
        mvcnormalEntities dbo = new mvcnormalEntities();
        // GET: selectallusers
        public ActionResult Displayall_sp_load()
        {
            var data = dbo.sp_selectAll().ToList();
            ViewBag.userdetails = data;
           return View();
        }
    }
}