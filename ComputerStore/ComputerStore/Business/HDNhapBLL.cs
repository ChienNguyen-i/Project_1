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
            if (hdn.maNV != "" && hdn.maNCC != "" && hdn.maMT != "" && hdn.ngayNhap != "")
            {
                hdn.maNV = CongCu.CatXau(hdn.maNV.ToUpper());
                hdn.maNCC = CongCu.CatXau(hdn.maNCC.ToUpper());
                hdn.maMT = CongCu.CatXau(hdn.maMT.ToUpper());
                hdn.ngayNhap = CongCu.CatXau(hdn.ngayNhap);
                hdnDAL.Insert(hdn);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public HDNhap LayHDNhap(string mahdn)
        {
            HDNhap hdn = null;
            foreach (HDNhap hdnhap in hdnDAL.GetData())
            {
                if (hdnhap.maHDN == mahdn)
                {
                    hdn = new HDNhap(hdnhap);
                    break;
                }
            }
            return hdn;
        }
        public void XoaHDNhap(string mahdn)
        {
            if (KT_MaHDN(mahdn) == true)
                hdnDAL.Delete(mahdn);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaHDNhap(HDNhap hdn)
        {
            if (KT_MaHDN(hdn.maHDN) == true)
                hdnDAL.Update(hdn);
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
    }
}
