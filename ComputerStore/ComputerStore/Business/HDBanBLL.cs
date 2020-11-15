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
            if (hdb.maNV != "" && hdb.maKH != "" && hdb.maMT != "" && hdb.ngayBan != "")
            {
                hdb.maNV = CongCu.CatXau(hdb.maNV.ToUpper());
                hdb.maKH = CongCu.CatXau(hdb.maKH.ToUpper());
                hdb.maMT = CongCu.CatXau(hdb.maMT.ToUpper());
                hdb.ngayBan = CongCu.CatXau(hdb.ngayBan);
                hdbDAL.Insert(hdb);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public HDBan LayHDBan(string mahdb)
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
        public void XoaHDBan(string mahdb)
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
                throw new Exception("Không tồn tại mã này.");
        }
        public List<HDBan> TimHDBan(HDBan hdb)
        {
            List<HDBan> list = hdbDAL.GetData();
            List<HDBan> kq = new List<HDBan>();
            if (hdb.maHDB == null)
            {
                kq = list;
            }
            if (hdb.maHDB != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maHDB == hdb.maHDB)
                        kq.Add(new HDBan(list[i]));
            }
            else
                kq = null;
            return kq;
        }
        public bool KT_MaHDB(string mahdb)
        {
            List<HDBan> list = hdbDAL.GetData();
            Node<HDBan> tmp = list.Head;
            bool kt = false;
            while (tmp != null)
            {
                if (tmp.Info.maHDB == mahdb)
                {
                    kt = true;
                    break;
                }
                else
                    tmp = tmp.Link;
            }
            return kt;
        }
    }
}
