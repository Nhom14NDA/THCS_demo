using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WEBSITEBANSACH.Models
{
    [MetadataTypeAttribute(typeof(KHACHHANGMetadata))]
    public partial class KHACHHANG
    {
        internal sealed class KHACHHANGMetadata
        {

            [Display(Name = "Mã Khách Hàng")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public int MaKH { get; set; }
            [Display(Name = "Họ Tên KH")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public string HoTen { get; set; }
            [Display(Name = "Tài Khoản")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public string Taikhoan { get; set; }
            [Display(Name = "Mật Khẩu")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public string Matkhau { get; set; }
            [Display(Name = "Email")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public string Email { get; set; }
            [Display(Name = "Địa Chỉ")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]

            public string Diachi { get; set; }
            [Display(Name = "Điện Thoại")]
            [Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public string Dienthoai { get; set; }
            [Display(Name = "Giới Tính")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public string Gioitinh { get; set; }
            //[DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "Ngày Sinh")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
           
            public Nullable<System.DateTime> Ngaysinh { get; set; }

        }

    }
}
 