using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class KhachHang
    {
        private string MaKH;
        private string TenKH;
        private string DiaChi;
        private string SoDT;

        public KhachHang()
        {
        }
        public KhachHang(string makh, string tenkh, string diachi, string sdt)
        {
            this.MaKH = makh;
            this.TenKH = tenkh;
            this.DiaChi = diachi;
            this.SoDT = sdt;
        }
        public KhachHang(KhachHang kh)
        {
            this.MaKH = kh.maKH;
            this.TenKH = kh.tenKH;
            this.DiaChi = kh.diaChi;
            this.SoDT = kh.soDT;
        }

        public string maKH
        {
            get
            {
                return MaKH;
            }
            set
            {
                if (value != "")
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
    }
}
