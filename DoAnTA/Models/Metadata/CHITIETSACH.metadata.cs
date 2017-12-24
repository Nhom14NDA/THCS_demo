using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WEBSITEBANSACH.Models
{
    [MetadataTypeAttribute(typeof(chitietsachMetadata))]
    public partial class CHITIETSACH
    {
        internal sealed class chitietsachMetadata
        {
            [Display(Name = "Mã Chi Tiết Sách")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public int MaCTS { get; set; }
            [Display(Name = "Mã Sách")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public Nullable<int> MaSach { get; set; }
            [Display(Name = "Tên  Sách")]
            [Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public string TensachCT { get; set; }
            [Display(Name = "Mô Tả")]

            public string Mota { get; set; }
            [Display(Name = "Ảnh Bìa")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public string Anhbia { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "cập Nhật Ngày")]
            [Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public Nullable<System.DateTime> Ngaycapnhat { get; set; }
            [Display(Name = "Số Lượng Tồn")]
            [Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public Nullable<int> Soluongton { get; set; }
            [Display(Name = "Đơn Giá")]
            [Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public Nullable<decimal> Dongia { get; set; }
            [Display(Name = "Tên Chủ Đề")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public Nullable<int> MACHUDE { get; set; }

        }
    }
}