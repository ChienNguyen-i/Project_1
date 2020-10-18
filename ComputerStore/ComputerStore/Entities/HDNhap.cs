using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    class HDNhap
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
        public HDNhap(string maNV, string mancc, string ngaynhap, string tongtien)
        {

        }
        #endregion
    }
}
