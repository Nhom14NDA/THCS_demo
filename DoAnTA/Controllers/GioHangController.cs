using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;
namespace WEBSITEBANSACH.Controllers
{
    public class GioHangController : Controller
    {
        
        SACHEntities db = new SACHEntities();
        public List<GioHangModels> LayGioHang()
        {
            List<GioHangModels> lstGioHang = Session["GioHang"] as List<GioHangModels>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHangModels>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        
}