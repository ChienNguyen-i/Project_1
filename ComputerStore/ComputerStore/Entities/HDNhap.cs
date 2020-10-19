using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class HDNhap
    {
        #region Các thành phần dữ liệu
        private static int stt = 0;
        public int MaHDN;
        private string MaNV;
        private string MaNCC;
        private DateTime NgayNhap;
        private double TongTien;
        #endregion
        #region Các phương thức khởi tạo
        public HDNhap()
        {
            stt++;
            MaHDN = stt;
            MaNV = " ";
            MaNCC = " ";
            NgayNhap = DateTime.Now;
            TongTien = 0;
        }
        public HDNhap(string manv, string mancc, DateTime ngaynhap, double tongtien)
        {
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
