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
            if (nv.tenNV != "" && nv.ngaySinh != "" && nv.gioiTinh != "" && nv.diaChi != "" && nv.soDT != "" && nv.loaiNV != "")
            {
                nv.tenNV = CongCu.ChuanHoaXau(nv.tenNV);
                nv.ngaySinh = CongCu.CatXau(nv.ngaySinh);
                nv.gioiTinh = CongCu.ChuanHoaXau(nv.gioiTinh);
                nv.diaChi = CongCu.ChuanHoaXau(nv.diaChi);
                nv.soDT = CongCu.CatXau(nv.soDT);
                nv.loaiNV = CongCu.HoaDau_1(nv.loaiNV);
                nvDAL.Insert(nv);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public NhanVien LayNhanVien(int manv)
        {
            int i;
            List<NhanVien> list = nvDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maNV == manv)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaNhanVien(int manv)
        {
            int i;
            List<NhanVien> list = nvDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maNV == manv)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                nvDAL.Update(list);
            }
            else
                IO.Writexy("Không tồn tại mã nhân viên này....", 5, 6, ConsoleColor.Black, ConsoleColor.White);
        }
        public void SuaNhanVien(NhanVien nv)
        {
            int i;
            List<NhanVien> list = nvDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maNV == nv.maNV)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(nv, i);
                nvDAL.Update(list);
            }
            else
                IO.Writexy("Không tồn tại nhân viên này...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
        }
        public List<NhanVien> TimNhanVien(NhanVien nv)
        {
            List<NhanVien> list = nvDAL.GetData();
            List<NhanVien> kq = new List<NhanVien>();
            if (nv.maNV == 0 && nv.tenNV == null)
            {
                kq = list;
            }
            //Tìm theo tên
            if (nv.tenNV != null && nv.maNV == 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenNV.IndexOf(nv.tenNV) >= 0)
                        kq.Add(new NhanVien(list[i]));
            }
            //Tìm theo mã
            else if (nv.tenNV == null && nv.maNV > 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maNV == nv.maNV)
                         kq.Add(new NhanVien(list[i]));
            }
            else
                kq = null;
            return kq;
        }
    }
}
