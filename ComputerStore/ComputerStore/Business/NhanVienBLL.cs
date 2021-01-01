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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại INhanVienBLL
    public class NhanVienBLL : INhanVienBLL
    {
        private INhanVienDAL nvDAL = new NhanVienDAL();
        public List<NhanVien> LayDSNhanVien()
        {
            return nvDAL.GetData();
        }
        public void ThemNhanVien(NhanVien nv)
        {
            if (nv.tenNV != "" && nv.ngaySinh != "" && nv.gioiTinh != "" && nv.diaChi != "" && nv.soDT != "" && nv.loaiNV != "" && nv.pass != "")
            {
                nv.tenNV = CongCu.ChuanHoaXau(nv.tenNV);
                nv.ngaySinh = CongCu.ChuanHoaMa(nv.ngaySinh);
                nv.gioiTinh = CongCu.ChuanHoaXau(nv.gioiTinh);
                nv.diaChi = CongCu.ChuanHoaXau(nv.diaChi);
                nv.soDT = CongCu.ChuanHoaMa(nv.soDT);
                nv.loaiNV = CongCu.HoaDau(nv.loaiNV);
                nv.pass = CongCu.GetMD5(nv.pass);
                nvDAL.Insert(nv);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public NhanVien LayNhanVien(string manv)
        {
            NhanVien nv = null;
            foreach (NhanVien nhanvien in nvDAL.GetData())
            {
                if (nhanvien.maNV == manv)
                {
                    nv = new NhanVien(nhanvien);
                    break;
                }
            }
            return nv;
        }
        public void XoaNhanVien(string manv)
        {
            if (KT_MaNhanVien(manv) == true)
                nvDAL.Delete(manv);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaNhanVien(NhanVien nv)
        {
            if (KT_MaNhanVien(nv.maNV) == true)
                nvDAL.Update(nv);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public List<NhanVien> TimNhanVien(NhanVien nv)
        {
            List<NhanVien> list = nvDAL.GetData();
            List<NhanVien> kq = new List<NhanVien>();
            if (nv.maNV == null && nv.tenNV == null)
            {
                kq = list;
            }
            if (nv.tenNV != null && nv.maNV == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenNV.IndexOf(nv.tenNV) >= 0)
                        kq.Add(new NhanVien(list[i]));
            }
            else if (nv.tenNV == null && nv.maNV != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maNV == nv.maNV)
                        kq.Add(new NhanVien(list[i]));
            }
            else
                kq = null;
            return kq;
        }
        public bool KTraGT(string s)
        {
            if (s.ToLower() == "nam" || s.ToLower() == "nữ")
                return true;
            else
                return false;
        }
        public bool KT_MaNhanVien(string manv)
        {
            bool kt = false;
            foreach (NhanVien nhanvien in nvDAL.GetData())
                if (nhanvien.maNV == manv)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public bool KT_TenNhanVien(string tennv)
        {
            bool kt = false;
            foreach (NhanVien nhanvien in nvDAL.GetData())
                if (nhanvien.tenNV == tennv || nhanvien.tenNV.IndexOf(tennv) >= 0)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
    }
}
