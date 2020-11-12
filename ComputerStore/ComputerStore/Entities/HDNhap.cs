﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class HDNhap
    {
        private string MaHDN;
        private string MaNV;
        private string MaNCC;
        private string MaMT;
        private string NgayNhap;
        private int SoLuong;
        private double DonGia;
        private double TongTien;

        public HDNhap()
        {
        }
        public HDNhap(string mahdn, string manv, string mancc, string mamt, string ngaynhap, int soluong, double dongia, double tongtien)
        {
            this.MaHDN = mahdn;
            this.MaNV = manv;
            this.MaNCC = mancc;
            this.MaMT = mamt;
            this.NgayNhap = ngaynhap;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.TongTien = tongtien;
        }
        //Phương thức sao chép
        public HDNhap(HDNhap hdn)
        {
            this.MaHDN = hdn.MaHDN;
            this.MaNV = hdn.MaNV;
            this.MaNCC = hdn.MaNCC;
            this.MaMT = hdn.MaMT;
            this.NgayNhap = hdn.NgayNhap;
            this.SoLuong = hdn.SoLuong;
            this.DonGia = hdn.DonGia;
            this.TongTien = hdn.TongTien;
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
        public double tongTien
        {
            get
            {
                return donGia * soLuong;
            }
            set
            {
                TongTien = value;
            }
        }
    }
}
