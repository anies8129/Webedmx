using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webedmx.Models;

namespace Webedmx.Controllers
{
    public class profiledbController : Controller
    {
        mvcnormalEntities objd = new mvcnormalEntities();
        // GET: profiledb
        public ActionResult Profile_Load()
        {
            var getdata = objd.sp_profilee(Session["uname"].ToString()).FirstOrDefault();
            return View(new prfoilecls
            {
                name = getdata.name,
                age = getdata.age,
                address = getdata.address,
                email = getdata.email,
                photo = getdata.photo
            });
        }
        public ActionResult profile_update(prfoilecls obj)
        {
            objd.sp_profile_update(Session["uname"].ToString(), obj.age, obj.address);

            var getdata = objd.sp_profilee(Session["uname"].ToString()).FirstOrDefault();
            return View("Profile_Load", new prfoilecls
            {
                name = getdata.name,
                age = getdata.age,
                address = getdata.address,
                email = getdata.email,
                photo = getdata.photo,
                msg = "updated"
            }
             ); ;
        }

    
    }
}