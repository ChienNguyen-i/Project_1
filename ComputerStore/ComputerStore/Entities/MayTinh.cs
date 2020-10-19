﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class MayTinh
    {
        #region Các thành phần dữ liệu
        private static int stt = 0;
        public int MaMT;
        private string MaLM;
        private string TenLM;
        private string MaNCC;
        private int SLNhap;
        private int SLCon;
        #endregion
        #region Các phương thức khởi tạo
        public MayTinh()
        {
            stt++;
            MaMT = stt;
            MaLM = " ";
            TenLM = " ";
            MaNCC = " ";
            SLNhap = 0;
            SLCon = 0;
        }
        public MayTinh(string malm, string tenlm, string mancc, int sln, int slc)
        {
            stt++;
            MaMT = stt;
            this.MaLM = malm;
            this.TenLM = tenlm;
            this.MaNCC = mancc;
            this.SLNhap = sln;
            this.SLCon = slc;
        }
        //Phương thức sao chép
        public MayTinh(MayTinh mt)
        {
            this.MaMT = mt.MaMT;
            this.MaLM = mt.MaLM;
            this.TenLM = mt.TenLM;
            this.MaNCC = mt.MaNCC;
            this.SLNhap = mt.SLNhap;
            this.SLCon = mt.SLCon;
        }
        #endregion
        #region Các thuộc tính
        public int maMT
        {
            get
            {
                return MaMT;
            }
            set
            {
                MaMT = value;
            }
        }
        public string maLM
        {
            get
            {
                return MaLM;
            }
            set
            {
                if (value != "")
                    MaLM = value;
            }
        }
        public string tenLM
        {
            get
            {
                return TenLM;
            }
            set
            {
                if (value != "")
                    TenLM = value;
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
        public int sLNhap
        {
            get
            {
                return SLNhap;
            }
            set
            {
                if (value >= 0)
                    SLNhap = value;
            }
        }
        public int sLCon
        {
            get
            {
                return SLCon;
            }
            set
            {
                if (value > 0)
                    SLCon = value;
            }
        }
        #endregion
    }
}
