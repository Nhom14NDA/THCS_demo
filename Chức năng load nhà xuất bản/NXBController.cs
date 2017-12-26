using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;

namespace WEBSITEBANSACH.Controllers
{
    public class NXBController : Controller
    {
        //
        // GET: /NXB/

        //
        // GET: /NXB/
        SACHEntities db = new SACHEntities();
        public PartialViewResult NXBpartial()
        {
            var NXB = db.NHAXUATBANs.ToList();
            return PartialView(NXB);
        }
        public ActionResult SPTHEONXB(int id)
        {
            var xb = from s in db.CHITIETSACHes where s.MANXB == id select s;
            return View(xb);
        }
	}
}