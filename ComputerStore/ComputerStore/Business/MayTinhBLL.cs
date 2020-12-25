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
            if (mt.tenMT != "" && mt.maNCC != "")
            {
                mt.tenMT = CongCu.ChuanHoaXau(mt.tenMT);
                mt.maNCC = CongCu.CatXau(mt.maNCC.ToUpper());
                mtDAL.Insert(mt);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public MayTinh LayMayTinh(string mamt)
        {
            MayTinh mt = null;
            foreach (MayTinh maytinh in mtDAL.GetData())
            {
                if (maytinh.maMT == mamt)
                {
                    mt = new MayTinh(maytinh);
                    break;
                }
            }
            return mt;
        }
        public void XoaMayTinh(string mamt)
        {
            if (KT_MaMayTinh(mamt) == true)
                mtDAL.Delete(mamt);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaMayTinh(MayTinh mt)
        {
            if (KT_MaMayTinh(mt.maMT) == true)
                mtDAL.Update(mt);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public List<MayTinh> TimMayTinh(MayTinh mt)
        {
            List<MayTinh> list = mtDAL.GetData();
            List<MayTinh> kq = new List<MayTinh>();
            if (mt.maMT == null && mt.tenMT == null)
            {
                kq = list;
            }
            if (mt.tenMT != null && mt.maMT == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenMT.IndexOf(mt.tenMT) >= 0)
                        kq.Add(new MayTinh(list[i]));
            }
            else if (mt.tenMT == null && mt.maMT != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maMT == mt.maMT)
                        kq.Add(new MayTinh(list[i]));
            }
            else
                kq = null;
            return kq;
        }
        public bool KT_MaMayTinh(string mamt)
        {
            bool kt = false;
            foreach (MayTinh maytinh in mtDAL.GetData())
                if (maytinh.maMT == mamt)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public bool KT_TenMayTinh(string tenmt)
        {
            bool kt = false;
            foreach (MayTinh maytinh in mtDAL.GetData())
                if (maytinh.tenMT == tenmt || maytinh.tenMT.IndexOf(tenmt) >= 0)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public void TruSoLuong(MayTinh mt, int sl)
        {
            MayTinhDAL mt_DAL = new MayTinhDAL();
            if (KT_MaMayTinh(mt.maMT) == true)
                mt_DAL.Update_Sub(mt, sl);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void CongSoLuong(MayTinh mt, int sl)
        {
            MayTinhDAL mt_DAL = new MayTinhDAL();
            if (KT_MaMayTinh(mt.maMT) == true)
                mt_DAL.Update_Add(mt, sl);
            else
                throw new Exception("Không tồn tại mã này.");
        }
    }
}
