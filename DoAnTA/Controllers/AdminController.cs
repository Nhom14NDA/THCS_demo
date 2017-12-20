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
        
        SACHEntities db = new SACHEntities();
      
        

        public ActionResult Sach(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.CHITIETSACHes.ToList().OrderBy(n => n.MaCTS).ToPagedList(pageNumber, pageSize));
        }


        //////////////////////////////////////////QUAN LY SACH/////////////////////////////////////
        public ActionResult sachchinh(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.SACHes.ToList().OrderBy(n => n.MaSach).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult themsachchinh()
        {


            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult themsachchinh(SACH sachchinh)
        {


            if (ModelState.IsValid)
            {

                db.SACHes.Add(sachchinh);
                db.SaveChanges();
            }
            return RedirectToAction("sachchinh");
        }
        [HttpGet]
        public ActionResult xoasachchinh(int masachchinh)
        {
            //lay doi tuong theo mã 
            SACH cd = db.SACHes.SingleOrDefault(n => n.MaSach == masachchinh);
            ViewBag.Masachchinh = cd.MaSach;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(cd);

        }
        [HttpPost, ActionName("xoasachchinh")]

        public ActionResult Xacnhansachchinh(int masachchinh)
        {
            SACH cd = db.SACHes.SingleOrDefault(n => n.MaSach == masachchinh);
            ViewBag.Masachchinh = cd.MaSach;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SACHes.Remove(cd);
            db.SaveChanges();
            return RedirectToAction("sachchinh");

        }
        [HttpGet]
        public ActionResult suasachchinh(int masachchinh)
        {
            //lay doi tuong theo mã 
            SACH cd = db.SACHes.SingleOrDefault(n => n.MaSach == masachchinh);

            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(cd);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult suasachchinh(SACH sachchinh, FormCollection f)
        {

            if (ModelState.IsValid)
            {
                db.Entry(sachchinh).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("sachchinh");

        }
        ///////////////////////////////////////////KHACH HANG////////////////////////////////////////////
     
        public ActionResult KHACHHANG(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.KHACHHANGs.ToList().OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult themKH()
        {


            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult themKH(KHACHHANG kh)
        {


            if (ModelState.IsValid)
            {

                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
            }
            return RedirectToAction("KHACHHANG");
        }
        [HttpGet]
        public ActionResult xoaKH(int maKH)
        {
            //lay doi tuong theo mã 
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == maKH);
            ViewBag.Masach = kh.MaKH;
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(kh);

        }
        [HttpPost, ActionName("xoaKH")]

        public ActionResult Xacnhankhachhang(int maKH)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == maKH);
            ViewBag.Masach = kh.MaKH;
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KHACHHANGs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("KHACHHANG");

        }
        [HttpGet]
        public ActionResult suakh(int makh)
        {
            //lay doi tuong theo mã 
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == makh);

            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(kh);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult suakh(KHACHHANG qlkh, FormCollection f)
        {

            if (ModelState.IsValid)
            {
                db.Entry(qlkh).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("KHACHHANG");

        }
	/////////////////////////////////////////THONG KE/////////////////////////////////////////////
        public ActionResult thongke()
        {
           
            var model = db.CHITIETSACHes
                .GroupBy(p=> p.CHUDE)
                .Select(g => new baocao
                {
                    Group = g.Key.Tenchude,
                    soluong= (int)(g.Sum(p => p.Soluongton)),
                    dongia = (float)(g.Sum(p => p.Dongia * p.Soluongton)),
                    Min = (float)(g.Min(p => p.Dongia)),
                    Max = (float)(g.Max(p => p.Dongia)),
                    Avg = (int)(g.Average(p => p.Dongia * p.Soluongton))                 
                  
                    
                });
            return View("thongke", model);
           
        }

}

