using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;
namespace WEBSITEBANSACH.Controllers
{
    public class CHUDEController : Controller
    {
        //
        // GET: /CHUDE/
     
        //bam vo xem gio hang de xem gio 
        SACHEntities db = new SACHEntities();
        public PartialViewResult CHUDEpartial()
        {
            var theloai = db.CHUDEs.ToList();
            return PartialView(theloai);
        }
        public ActionResult SPTHEOCHUDE(int id)
        {
            var sach = from s in db.CHITIETSACHes where  s.MACHUDE == id select s;
            return View(sach);
        }
	}
}