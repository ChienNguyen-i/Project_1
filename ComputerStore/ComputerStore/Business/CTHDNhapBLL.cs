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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại ICTHDNhapBLL
    public class CTHDNhapBLL : ICTHDNhapBLL
    {
        private ICTHDNhapDAL cthdnDAL = new CTHDNhapDAL();
        public List<CTHDNhap> LayDSCTHDNhap()
        {
            return cthdnDAL.GetData();
        }
        public void ThemCTHDNhap(CTHDNhap cthdn)
        {

        }
        public CTHDNhap LayCTHDNhap(int macthdn)
        {
            int i;
            List<CTHDNhap> list = cthdnDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maCTHDN == macthdn)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaCTHDNhap(int macthdn)
        {
            int i;
            List<CTHDNhap> list = cthdnDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maCTHDN == macthdn)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                cthdnDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaCTHDNhap(CTHDNhap cthdn)
        {
            int i;
            List<CTHDNhap> list = cthdnDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maCTHDN == cthdn.maCTHDN)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(cthdn, i);
                cthdnDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại chi tiết hóa đơn nhập này.");
        }
        public List<CTHDNhap> TimCTHDNhap(CTHDNhap cthdn)
        {
            List<CTHDNhap> list = cthdnDAL.GetData();
            List<CTHDNhap> kq = new List<CTHDNhap>();
            if (cthdn.maCTHDN == 0)
            {
                kq = list;
            }
            //Tìm theo mã
            if (cthdn.maCTHDN != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maCTHDN == cthdn.maCTHDN)
                        kq.Add(new CTHDNhap(list[i]));
            }
            else
                kq = null;
            return kq;
        }
    }
}
