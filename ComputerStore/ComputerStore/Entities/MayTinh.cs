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
        private int SLCon;
        private double GiaBan;

        public MayTinh()
        {
        }
        public MayTinh(string mamt, string tenmt, string mancc, int slc, double giaban)
        {
            this.MaMT = mamt;
            this.TenMT = tenmt;
            this.MaNCC = mancc;
            this.SLCon = slc;
            this.GiaBan = giaban;
        }
        public MayTinh(MayTinh mt)
        {
            this.MaMT = mt.MaMT;
            this.TenMT = mt.TenMT;
            this.MaNCC = mt.MaNCC;
            this.SLCon = mt.SLCon;
            this.GiaBan = mt.GiaBan;
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
        public double giaBan
        {
            get
            {
                return GiaBan;
            }
            set
            {
                if (value > 0)
                    GiaBan = value;
            }
        }
    }
}
