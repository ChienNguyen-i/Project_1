using System;
using System.Collections.Generic;
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
            if (hdb.maNV != "" && hdb.maKH != "" && hdb.ngayBan != "")
            {
                hdb.maNV = CongCu.ChuanHoaMa(hdb.maNV);
                hdb.maKH = CongCu.ChuanHoaMa(hdb.maKH);
                hdb.ngayBan = CongCu.ChuanHoaMa(hdb.ngayBan);
              hdbDAL.Insert(hdb);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public HDBan LayHDBan(string mahdb)
        {
            HDBan hdb = null;
            foreach (HDBan hdban in hdbDAL.GetData())
            {
                if (hdban.maHDB == mahdb)
                {
                    hdb = new HDBan(hdban);
                    break;
                }
            }
            return hdb;
        }
        public void XoaHDBan(string mahdb)
        {
            if (KT_MaHDB(mahdb) == true)
                hdbDAL.Delete(mahdb);
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
            bool kt = false;
            foreach (HDBan hdban in hdbDAL.GetData())
                if (hdban.maHDB == mahdb)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public HDBan LayMaHDB(string mamv, string makh, string ngayban)
        {
            HDBan hdb = null;
            foreach (HDBan hdban in hdbDAL.GetData())
            {
                if (hdban.maNV == mamv && hdban.maKH == makh && hdban.ngayBan == ngayban)
                {
                    hdb = new HDBan(hdban);
                    break;
                }
            }
            return hdb;
        }
        public double TTien(string mahd)
        {
            HDBanDAL hdbDAL = new HDBanDAL();
            return hdbDAL.TongTien(mahd);
        }
    }
}
