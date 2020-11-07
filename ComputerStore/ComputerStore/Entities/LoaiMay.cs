using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class LoaiMay
    {
        private int MaLM;
        private string TenLM;
        private string DacDiem;

        public LoaiMay()
        {
        }
        public LoaiMay(int malm, string tenlm, string dacdiem)
        {
            this.MaLM = malm;
            this.TenLM = tenlm;
            this.DacDiem = dacdiem;
        }
        //Phương thức sao chép
        public LoaiMay(LoaiMay lm)
        {
            this.MaLM = lm.MaLM;
            this.TenLM = lm.TenLM;
            this.DacDiem = lm.DacDiem;
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
        public string dacDiem
        {
            get
            {
                return DacDiem;
            }
            set
            {
                if (value != "")
                    DacDiem = value;
            }
        }
    }
}
