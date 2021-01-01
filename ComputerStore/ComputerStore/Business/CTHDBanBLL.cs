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
    public class CTHDBanBLL : ICTHDBanBLL
    {
        private ICTHDBanDAL cthdbDAL = new CTHDBanDAL();
        public List<CTHDBan> LayDS_CTHDBan()
        {
            return cthdbDAL.GetData();
        }
        public void ThemCTHDBan(CTHDBan cthdb)
        {
            if (cthdb.maHDB != "" && cthdb.maMT != "")
            {
                cthdb.maHDB = CongCu.ChuanHoaMa(cthdb.maHDB);
                cthdb.maMT = CongCu.ChuanHoaMa(cthdb.maMT);
                cthdbDAL.Insert(cthdb);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public List<CTHDBan> LayCTHDBan(CTHDBan cthdb)
        {
            List<CTHDBan> list = cthdbDAL.GetData();
            List<CTHDBan> kq = new List<CTHDBan>();
            if (cthdb.maHDB == null)
            {
                kq = list;
            }
            if (cthdb.maHDB != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maHDB == cthdb.maHDB)
                        kq.Add(new CTHDBan(list[i]));
            }
            else
                kq = null;
            return kq;
        }
        public void XoaCTHDBan(string mahdb)
        {
            if (KT_MaHDB(mahdb) == true)
                cthdbDAL.Delete(mahdb);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public bool KT_MaHDB(string mahdb)
        {
            bool kt = false;
            foreach (CTHDBan cthdban in cthdbDAL.GetData())
                if (cthdban.maHDB == mahdb)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
    }
}
