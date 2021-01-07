using System;
using System.Collections.Generic;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer;
using ComputerStore.DataAccessLayer.Interface;
using ComputerStore.Business.Interface;

namespace ComputerStore.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IHDNhapBLL
    public class HDNhapBLL : IHDNhapBLL
    {
        private IHDNhapDAL hdnDAL = new HDNhapDAL();
        public List<HDNhap> LayDSHDNhap()
        {
            return hdnDAL.GetData();
        }
        public void ThemHDNhap(HDNhap hdn)
        {
            if (hdn.maNV != "" && hdn.maNCC != "" && hdn.ngayNhap != "")
            {
                hdn.maNV = CongCu.ChuanHoaMa(hdn.maNV);
                hdn.maNCC = CongCu.ChuanHoaMa(hdn.maNCC);
                hdn.ngayNhap = CongCu.ChuanHoaMa(hdn.ngayNhap);
                hdnDAL.Insert(hdn);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public void XoaHDNhap(string mahdn)
        {
            if (KT_MaHDN(mahdn) == true)
                hdnDAL.Delete(mahdn);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public List<HDNhap> TimHDNhap(HDNhap hdn)
        {
            List<HDNhap> list = hdnDAL.GetData();
            List<HDNhap> kq = new List<HDNhap>();
            if (hdn.maHDN == null)
            {
                kq = list;
            }
            if (hdn.maHDN != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maHDN == hdn.maHDN)
                        kq.Add(new HDNhap(list[i]));
            }
            else
                kq = null;
            return kq;
        }
        public bool KT_MaHDN(string mahdn)
        {
            bool kt = false;
            foreach (HDNhap hdnhap in hdnDAL.GetData())
                if (hdnhap.maHDN == mahdn)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public HDNhap LayMaHDN(string mamv, string mancc, string ngaynhap)
        {
            HDNhap hdn = null;
            foreach (HDNhap hdnhap in hdnDAL.GetData())
            {
                if (hdnhap.maNV == mamv && hdnhap.maNCC == mancc && hdnhap.ngayNhap == ngaynhap)
                {
                    hdn = new HDNhap(hdnhap);
                    break;
                }
            }
            return hdn;
        }
        public double TTien(string mahd)
        {
            HDNhapDAL hdnDAL = new HDNhapDAL();
            return hdnDAL.TongTien(mahd);
        }
        public string LayMaNCC(string mamt)
        {
            HDNhapDAL hdnDAL = new HDNhapDAL();
            return hdnDAL.LayNCC(mamt);
        }
    }
}