using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class CTHDBan
    {
        private string MaHDB;
        private string MaMT;
        private int SoLuong;
        private double DonGia;
        private double ThanhTien;

        public CTHDBan()
        {
        }
        public CTHDBan(string mahdb, string mamt, int soluong, double dongia, double thanhtien)
        {
            this.MaHDB = mahdb;
            this.MaMT = mamt;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.ThanhTien = thanhtien;
        }
        public CTHDBan(CTHDBan cthdb)
        {
            this.MaHDB = cthdb.maHDB;
            this.MaMT = cthdb.maMT;
            this.SoLuong = cthdb.soLuong;
            this.DonGia = cthdb.donGia;
            this.ThanhTien = cthdb.thanhTien;
        }

        public string maHDB
        {
            get
            {
                return MaHDB;
            }
            set
            {
                if (value != "")
                    MaHDB = value;
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
                if (value > 0)
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
                return soLuong * donGia;
            }
            set
            {
                ThanhTien = value;
            }
        }
    }
}
