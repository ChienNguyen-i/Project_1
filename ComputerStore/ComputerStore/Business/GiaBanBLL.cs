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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IGiaBanBLL
    public class GiaBanBLL : IGiaBanBLL
    {
        private IGiaBanDAL gbDAL = new GiaBanDAL();
        public List<GiaBan> LayDSGiaBan()
        {
            return gbDAL.GetData();
        }
        public void ThemGiaBan(GiaBan gb)
        {
            gbDAL.Insert(gb);
        }
        public GiaBan LayGiaBan(int magb)
        {
            int i;
            List<GiaBan> list = gbDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maGB == magb)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaGiaBan(int magb)
        {
            int i;
            List<GiaBan> list = gbDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maGB == magb)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                gbDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaGiaBan(GiaBan gb)
        {
            int i;
            List<GiaBan> list = gbDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maGB == gb.maGB)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(gb, i);
                gbDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại giá bán này.");
        }
        public List<GiaBan> TimGiaBan(GiaBan gb)
        {
            List<GiaBan> list = gbDAL.GetData();
            List<GiaBan> kq = new List<GiaBan>();
            if (gb.maGB == 0)
            {
                kq = list;
            }
            //Tìm theo mã
            if (gb.maGB != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maGB == gb.maGB)
                        kq.Add(new GiaBan(list[i]));
            }
            else
                kq = null;
            return kq;
        }
    }
}
