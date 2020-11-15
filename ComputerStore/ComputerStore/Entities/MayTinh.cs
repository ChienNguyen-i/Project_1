using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ComputerStore.Entities
{
    public class MayTinh
    {
        private string MaMT;
        private string TenMT;
        private string MaNCC;
        private int SLNhap;
        private int SLCon;

        public MayTinh()
        {
        }
        public MayTinh(string mamt, string tenmt, string mancc, int sln, int slc)
        {
            this.MaMT = mamt;
            this.TenMT = tenmt;
            this.MaNCC = mancc;
            this.SLNhap = sln;
            this.SLCon = slc;
        }
        public MayTinh(MayTinh mt)
        {
            this.MaMT = mt.MaMT;
            this.TenMT = mt.TenMT;
            this.MaNCC = mt.MaNCC;
            this.SLNhap = mt.SLNhap;
            this.SLCon = mt.SLCon;
        }

        public string maMT
        {
            get
            {
                return MaMT;
            }
            set
            {
                if (value != "")
                    MaMT = value;
            }
        }
        public string tenMT
        {
            get
            {
                return TenMT;
            }
            set
            {
                if (value != "")
                    TenMT = value;
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
                if (value > 0)
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
                if (value >= 0)
                    SLCon = value;
            }
        }
    }
}
