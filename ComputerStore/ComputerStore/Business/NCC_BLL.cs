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
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại INCC_BLL
    public class NCC_BLL : INCC_BLL
    {
        private INCC_DAL nccDAL = new NCC_DAL();
        public List<NCC> LayDSNCC()
        {
            return nccDAL.GetData();
        }
        public void ThemNCC(NCC ncc)
        {
            if (ncc.tenNCC != "" && ncc.diaChi != "" && ncc.soDT != "")
            {
                ncc.tenNCC = ComputerStore.Utility.CongCu.ChuanHoaXau(ncc.tenNCC);
                ncc.diaChi = ComputerStore.Utility.CongCu.ChuanHoaXau(ncc.diaChi);
                ncc.soDT = ComputerStore.Utility.CongCu.CatXau(ncc.soDT);
                nccDAL.Insert(ncc);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public NCC LayNCC(int mancc)
        {
            int i;
            List<NCC> list = nccDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maNCC == mancc)
                    break;
            if (i < list.Count)
                return list[i];
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void XoaNCC(int mancc)
        {
            int i;
            List<NCC> list = nccDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maNCC == mancc)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                nccDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaNCC(NCC ncc)
        {
            int i;
            List<NCC> list = nccDAL.GetData();
            for (i = 0; i < list.Count; ++i)
                if (list[i].maNCC == ncc.maNCC)
                    break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(ncc, i);
                nccDAL.Update(list);
            }
            else
                throw new Exception("Không tồn tại nhà cung cấp này.");
        }
        public List<NCC> TimNCC(NCC ncc)
        {
            List<NCC> list = nccDAL.GetData();
            List<NCC> kq = new List<NCC>();
            if (ncc.maNCC == 0 && ncc.tenNCC == null)
            {
                kq = list;
            }
            //Tìm theo tên
            if (ncc.tenNCC != null && ncc.maNCC == 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenNCC.IndexOf(ncc.tenNCC) >= 0)
                        kq.Add(new NCC(list[i]));
            }
            //Tìm theo mã
            else if (ncc.tenNCC == null && ncc.maNCC != 0)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maNCC == ncc.maNCC)
                        kq.Add(new NCC(list[i]));
            }
            else
                kq = null;
            return kq;
        }
    }
}
