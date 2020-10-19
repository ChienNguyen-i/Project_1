using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class NhanVien
    {
        #region Các thành phần dữ liệu
        private static int stt = 0;
        public int MaNV;
        private string TenNV;
        private string GioiTinh;
        private string DiaChi;
        private string SoDT;
        private string LoaiNV;
        #endregion
        #region Các phương thức khởi tạo
        public NhanVien()
        {
            stt++;
            MaNV = stt;
            TenNV = " ";
            GioiTinh = " ";
            DiaChi = " ";
            SoDT = " ";
            LoaiNV = " ";
        }
        public NhanVien(string tennv, string gt, string diachi, string sdt, string loainv)
        {
            stt++;
            MaNV = stt;
            this.TenNV = tennv;
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
            this.GioiTinh = nv.GioiTinh;
            this.DiaChi = nv.DiaChi;
            this.SoDT = nv.SoDT;
            this.LoaiNV = nv.LoaiNV;
        }
        #endregion
        #region Các thuộc tính
        public int maNV
        {
            get
            {
                return MaNV;
            }
            set
            {
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
        public string gioiTinh
        {
            get
            {
                return GioiTinh;
            }
            set
            {
                if (value.ToLower() == "nam" || value.ToLower() == "nữ")
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
        #endregion
    }
}
