﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class NCC
    {
        private string MaNCC;
        private string TenNCC;
        private string DiaChi;
        private string SoDT;

        public NCC()
        {
        }
        public NCC(string mancc, string tenncc, string diachi, string sdt)
        {
            this.MaNCC = mancc;
            this.TenNCC = tenncc;
            this.DiaChi = diachi;
            this.SoDT = sdt;
        }
        public NCC(NCC ncc)
        {
            this.MaNCC = ncc.maNCC;
            this.TenNCC = ncc.tenNCC;
            this.DiaChi = ncc.diaChi;
            this.SoDT = ncc.soDT;
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
