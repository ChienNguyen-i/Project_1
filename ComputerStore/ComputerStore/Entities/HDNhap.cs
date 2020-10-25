using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class HDNhap
    {
        #region Các thành phần dữ liệu
        private int MaHDN;
        private int MaNV;
        private int MaNCC;
        private DateTime NgayNhap;
        private double TongTien;
        #endregion
        #region Các phương thức khởi tạo
        public HDNhap()
        {
        }
        public HDNhap(int mahdn, int manv, int mancc, DateTime ngaynhap, double tongtien)
        {
            this.MaHDN = mahdn;
            this.MaNV = manv;
            this.MaNCC = mancc;
            this.NgayNhap = ngaynhap;
            this.TongTien = tongtien;
        }
        //Phương thức sao chép
        public HDNhap(HDNhap hdn)
        {
            this.MaHDN = hdn.MaHDN;
            this.MaNV = hdn.MaNV;
            this.MaNCC = hdn.MaNCC;
            this.NgayNhap = hdn.NgayNhap;
            this.TongTien = hdn.TongTien;
        }
        #endregion
        #region Các thuộc tính
        public int maHDN
        { 
            get
            {
                return MaHDN;
            }
            set
            {
                if (value > 0)
                    MaHDN = value;
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
        public int maNCC
        {
            get
            {
                return MaNCC;
            }
            set
            {
                if (value > 0)
                    MaNCC = value;
            }
        }
        public DateTime ngayNhap
        {
            get
            {
                return NgayNhap;
            }
            set
            {
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
        #endregion
    }
}
