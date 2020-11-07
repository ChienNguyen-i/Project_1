using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class NCC
    {
        private int MaNCC;
        private string TenNCC;
        private string DiaChi;
        private string SoDT;

        public NCC()
        {
        }
        public NCC(int mancc, string tenncc, string diachi, string sdt)
        {
            this.MaNCC = mancc;
            this.TenNCC = tenncc;
            this.DiaChi = diachi;
            this.SoDT = sdt;
        }
        //Phương thức sao chép
        public NCC(NCC ncc)
        {
            this.MaNCC = ncc.MaNCC;
            this.TenNCC = ncc.TenNCC;
            this.DiaChi = ncc.DiaChi;
            this.SoDT = ncc.SoDT;
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
    }
}
