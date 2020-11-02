using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class HDBan
    {
        #region Các thành phần dữ liệu
        private int MaHDB;
        private int MaNV;
        private int MaKH;
        private int MaMT;
        private DateTime NgayBan;
        private int SoLuong;
        private double DonGia;
        private double TongTien;
        #endregion
        #region Các phương thức khởi tạo
        public HDBan()
        {
        }
        public HDBan(int mahdb, int manv, int makh, int mamt, DateTime ngayban, int soluong, double dongia, double tongtien)
        {
            this.MaHDB = mahdb;
            this.MaNV = manv;
            this.MaKH = makh;
            this.MaMT = mamt;
            this.NgayBan = ngayban;
            this.SoLuong = soluong;
            this.DonGia = dongia;
            this.TongTien = tongtien;
        }
        //Phương thức sao chép
        public HDBan(HDBan hdb)
        {
            this.MaHDB = hdb.MaHDB;
            this.MaNV = hdb.MaNV;
            this.MaKH = hdb.MaKH;
            this.MaMT = hdb.MaMT;
            this.NgayBan = hdb.NgayBan;
            this.SoLuong = hdb.SoLuong;
            this.DonGia = hdb.DonGia;
            this.TongTien = hdb.TongTien;
        }
        #endregion
        #region Các thuộc tính
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
        public int maNV
        {
            get
            {
                return MaNV;
            }
            set
            {
                if (value > 0)
                    MaNV = value;
            }
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
        public DateTime ngayBan
        {
            get
            {
                return NgayBan;
            }
            set
            {
                NgayBan = value;
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
        #endregion
    }
}
