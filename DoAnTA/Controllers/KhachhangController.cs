using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;
namespace WEBSITEBANSACH.Controllers
{
    public class KhachhangController : Controller
    {
      
        QLBSEntities db = new QLBSEntities();
        [HttpPost]
        public ActionResult DangNhap(String Id, String Password)
        {
            var user = db.KHACHHANGs.Find(Id);
            if (user == null)
            {
                ModelState.AddModelError("", "Sai tên đang nhập");
            }
            else if (user.Matkhau != Password)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
     
            else
            {
                ModelState.AddModelError("", "Đăng nhập thành công");

            }
            return View("model");
        }
        //[HttpGet]
        //public ActionResult DangNhap(FormCollection collection)
        //{
        //    var tendn = collection["Id"];
        //    var matkhau = collection["Password"];
        //    if (String.IsNullOrEmpty(tendn))
        //    {
        //        ViewData["Loi1"] = "Vui lòng nhập tên đăng nhập";
        //    }
        //    else if (String.IsNullOrEmpty(matkhau))
        //    {
        //        ViewData["Loi2"] = "Vui lòng nhập mật khẩu";
        //    }
        //    else
        //    {
        //        KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
        //        if (kh != null)
        //        {
        //            ViewBag.thongbao = "Đăng nhập thành công";
        //            Session["Taikhoan"] = kh;
        //        }
        //        else
        //            ViewBag.thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
        //    }
        //    return View("Dangnhap");
        //}
       
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(FormCollection collection,KHACHHANG kh)
        {
            var hoten=collection["HotenKH"];
            var tendn=collection["TenDN"];
            var matkhau=collection["MatKhau"];
            var xacnhanmatkhau=collection["XacNhanMatKhau"];
            var diachi=collection["DienThoai"];
            var email=collection["Email"];
            var dienthoai = collection["DienThoai"];
            var  gioitinh= collection["GioiTinh"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["NgaySinh"]);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được trống";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(xacnhanmatkhau))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu";
            }
             if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email không được bỏ trống";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "Phải nhập số điện thoại";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi7"] = "phải nhập giới tính";
            }
            else
            {
                kh.HoTen = hoten;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.Diachi = diachi;
                kh.Dienthoai = dienthoai;
                kh.Gioitinh = gioitinh;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
                //return RedirectToAction("Dangnhap");
            }

            return View("DangKi");
        }

     
        
        
	   }
}

	
