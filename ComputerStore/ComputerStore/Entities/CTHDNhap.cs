﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class CTHDNhap
    {
        private string MaHDN;
        private string MaMT;
        private int SoLuong;
        private double DonGia;
        private double ThanhTien;

        public CTHDNhap()
        {
        }
        public CTHDNhap(string mahdn, string mamt, int soluong, double dongia, double thanhtien)
        {
            this.MaHDN = mahdn;
            this.MaMT = mamt;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.ThanhTien = thanhtien;
        }
        public CTHDNhap(CTHDNhap cthdn)
        {
            this.MaHDN = cthdn.maHDN;
            this.MaMT = cthdn.maMT;
            this.SoLuong = cthdn.soLuong;
            this.DonGia = cthdn.donGia;
            this.ThanhTien = cthdn.thanhTien;
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
                return donGia * soLuong;
            }
            set
            {
                ThanhTien = value;
            }
        }
    }
}
