using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class KhachHang
    {
        private int MaKH;
        private string TenKH;
        private string DiaChi;
        private string SoDT;

        public KhachHang()
        {
        }
        public KhachHang(int makh, string tenkh, string diachi, string sdt)
        {
            this.MaKH = makh;
            this.TenKH = tenkh;
            this.DiaChi = diachi;
            this.SoDT = sdt;
        }
        //Phương thức sao chép
        public KhachHang(KhachHang kh)
        {
            this.MaKH = kh.MaKH;
            this.TenKH = kh.TenKH;
            this.DiaChi = kh.DiaChi;
            this.SoDT = kh.SoDT;
        }

        public int maKH
        {
            get
            {
                return MaKH;
            }
            set
            {
                if (value > 0)
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
