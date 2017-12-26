using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;
namespace WEBSITEBANSACH.Controllers
{
    public class SachmoiController : Controller
    {
        //
        // GET: /Sachmoi/
        SACHEntities db = new SACHEntities();
        public PartialViewResult SACHMOIpartial()
        {
            var sachmoi = db.CHITIETSACHes.Take(4).ToList();
            return PartialView(sachmoi);
        }
        public ActionResult chitiet(int id)
        {
            var chitiet = from s in db.CHITIETSACHes
                          where s.MaCTS == id
                          select s;
            return View(chitiet.Single());
        }
	}
}