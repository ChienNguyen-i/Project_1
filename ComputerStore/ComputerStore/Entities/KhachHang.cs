using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    class KhachHang
    {
        #region Các thành phần dữ liệu
        private static int stt = 0;
        public int MaKH;
        private string TenKH;
        private string GioiTinh;
        private string DiaChi;
        private string SoDT;
        #endregion
        #region Các phương thức khởi tạo
        public KhachHang()
        {
            stt++;
            MaKH = stt;
            TenKH = " ";
            GioiTinh = " ";
            DiaChi = " ";
            SoDT = " ";
        }
        public KhachHang(string tenkh, string gt, string diachi, string sdt)
        {
            this.TenKH = tenkh;
            this.GioiTinh = gt;
            this.DiaChi = diachi;
            this.SoDT = sdt;
        }
        //Phương thức sao chép
        public KhachHang(KhachHang kh)
        {
            this.MaKH = kh.MaKH;
            this.TenKH = kh.TenKH;
            this.GioiTinh = kh.GioiTinh;
            this.DiaChi = kh.DiaChi;
            this.SoDT = kh.SoDT;
        }
        #endregion
        #region Các thuộc tính
        public int maKH
        {
            get
            {
                return MaKH;
            }
            set
            {
                MaKH = value;
            }
        }
        public string tenKH
        {
            get
            {
                return TenKH;
            }
            set
            {
                if (value != "")
                    TenKH = value;
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
        #endregion
    }
}
