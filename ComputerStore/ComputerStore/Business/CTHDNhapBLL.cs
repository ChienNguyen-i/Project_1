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
    public class CTHDNhapBLL : ICTHDNhapBLL
    {
        private ICTHDNhapDAL cthdnDAL = new CTHDNhapDAL();
        public List<CTHDNhap> LayDS_CTHDNhap()
        {
            return cthdnDAL.GetData();
        }
        public void ThemCTHDNhap(CTHDNhap cthdn)
        {

            if (cthdn.maHDN != "" && cthdn.maMT != "" && cthdn.tenMT != "")
            {
                cthdn.maHDN = CongCu.ChuanHoaMa(cthdn.maHDN);
                cthdn.maMT = CongCu.ChuanHoaMa(cthdn.maMT);
                cthdn.tenMT = CongCu.ChuanHoaXau(cthdn.tenMT);
                cthdnDAL.Insert(cthdn);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public bool KT_MaMT(string mamt)
        {
            bool kt = false;
            foreach (CTHDNhap cthdnhap in cthdnDAL.GetData())
                if (cthdnhap.maMT == mamt)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public CTHDNhap LayMT(string mamt)
        {
            CTHDNhap cthdn = null;
            foreach (CTHDNhap cthdnhap in cthdnDAL.GetData())
            {
                if (cthdnhap.maMT == mamt)
                {
                    cthdn = new CTHDNhap(cthdnhap);
                    break;
                }
            }
            return cthdn;
        }
        public List<CTHDNhap> LayCTHDNhap(CTHDNhap cthdn)
        {
            List<CTHDNhap> list = cthdnDAL.GetData();
            List<CTHDNhap> kq = new List<CTHDNhap>();
            if (cthdn.maHDN == null)
            {
                kq = list;
            }
            if (cthdn.maHDN != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maHDN == cthdn.maHDN)
                        kq.Add(new CTHDNhap(list[i]));
            }
            else
                kq = null;
            return kq;
        }
        public void XoaCTHDNhap(string mahdn)
        {
            if (KT_MaHDN(mahdn) == true)
                cthdnDAL.Delete(mahdn);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public bool KT_MaHDN(string mahdn)
        {
            bool kt = false;
            foreach (CTHDNhap cthdnhap in cthdnDAL.GetData())
                if (cthdnhap.maHDN == mahdn)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
    }
}