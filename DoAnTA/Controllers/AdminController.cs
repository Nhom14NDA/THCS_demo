using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;




namespace WEBSITEBANSACH.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        SACHEntities db = new SACHEntities();
      
        public ActionResult TrangAdmin()
        {

            return View();
        }

        




}

