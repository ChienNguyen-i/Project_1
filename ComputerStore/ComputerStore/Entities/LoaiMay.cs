using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Entities
{
    public class LoaiMay
    {
        #region Các thành phần dữ liệu
        private static int stt = 0;
        public int MaLM;
        private string TenLM;
        private string DacDiem;
        #endregion
        #region Các phương thức khởi tạo
        public LoaiMay()
        {
            stt++;
            MaLM = stt;
            TenLM = " ";
            DacDiem = " ";
        }
        public LoaiMay(string tenlm, string dacdiem)
        {
            stt++;
            MaLM = stt;
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
        #endregion
        #region Các thuộc tính
        public int maLM
        {
            get
            {
                return MaLM;
            }
            set
            {
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
        #endregion
    }
}
