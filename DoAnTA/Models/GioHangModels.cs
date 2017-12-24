using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBSITEBANSACH.Models
{
    public class GioHangModels
    {
        SACHEntities db = new SACHEntities();
        public List<CHITIETSACH> Items = new List<CHITIETSACH>();
        public int iMaSach { set; get; }
        public string sTenSach { set; get; }
        public string sAnhBia { set; get; }
        public double dDongia { set; get; }
        public int iSoLuong { set; get; }
        public double dThanhTien
        {
            get { return iSoLuong * dDongia; }
        }
        public int soluong
        {
            get
            {
                var sl = Items.Sum(p =>p.Soluongton);
                return soluong;
            }
        }

  
        public GioHangModels(int MaSach)
        {
            iMaSach = MaSach;
            CHITIETSACH ctsanh = db.CHITIETSACHes.Single(n => n.MaCTS==iMaSach);
            sTenSach = ctsanh.TensachCT;
            sAnhBia = ctsanh.Anhbia;
            dDongia = double.Parse(ctsanh.Dongia.ToString());
            iSoLuong = 1;

        }

        

       
    }
}