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
        public void XoaMayTinh(string mamt)
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
                throw new Exception("Không tồn tại mã này.");
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
            List<MayTinh> list = mtDAL.GetData();
            Node<MayTinh> tmp = list.Head;
            bool kt = false;
            while (tmp != null)
            {
                if (tmp.Info.maMT == mamt)
                {
                    kt = true;
                    break;
                }
                else
                    tmp = tmp.Link;
            }
            return kt;
        }
        public bool KT_TenMayTinh(string tenmt)
        {
            List<MayTinh> list = mtDAL.GetData();
            Node<MayTinh> tmp = list.Head;
            bool kt = false;
            while (tmp != null)
            {
                if (tmp.Info.tenMT == tenmt)
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
