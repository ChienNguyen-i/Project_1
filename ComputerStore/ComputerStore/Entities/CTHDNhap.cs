using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class CTHDNhap
    {
        #region Các thành phần dữ liệu
        private static int stt = 0;
        public int MaCTHDN;
        private string MaHDN;
        private string MaMT;
        private int SoLuong;
        private double DonGia;
        private double ThanhTien;
        #endregion
        #region Các phương thức khởi tạo
        public CTHDNhap()
        {
            stt++;
            MaCTHDN = stt;
            MaHDN = " ";
            MaMT = " ";
            SoLuong = 0;
            DonGia = 0;
            ThanhTien = 0;
        }
        public CTHDNhap(string mahdn, string mamt, int soluong, double dongia, double thanhtien)
        {
            this.MaHDN = mahdn;
            this.MaMT = mamt;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.ThanhTien = thanhtien;
        }
        //Phương thức sao chép
        public CTHDNhap(CTHDNhap c)
        {
            this.MaCTHDN = c.MaCTHDN;
            this.MaHDN = c.MaHDN;
            this.MaMT = c.MaMT;
            this.SoLuong = c.SoLuong;
            this.DonGia = c.DonGia;
            this.ThanhTien = c.ThanhTien;
        }
        #endregion
        #region Các thuộc tính
        public int maCTHDN
        {
            get
            {
                return MaCTHDN;
            }
            set
            {
                MaCTHDN = value;
            }
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
        public string maMT
        {
            get
            {
                return MaMT;
            }
            set
            {
                if (value != "")
                    MaMT = value;
            }
        }
        public int soLuong
        {
            get
            {
                return SoLuong;
            }
            set
            {
                if (value >= 0)
                    SoLuong = value;
            }
        }
        public double donGia
        {
            get
            {
                return DonGia;
            }
            set
            {
                if (value > 0)
                    DonGia = value;
            }
        }
        public double thanhTien
        {
            get
            {
                return ThanhTien;
            }
            set
            {
                if (value > 0)
                    ThanhTien = value;
            }
        }
        #endregion
    }
}
