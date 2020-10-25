using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class MayTinh
    {
        #region Các thành phần dữ liệu
        private int MaMT;
        private int MaLM;
        private string TenMT;
        private int MaNCC;
        private int SLNhap;
        private int SLCon;
        #endregion
        #region Các phương thức khởi tạo
        public MayTinh()
        {
        }
        public MayTinh(int mamt, int malm, string tenmt, int mancc, int sln, int slc)
        {
            this.MaMT = mamt;
            this.MaLM = malm;
            this.TenMT = tenmt;
            this.MaNCC = mancc;
            this.SLNhap = sln;
            this.SLCon = slc;
        }
        //Phương thức sao chép
        public MayTinh(MayTinh mt)
        {
            this.MaMT = mt.MaMT;
            this.MaLM = mt.MaLM;
            this.TenMT = mt.TenMT;
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
                if (value > 0)
                    MaMT = value;
            }
        }
        public int maLM
        {
            get
            {
                return MaLM;
            }
            set
            {
                if (value > 0)
                    MaLM = value;
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
