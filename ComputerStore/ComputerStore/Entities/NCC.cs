using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class NCC
    {
        #region Các thành phần dữ liệu
        private static int stt = 0;
        public int MaNCC;
        private string TenNCC;
        private string DiaChi;
        private string SoDT;
        #endregion
        #region Các phương thức khởi tạo
        public NCC()
        {
            stt++;
            MaNCC = stt;
            TenNCC = " ";
            DiaChi = " ";
            SoDT = " ";
        }
        public NCC(string tenncc, string diachi, string sdt)
        {
            stt++;
            MaNCC = stt;
            this.TenNCC = tenncc;
            this.DiaChi = diachi;
            this.SoDT = sdt;
        }
        //Phương thức sao chép
        public NCC(NCC n)
        {
            this.MaNCC = n.MaNCC;
            this.TenNCC = n.TenNCC;
            this.DiaChi = n.DiaChi;
            this.SoDT = n.SoDT;
        }
        #endregion
        #region Các thuộc tính
        public int maNCC
        {
            get
            {
                return MaNCC;
            }
            set
            {
                MaNCC = value;
            }
        }
        public string tenNCC
        {
            get
            {
                return TenNCC;
            }
            set
            {
                if (value != "")
                    TenNCC = value;
            }
        }
        public string diaChi
        {
            get
            {
                return DiaChi;
            }
            set
            {
                if (value != "")
                    DiaChi = value;
            }
        }
        public string soDT
        {
            get
            {
                return SoDT;
            }
            set
            {
                if (value != "")
                    SoDT = value;
            }
        }
        #endregion
    }
}
