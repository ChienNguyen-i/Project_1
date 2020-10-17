using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    class NCC
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
        public NCC(string tenNCC, string diaChi, string sdt)
        {
            stt++;
            MaNCC = stt;
            this.TenNCC = tenNCC;
            this.DiaChi = diaChi;
            this.SoDT = sdt;
        }
        public NCC(NCC ncc)
        {
            this.MaNCC = ncc.MaNCC;
            this.TenNCC = ncc.TenNCC;
            this.DiaChi = ncc.DiaChi;
            this.SoDT = ncc.SoDT;
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
        public string sdt
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
