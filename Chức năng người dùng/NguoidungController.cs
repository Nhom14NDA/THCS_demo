using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;
using WEBSITEBANSACH.Controllers;
namespace WEBSITEBANSACH.Controllers
{
    public class NguoidungController : Controller
    {

        //
        // GET: /DANGKI/
        SACHEntities db = new SACHEntities();

        [HttpGet]
        public ActionResult DangNhap()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            String sTaiKhoan = f["txtTaiKhoan"].ToString();
            String sMatKhau = f.Get("txtMatKhau").ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.Taikhoan == sTaiKhoan && n.Matkhau == sMatKhau);
            if (kh != null && sTaiKhoan != "Admin" && sMatKhau != "123456")
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công!";
                Session["TaiKhoan"] = kh.HoTen;
                Session["MaKhachHang"] = kh.MaKH;
                Session["TaiKhoan1"] = kh;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Admin am = db.Admins.SingleOrDefault(n => n.TaikhoanAdmin == sTaiKhoan && n.MatkhauAdmin == sMatKhau);

                if (am != null)
                {
                    ViewBag.ThongBao = "Chúc mừng đăng nhập thành công!";
                    Session["TaiKhoan"] = am.Hoten;
                    Session["MaKhachHang"] = am.TaikhoanAdmin;
                    Session["TaiKhoanAdmin1"] = am;
                    return RedirectToAction("QlAdmin", "Home");
                }
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            Session["MaKhachHang"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Dangki()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangki(KHACHHANG model)
        {
            try
            {


                db.KHACHHANGs.Add(model);
                db.SaveChanges();
                ModelState.AddModelError("", "Đăng ký thành công !");



            }
            catch
            {
                ModelState.AddModelError("", "Đăng ký thất bại !");
            }
            return View();
        }

    }
}