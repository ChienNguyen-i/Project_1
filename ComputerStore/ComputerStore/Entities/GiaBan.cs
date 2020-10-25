using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class GiaBan
    {
        #region Các thành phần dữ liệu
        private int MaGB;
        private int MaMT;
        private double Giaban;
        private DateTime NgayAD;
        private DateTime NgayThoiAD;
        #endregion
        #region Các phương thức khởi tạo
        public GiaBan()
        {
        }
        public GiaBan(int magb, int mamt, double giaban, DateTime ngayad, DateTime ngaythoiad)
        {
            this.MaGB = magb;
            this.MaMT = mamt;
            this.Giaban = giaban;
            this.NgayAD = ngayad;
            this.NgayThoiAD = ngaythoiad;
        }
        //Phương thức sao chép
        public GiaBan(GiaBan gb)
        {
            this.MaGB = gb.MaGB;
            this.MaMT = gb.MaMT;
            this.Giaban = gb.Giaban;
            this.NgayAD = gb.NgayAD;
            this.NgayThoiAD = gb.NgayThoiAD;
        }
        #endregion
        #region Các thuộc tính
        public int maGB
        {
            get
            {
                return MaGB;
            }
            set
            {
                if (value > 0)
                    MaGB = value;
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
        public double giaBan
        {
            get
            {
                return Giaban;
            }
            set
            {
                if (value > 0)
                    Giaban = value;
            }
        }
        public DateTime ngayAD
        {
            get
            {
                return NgayAD;
            }
            set
            {
                NgayAD = value;
            }
        }
        public DateTime ngayThoiAD
        {
            get
            {
                return NgayThoiAD;
            }
            set
            {
                NgayThoiAD = value;
            }
        }
        #endregion
    }
}
