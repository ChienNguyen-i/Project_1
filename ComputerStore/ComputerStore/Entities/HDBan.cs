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
        private DateTime NgayBan;
        private double TongTien;
        #endregion
        #region Các phương thức khởi tạo
        public HDBan()
        {
        }
        public HDBan(int mahdb, int manv, int makh, DateTime ngayban, double tongtien)
        {
            this.MaHDB = mahdb;
            this.MaNV = manv;
            this.MaKH = makh;
            this.NgayBan = ngayban;
            this.TongTien = tongtien;
        }
        //Phương thức sao chép
        public HDBan(HDBan hdb)
        {
            this.MaHDB = hdb.MaHDB;
            this.MaNV = hdb.MaNV;
            this.MaKH = hdb.MaKH;
            this.NgayBan = hdb.NgayBan;
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
