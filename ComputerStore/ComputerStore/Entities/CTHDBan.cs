using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class CTHDBan
    {
        #region Các thành phần dữ liệu
        private int MaCTHDB;
        private int MaHDB;
        private int MaMT;
        private int SoLuong;
        private double DonGia;
        private double ThanhTien;
        #endregion
        #region Các phương thức khởi tạo
        public CTHDBan()
        {
        }
        public CTHDBan(int macthdb, int mahdb, int mamt, int soluong, double dongia, double thanhtien)
        {
            this.MaCTHDB = macthdb;
            this.MaHDB = mahdb;
            this.MaMT = mamt;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.ThanhTien = thanhtien;
        }
        //Phương thức sao chép
        public CTHDBan(CTHDBan c)
        {
            this.MaCTHDB = c.MaCTHDB;
            this.MaHDB = c.MaHDB;
            this.MaMT = c.MaMT;
            this.SoLuong = c.SoLuong;
            this.DonGia = c.DonGia;
            this.ThanhTien = c.ThanhTien;
        }
        #endregion
        #region Các thuộc tính
        public int maCTHDB
        {
            get
            {
                return MaCTHDB;
            }
            set
            {
                if (value > 0)
                    MaCTHDB = value;
            }
        }
        public int maHDB
        {
            get
            {
                return MaHDB;
            }
            set
            {
                if (value > 0)
                    MaHDB = value;
            }
        }
        public int maMT
        {
            get
            {
                return MaMT;
            }
            set
            {
                if (value > 0)
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
