using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webedmx.Models;

namespace Webedmx.Controllers
{
    public class insertdbController : Controller
    {
        mvcnormalEntities obj = new mvcnormalEntities();
        // GET: insertdb
        public ActionResult Insert_pageload()
        {
            List<stclass> stlist = new List<stclass>
            {
                new stclass{sid=1, sname="kerala"},
                new stclass{sid=2, sname="tamilnadu"},
                new stclass{sid=3, sname="karnataka"}
            };

            ViewBag.SelectList = new SelectList(stlist, "sid", "sname");
            insercls obj = new insercls();
            obj.myfavoritequal = getqualificationdata();
            return View(obj);
        }
        public List<checkboxlisthelper> getqualificationdata()
        {
            List<checkboxlisthelper> sts = new List<checkboxlisthelper>()
            {
                new checkboxlisthelper { value = "sslc", text = "sslc", ischecked = true },
               new checkboxlisthelper { value = "bca", text = "bca", ischecked = false },
                new checkboxlisthelper { value = "plustwo", text = "plustwo", ischecked = false },
                new checkboxlisthelper { value = "btech", text = "btech", ischecked = false },


            };
            return sts;

        }
        public ActionResult Insert_click(insercls clsobj, HttpPostedFileBase file,FormCollection form)
        {
             if(ModelState.IsValid)
            {
                if(file.ContentLength>0)
                {
                    string sname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/PHS");
                    string pa = Path.Combine(s, sname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\PHS", sname);
                    clsobj.photo = fullpath;
                }
                List<stclass> stlist = new List<stclass>
                {
                new stclass{sid=1, sname="kerala"},
                new stclass{sid=2, sname="tamilnadu"},
                new stclass{sid=3, sname="karnataka"}
                };
                ViewBag.SelectList = new SelectList(stlist, "sid", "sname");

                 int selectid = Convert.ToInt32(form["selstates"]);
                stclass selecteditem = stlist.FirstOrDefault(c => c.sid == selectid);
                clsobj.sid = selecteditem.sid;
                clsobj.sname = selecteditem.sname;

                var quid = string.Join(",", clsobj.selectedqual);
                clsobj.qual = quid;
                clsobj.myfavoritequal = getqualificationdata();

                obj.sp_insert(clsobj.name, clsobj.age, clsobj.address, clsobj.email, clsobj.photo, clsobj.gender, clsobj.sname,clsobj.qual, clsobj.username, clsobj.pwd);
                clsobj.msg = "successfully inserted";
                return View("Insert_pageload", clsobj);
            }
            else
            {
                List<stclass> stlist = new List<stclass>
                {
                  new stclass{sid=1, sname="kerala"},
                  new stclass{sid=2, sname="tamilnadu"},
                  new stclass{sid=3, sname="karnataka"}
                };  
                ViewBag.SelectList = new SelectList(stlist, "sid", "sname");
                clsobj.myfavoritequal = getqualificationdata();
            }
            return View("Insert_pageload", clsobj);
        }
    }
}
