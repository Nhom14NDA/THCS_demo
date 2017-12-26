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
        //
        // GET: /GioHang/
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
       private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHangModels> lstGioHang = Session["GioHang"] as List<GioHangModels>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        private double TongTien()
        {
            double iTongTien = 0;
            List<GioHangModels> lstGioHang = Session["GioHang"] as List<GioHangModels>;
            if (lstGioHang != null)
            {
                iTongTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return iTongTien;
        }
        //cap nhat gio hang
        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHangModels> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }


        public ActionResult DatHang(FormCollection collection)
        {
            //thêm đơn hàng
            DONHANG dh = new DONHANG();
            KHACHHANG kh = (KHACHHANG)Session["TaiKhoan1"];

            List<GioHangModels> gh = LayGioHang();
            dh.MaKH = kh.MaKH;
            dh.NgayDat = DateTime.Now;
            var NgayGiao = String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);
            dh.NgayGiao = DateTime.Parse(NgayGiao);
            dh.TinhTrangGiaoHang = false;
            dh.DaThanhToan = false;
            db.DONHANGs.Add(dh);
            db.SaveChanges();
            //thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                ctdh.MaDonHang = dh.MaDonHang;
                ctdh.MASACHCT = item.iMaSach;
                ctdh.Soluong = item.iSoLuong;
                ctdh.DonGia = (float)item.dDongia;
                db.CHITIETDONHANGs.Add(ctdh);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("XacNhanDonHang", "GioHang");
        }
        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}