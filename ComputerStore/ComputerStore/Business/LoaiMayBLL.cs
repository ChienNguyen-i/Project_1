using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;
using ComputerStore.DataAccessLayer;
using ComputerStore.DataAccessLayer.Interface;
using ComputerStore.Business.Interface;

namespace ComputerStore.Business
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại ILoaiMayBLL
    public class LoaiMayBLL : ILoaiMayBLL
    {
        private ILoaiMayDAL lmDAL = new LoaiMayDAL();
        public List<LoaiMay> LayDSLoaiMay()
        {
            return lmDAL.GetData();
        }
        public void ThemLoaiMay(LoaiMay lm)
        {
            if (lm.tenLM != "" && lm.dacDiem != "")
            {
                lm.tenLM = CongCu.HoaDau(lm.tenLM);
                lm.dacDiem = CongCu.HoaDau(lm.dacDiem);
                lmDAL.Insert(lm);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public LoaiMay LayLoaiMay(int malm)
        {
            int i;
            List<LoaiMay> list = lmDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maLM == malm)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaLoaiMay(int malm)
        {
            int i;
            List<LoaiMay> list = lmDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maLM == malm)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                lmDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaLoaiMay(LoaiMay lm)
        {
            int i;
            List<LoaiMay> list = lmDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maLM == lm.maLM)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(lm, i);
                lmDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại loại máy này.");
        }
        public List<LoaiMay> TimLoaiMay(LoaiMay lm)
        {
            List<LoaiMay> list = lmDAL.GetData();
            List<LoaiMay> kq = new List<LoaiMay>();
            if (lm.maLM == 0 && lm.tenLM == null)
            {
                kq = list;
            }
            //Tìm theo tên
            if (lm.tenLM != null && lm.maLM == 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenLM.IndexOf(lm.tenLM) >= 0)
                        kq.Add(new LoaiMay(list[i]));
            }
            //Tìm theo mã
            else if (lm.tenLM == null && lm.maLM > 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maLM == lm.maLM)
                        kq.Add(new LoaiMay(list[i]));
            }
            else
                kq = null;
            return kq;
        }
    }
}
