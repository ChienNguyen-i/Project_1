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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IHDBanBLL
    public class HDBanBLL : IHDBanBLL
    {
        private IHDBanDAL hdbDAL = new HDBanDAL();
        public List<HDBan> LayDSHDBan()
        {
            return hdbDAL.GetData();
        }
        public void ThemHDBan(HDBan hdb)
        {
            hdbDAL.Insert(hdb);
        }
        public HDBan LayHDBan(int mahdb)
        {
            int i;
            List<HDBan> list = hdbDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maHDB == mahdb)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaHDBan(int mahdb)
        {
            int i;
            List<HDBan> list = hdbDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maHDB == mahdb)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                hdbDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaHDBan(HDBan hdb)
        {
            int i;
            List<HDBan> list = hdbDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maHDB == hdb.maHDB)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(hdb, i);
                hdbDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại hóa đơn bán này.");
        }
        public List<HDBan> TimHDBan(HDBan hdb)
        {
            List<HDBan> list = hdbDAL.GetData();
            List<HDBan> kq = new List<HDBan>();
            if (hdb.maHDB == 0)
            {
                kq = list;
            }
            //Tìm theo mã
            if (hdb.maHDB != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maHDB == hdb.maHDB)
                        kq.Add(new HDBan(list[i]));
            }
            else
                kq = null;
            return kq;
        }
    }
}
