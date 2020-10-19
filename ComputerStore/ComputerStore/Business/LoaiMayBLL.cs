using ComputerStore.Business.Interface;
using ComputerStore.DataAccessLayer;
using ComputerStore.Entities;
using System;
using System.Text;
using ComputerStore.Utility;

namespace ComputerStore.Business
{
    /*public class LoaiMayBLL : ILoaiMayBLL
    {
        private ILoaiMayBLL lmDAL = new LoaiMayDAL();
        public List<LoaiMay> LayDSLoaiMay()
        {
            return lmDAL.GetData();
        }
        public void ThemLoaiMay(LoaiMay lm)
        {
            if (lm.tenLM != "" && lm.dacDiem != "")
            {
                lm.tenLM = ComputerStore.Utility.CongCu.ChuanHoaXau(lm.tenLM);
                lm.dacDiem = ComputerStore.Utility.CongCu.ChuanHoaXau(lm.dacDiem);
            }
            else
                throw new Exception("Dữ liệu sai");
        }
    }*/
}
