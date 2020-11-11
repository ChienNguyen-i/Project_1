using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class NhanVien
    {
        private int MaNV;
        private string TenNV;
        private string NgaySinh;
        private string GioiTinh;
        private string DiaChi;
        private string SoDT;
        private string LoaiNV;

        public NhanVien()
        {
        }
        public NhanVien(int manv, string tennv, string ngaysinh, string gt, string diachi, string sdt, string loainv)
        {
            this.MaNV = manv;
            this.TenNV = tennv;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gt;
            this.DiaChi = diachi;
            this.SoDT = sdt;
            this.LoaiNV = loainv;
        }
        //Phương thức sao chép
        public NhanVien(NhanVien nv)
        {
            this.MaNV = nv.MaNV;
            this.TenNV = nv.TenNV;
            this.NgaySinh = nv.NgaySinh;
            this.GioiTinh = nv.GioiTinh;
            this.DiaChi = nv.DiaChi;
            this.SoDT = nv.SoDT;
            this.LoaiNV = nv.LoaiNV;
        }

        public int maNV
        {
            get
            {
                return MaNV;
            }
            set
            {
                if (value > 0)
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
    }
}
