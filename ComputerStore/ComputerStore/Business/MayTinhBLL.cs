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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IMayTinhBLL
    public class MayTinhBLL : IMayTinhBLL
    {
        private IMayTinhDAL mtDAL = new MayTinhDAL();
        public List<MayTinh> LayDSMayTinh()
        {
            return mtDAL.GetData();
        }
        public void ThemMayTinh(MayTinh mt)
        {
            if (mt.tenMT != "")
            {
                mt.tenMT = CongCu.HoaDau(mt.tenMT);
                mtDAL.Insert(mt);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public MayTinh LayMayTinh(int mamt)
        {
            int i;
            List<MayTinh> list = mtDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maMT == mamt)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaMayTinh(int mamt)
        {
            int i;
            List<MayTinh> list = mtDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maMT == mamt)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                mtDAL.Update(list);
            }
            else
                IO.Writexy("Không tồn tại mã máy tính này....", 5, 6, ConsoleColor.Black, ConsoleColor.White);
        }
        public void SuaMayTinh(MayTinh mt)
        {
            int i;
            List<MayTinh> list = mtDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maMT == mt.maMT)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(mt, i);
                mtDAL.Update(list);
            }
            else
                IO.Writexy("Không tồn tại máy tính này...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
        }
        public List<MayTinh> TimMayTinh(MayTinh mt)
        {
            List<MayTinh> list = mtDAL.GetData();
            List<MayTinh> kq = new List<MayTinh>();
            if (mt.maMT == 0 && mt.tenMT == null)
            {
                kq = list;
            }
            //Tìm theo tên
            if (mt.tenMT != null && mt.maMT == 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenMT.IndexOf(mt.tenMT) >= 0)
                        kq.Add(new MayTinh(list[i]));
            }
            //Tìm theo mã
            else if (mt.tenMT == null && mt.maMT > 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maMT == mt.maMT)
                        kq.Add(new MayTinh(list[i]));
            }
            else
                kq = null;
            return kq;
        }
    }
}
