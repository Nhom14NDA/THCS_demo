using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace WEBSITEBANSACH.Models
{
    [MetadataTypeAttribute(typeof(CHUDEMetadata))]
    public partial class CHUDE
    {
        internal sealed class CHUDEMetadata
        {
            [Display(Name = "Mã chủ đề")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public int MaChuDe { get; set; }
            [Display(Name = "Tên chủ đề")]
            //[Required(ErrorMessage = "Vui Lòng Nhập Dữ Liệu Cho Trường Này.")]
            public string Tenchude { get; set; }
            
          
           

        }
    }
}