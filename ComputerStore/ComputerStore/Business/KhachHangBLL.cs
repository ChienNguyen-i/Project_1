using System;
using System.Collections;
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
            if (kh.tenKH != "" && kh.gioiTinh != "" && kh.diaChi != "" && kh.soDT != "")
            {
                kh.tenKH = ComputerStore.Utility.CongCu.ChuanHoaXau(kh.tenKH);
                kh.gioiTinh = ComputerStore.Utility.CongCu.ChuanHoaXau(kh.gioiTinh);
                kh.diaChi = ComputerStore.Utility.CongCu.ChuanHoaXau(kh.diaChi);
                kh.soDT = ComputerStore.Utility.CongCu.CatXau(kh.soDT);
                khDAL.Insert(kh);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public KhachHang LayKhachHang(int makh)
        {
            int i;
            List<KhachHang> list = khDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maKH == makh)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaKhachHang(int makh)
        {
            int i;
            List<KhachHang> list = khDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maKH == makh)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                khDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaKhachHang(KhachHang kh)
        {
            int i;
            List<KhachHang> list = khDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maKH == kh.maKH)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(kh, i);
                khDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại khách hàng này.");
        }
        public List<KhachHang> TimKhachHang(KhachHang kh)
        {
            List<KhachHang> list = khDAL.GetData();
            List<KhachHang> kq = new List<KhachHang>();
            if (kh.maKH == 0 && kh.tenKH == null)
            {
                kq = list;
            }
            //Tìm theo tên
            if (kh.tenKH != null && kh.maKH == 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenKH.IndexOf(kh.tenKH) >= 0)
                        kq.Add(new KhachHang(list[i]));
            }
            //Tìm theo mã
            else if (kh.tenKH == null && kh.maKH != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maKH == kh.maKH)
                        kq.Add(new KhachHang(list[i]));
            }
            else
                kq = null;
            return kq;
        }
    }
}
