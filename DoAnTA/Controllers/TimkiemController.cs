using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;
using PagedList.Mvc;
using PagedList;
namespace WEBSITEBANSACH.Controllers
{
    public class TimkiemController : Controller
    {
        //
        // GET: /Timkiem/
        SACHEntities db = new SACHEntities();
        public ActionResult Ketquatimkiem(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<CHITIETSACH> lstKQTK = db.CHITIETSACHes.Where(n => n.TensachCT.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.CHITIETSACHes.OrderBy(n => n.TensachCT).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TensachCT).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Ketquatimkiem(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<CHITIETSACH> lstKQTK = db.CHITIETSACHes.Where(n => n.TensachCT.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.CHITIETSACHes.OrderBy(n => n.TensachCT).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TensachCT).ToPagedList(pageNumber, pageSize));
        }
    }

    }
	
