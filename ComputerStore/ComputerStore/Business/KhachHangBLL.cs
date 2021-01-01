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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IKhachHangBLL
    public class KhachHangBLL : IKhachHangBLL
    {
        private IKhachHangDAL khDAL = new KhachHangDAL();
        public List<KhachHang> LayDSKhachHang()
        {
            return khDAL.GetData();
        }
        public void ThemKhachHang(KhachHang kh)
        {
            if (kh.tenKH != "" && kh.diaChi != "" && kh.soDT != "")
            {
                kh.tenKH = CongCu.ChuanHoaXau(kh.tenKH);
                kh.diaChi = CongCu.ChuanHoaXau(kh.diaChi);
                kh.soDT = CongCu.ChuanHoaMa(kh.soDT);
                khDAL.Insert(kh);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public KhachHang LayKhachHang(string makh)
        {
            KhachHang kh = null;
            foreach (KhachHang khachhang in khDAL.GetData())
            {
                if (khachhang.maKH == makh)
                {
                    kh = new KhachHang(khachhang);
                    break;
                }
            }
            return kh;
        }
        public void XoaKhachHang(string makh)
        {
            if (KT_MaKhachHang(makh) == true)
                khDAL.Delete(makh);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaKhachHang(KhachHang kh)
        {
            if (KT_MaKhachHang(kh.maKH) == true)
                khDAL.Update(kh);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public List<KhachHang> TimKhachHang(KhachHang kh)
        {
            List<KhachHang> list = khDAL.GetData();
            List<KhachHang> kq = new List<KhachHang>();
            if (kh.maKH == null && kh.tenKH == null)
            {
                kq = list;
            }
            if (kh.tenKH != null && kh.maKH == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenKH.IndexOf(kh.tenKH) >= 0)
                        kq.Add(new KhachHang(list[i]));
            }
            else if (kh.tenKH == null && kh.maKH != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maKH == kh.maKH)
                        kq.Add(new KhachHang(list[i]));
            }
            else
                kq = null;
            return kq;
        }
        public bool KT_MaKhachHang(string makh)
        {
            bool kt = false;
            foreach (KhachHang khachhang in khDAL.GetData())
                if (khachhang.maKH == makh)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public bool KT_TenKhachHang(string tenkh)
        {
            bool kt = false;
            foreach (KhachHang khachhang in khDAL.GetData())
                if (khachhang.tenKH == tenkh || khachhang.tenKH.IndexOf(tenkh) >= 0)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
    }
}
