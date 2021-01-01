using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class HDBan
    {
        private string MaHDB;
        private string MaNV;
        private string MaKH;
        private string NgayBan;
        private double TongTien;

        public HDBan()
        {
        }
        public HDBan(string mahdb, string manv, string makh, string ngayban, double tongtien)
        {
            this.MaHDB = mahdb;
            this.MaNV = manv;
            this.MaKH = makh;
            this.NgayBan = ngayban;
            this.TongTien = tongtien;
        }
        public HDBan(HDBan hdb)
        {
            this.MaHDB = hdb.maHDB;
            this.MaNV = hdb.maNV;
            this.MaKH = hdb.maKH;
            this.NgayBan = hdb.ngayBan;
            this.TongTien = hdb.tongTien;
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
        public string ngayBan
        {
            get
            {
                return NgayBan;
            }
            set
            {
                if (value != "")
                    NgayBan = value;
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
