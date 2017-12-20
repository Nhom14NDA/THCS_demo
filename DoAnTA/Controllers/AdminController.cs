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
        
        public ActionResult Sach(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.CHITIETSACHes.ToList().OrderBy(n => n.MaCTS).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult themmoi()
        {

            ViewBag.MACHUDE = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.Tenchude), "MACHUDE", "Tenchude");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult themmoi(CHITIETSACH sach, HttpPostedFileBase fileUpload)
        {
            ViewBag.MACHUDE = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.Tenchude), "MACHUDE", "Tenchude");
            if (fileUpload == null)
            {
                ViewBag.thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    //luu ten file luu ý bo sung thu vien using IO
                    var filename = Path.GetFileName(fileUpload.FileName);
                    //luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/hinhanh/sach/"), filename);
                    //kiem tra hinh anh ton tai chua
                    if (System.IO.File.Exists(path))
                        ViewBag.thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    sach.Anhbia = filename;
                    db.CHITIETSACHes.Add(sach);
                    db.SaveChanges();
                }
                return RedirectToAction("Sach");
            }
        }
        //  chitietsach
        public ActionResult chitietsach(int Mactsach)
        {
            //lay doi tuong theo mã 
            CHITIETSACH sach = db.CHITIETSACHes.SingleOrDefault(n => n.MaCTS == Mactsach);
            ViewBag.Masach = sach.MaSach;
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);

        }
        [HttpGet]
        public ActionResult suasach(int Mactsach)
        {
            //lay doi tuong theo mã 
            CHITIETSACH sach = db.CHITIETSACHes.SingleOrDefault(n => n.MaCTS == Mactsach);

            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MACHUDE = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.Tenchude), "MACHUDE", "Tenchude", sach.MACHUDE);
            return View(sach);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult suasach(CHITIETSACH sach, FormCollection f)
        {

            if (ModelState.IsValid)
            {
                db.Entry(sach).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.MACHUDE = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.Tenchude), "MACHUDE", "Tenchude", sach.MACHUDE);
            return RedirectToAction("Sach");

        }

        [HttpGet]
        public ActionResult xoasach(int Mactsach)
        {
            //lay doi tuong theo mã 
            CHITIETSACH sach = db.CHITIETSACHes.SingleOrDefault(n => n.MaCTS == Mactsach);
            ViewBag.Masach = sach.MaSach;
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MACHUDE = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.Tenchude), "MACHUDE", "Tenchude", sach.MACHUDE);
            return View(sach);

        }
        [HttpPost, ActionName("xoasach")]

        public ActionResult Xacnhanxoa(int Mactsach)
        {
            CHITIETSACH sach = db.CHITIETSACHes.SingleOrDefault(n => n.MaCTS == Mactsach);
            ViewBag.Masach = sach.MaSach;
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.CHITIETSACHes.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Sach");

        }
        //////////////////////////CHU DE////////////////////////////////
        public ActionResult chude(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.CHUDEs.ToList().OrderBy(n => n.MaChuDe).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult themchude()
        {


            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult themchude(CHUDE chude)
        {


            if (ModelState.IsValid)
            {

                db.CHUDEs.Add(chude);
                db.SaveChanges();
            }
            return RedirectToAction("chude");
        }
        [HttpGet]
        public ActionResult xoacd(int macd)
        {
            //lay doi tuong theo mã 
            CHUDE cd = db.CHUDEs.SingleOrDefault(n => n.MaChuDe == macd);
            ViewBag.Masach = cd.MaChuDe;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(cd);

        }
        [HttpPost, ActionName("xoacd")]

        public ActionResult Xacnhanchude(int macd)
        {
            CHUDE cd = db.CHUDEs.SingleOrDefault(n => n.MaChuDe == macd);
            ViewBag.Masach = cd.MaChuDe;
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.CHUDEs.Remove(cd);
            db.SaveChanges();
            return RedirectToAction("chude");

        }
        [HttpGet]
        public ActionResult suachude(int macd)
        {
            //lay doi tuong theo mã 
            CHUDE cd = db.CHUDEs.SingleOrDefault(n => n.MaChuDe == macd);

            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(cd);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult suachude(CHUDE chudesach, FormCollection f)
        {

            if (ModelState.IsValid)
            {
                db.Entry(chudesach).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("chude");

        }
        //doanh thu thống kê theo chủ đề 

        public ActionResult thongkedoanhthu()
        {
            var model = db.CHITIETDONHANGs
                .GroupBy(d => d.CHITIETSACH.CHUDE)
                .ToList()
                .Select(g => new baocao
                {
                    Group = g.Key.Tenchude,
                    soluong = (int)(g.Sum(p => p.Soluong)),
                    dongia = (double)(g.Sum(p => p.DonGia *p.Soluong)),
                    Min = (double)(g.Min(p => p.DonGia)),
                    Max = (double)(g.Max(p => p.DonGia)),
                    Avg = (int)(g.Average(p => p.DonGia * p.Soluong)) 
                });
            return View("thongkedoanhthu", model);
        }
       

    }




}

