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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại IHDNhapBLL
    public class HDNhapBLL : IHDNhapBLL
    {
        private IHDNhapDAL hdnDAL = new HDNhapDAL();
        public List<HDNhap> LayDSHDNhap()
        {
            return hdnDAL.GetData();
        }
        public void ThemHDNhap(HDNhap hdn)
        {
            if (hdn.maNV != "" && hdn.maNCC != "" && hdn.maMT != "" && hdn.ngayNhap != "")
            {
                hdn.maNV = CongCu.CatXau(hdn.maNV);
                hdn.maNCC = CongCu.CatXau(hdn.maNCC);
                hdn.maMT = CongCu.CatXau(hdn.maMT);
                hdn.ngayNhap = CongCu.CatXau(hdn.ngayNhap);
                hdnDAL.Insert(hdn);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public HDNhap LayHDNhap(string mahdn)
        {
            int i;
            List<HDNhap> list = hdnDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maHDN == mahdn)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaHDNhap(string mahdn)
        {
            int i;
            List<HDNhap> list = hdnDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maHDN == mahdn)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                hdnDAL.Update(list);
            }
            else
                IO.Writexy("Không tồn tại mã hóa đơn nhập này....", 5, 6, ConsoleColor.Black, ConsoleColor.White);
        }
        public void SuaHDNhap(HDNhap hdn)
        {
            int i;
            List<HDNhap> list = hdnDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maHDN == hdn.maHDN)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(hdn, i);
                hdnDAL.Update(list);
            }
            else
                IO.Writexy("Không tồn tại hóa đơn nhập này...", 5, 8, ConsoleColor.Black, ConsoleColor.White);
        }
        public List<HDNhap> TimHDNhap(HDNhap hdn)
        {
            List<HDNhap> list = hdnDAL.GetData();
            List<HDNhap> kq = new List<HDNhap>();
            if (hdn.maHDN == null)
            {
                kq = list;
            }
            //Tìm theo mã
            if (hdn.maHDN != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maHDN == hdn.maHDN)
                        kq.Add(new HDNhap(list[i]));
            }
            else
                kq = null;
            return kq;
        }
    }
}
