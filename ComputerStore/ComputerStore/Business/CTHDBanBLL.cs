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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại ICTHDBanBLL
    public class CTHDBanBLL : ICTHDBanBLL
    {
        private ICTHDBanDAL cthdbDAL = new CTHDBanDAL();
        public List<CTHDBan> LayDSCTHDBan()
        {
            return cthdbDAL.GetData();
        }
        public void ThemCTHDBan(CTHDBan cthdb)
        {

        }
        public CTHDBan LayCTHDBan(int macthdb)
        {
            int i;
            List<CTHDBan> list = cthdbDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maCTHDB == macthdb)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaCTHDBan(int macthdb)
        {
            int i;
            List<CTHDBan> list = cthdbDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maCTHDB == macthdb)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                cthdbDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaCTHDBan(CTHDBan cthdb)
        {
            int i;
            List<CTHDBan> list = cthdbDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maCTHDB == cthdb.maCTHDB)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(cthdb, i);
                cthdbDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại chi tiết hóa đơn bán này.");
        }
        public List<CTHDBan> TimCTHDBan(CTHDBan cthdb)
        {
            List<CTHDBan> list = cthdbDAL.GetData();
            List<CTHDBan> kq = new List<CTHDBan>();
            if (cthdb.maCTHDB == 0)
            {
                kq = list;
            }
            //Tìm theo mã
            if (cthdb.maCTHDB != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maCTHDB == cthdb.maCTHDB)
                        kq.Add(new CTHDBan(list[i]));
            }
            else
                kq = null;
            return kq;
        }
    }
}
