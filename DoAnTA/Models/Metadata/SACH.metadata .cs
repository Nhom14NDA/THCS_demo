using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEBSITEBANSACH.Models.Metadata
{
    [MetadataTypeAttribute(typeof(SACHMetadata))]
    public partial class SACH
    {
        internal sealed class SACHMetadata
        {
            [Display(Name = "Mã Sách")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public int MaSach { get; set; }
            [Display(Name = "Tên Sách")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public string Tensach { get; set; }
         


        }
    }
}