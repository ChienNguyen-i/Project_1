using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class HDNhap
    {
        private string MaHDN;
        private string MaNV;
        private string MaNCC;
        private string NgayNhap;
        private double TongTien;

        public HDNhap()
        {
        }
        public HDNhap(string mahdn, string manv, string mancc, string ngaynhap, double tongtien)
        {
            this.MaHDN = mahdn;
            this.MaNV = manv;
            this.MaNCC = mancc;
            this.NgayNhap = ngaynhap;
            this.TongTien = tongtien;
        }
        public HDNhap(HDNhap hdn)
        {
            this.MaHDN = hdn.maHDN;
            this.MaNV = hdn.maNV;
            this.MaNCC = hdn.maNCC;
            this.NgayNhap = hdn.ngayNhap;
            this.TongTien = hdn.tongTien;
        }

        public string maHDN
        {
            get
            {
                return MaHDN;
            }
            set
            {
                if (value != "")
                    MaHDN = value;
            }
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
        public string maNCC
        {
            get
            {
                return MaNCC;
            }
            set
            {
                if (value != "")
                    MaNCC = value;
            }
        }
        public string ngayNhap
        {
            get
            {
                return NgayNhap;
            }
            set
            {
                if (value != "")
                    NgayNhap = value;
            }
        }
        public double tongTien
        {
            get
            {
                return TongTien;
            }
            set
            {
                if (value > 0)
                    TongTien = value;
            }
        }
    }
}
