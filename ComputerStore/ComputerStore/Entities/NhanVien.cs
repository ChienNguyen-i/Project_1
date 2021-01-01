using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class NhanVien
    {
        private string MaNV;
        private string TenNV;
        private string NgaySinh;
        private string GioiTinh;
        private string DiaChi;
        private string SoDT;
        private string LoaiNV;
        private string Password;

        public NhanVien()
        {
        }
        public NhanVien(string manv, string tennv, string ngaysinh, string gt, string diachi, string sdt, string loainv, string pass)
        {
            this.MaNV = manv;
            this.TenNV = tennv;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gt;
            this.DiaChi = diachi;
            this.SoDT = sdt;
            this.LoaiNV = loainv;
            this.Password = pass;
        }
        public NhanVien(NhanVien nv)
        {
            this.MaNV = nv.maNV;
            this.TenNV = nv.tenNV;
            this.NgaySinh = nv.ngaySinh;
            this.GioiTinh = nv.gioiTinh;
            this.DiaChi = nv.diaChi;
            this.SoDT = nv.soDT;
            this.LoaiNV = nv.LoaiNV;
            this.Password = nv.loaiNV;
        }

        public string maNV
        {
            get
            {
                return MaNV;
            }
            set
            {
                if (value != "")
                    MaNV = value;
            }
        }
        public string tenNV
        {
            get
            {
                return TenNV;
            }
            set
            {
                if (value != "")
                    TenNV = value;
            }
        }
        public string ngaySinh
        {
            get
            {
                return NgaySinh;
            }
            set
            {
                if (value != "")
                    NgaySinh = value;
            }
        }
        public string gioiTinh
        {
            get
            {
                return GioiTinh;
            }
            set
            {
                if (value != "")
                    GioiTinh = value;
            }
        }
        public string diaChi
        {
            get
            {
                return DiaChi;
            }
            set
            {
                if (value != "")
                    DiaChi = value;
            }
        }
        public string soDT
        {
            get
            {
                return SoDT;
            }
            set
            {
                if (value != "")
                    SoDT = value;
            }
        }
        public string loaiNV
        {
            get
            {
                return LoaiNV;
            }
            set
            {
                if (value != "")
                    LoaiNV = value;
            }
        }
        public string pass
        {
            get
            {
                return Password;
            }
            set
            {
                if (value != "")
                    Password = value;
            }
        }
    }
}
