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
                ncc.tenNCC = CongCu.ChuanHoaXau(ncc.tenNCC);
                ncc.diaChi = CongCu.ChuanHoaXau(ncc.diaChi);
                ncc.soDT = CongCu.CatXau(ncc.soDT);
                nccDAL.Insert(ncc);
            }
            else
                throw new Exception("Dữ liệu sai.");
        }
        public NCC LayNCC(string mancc)
        {
            NCC ncc = null;
            foreach (NCC n in nccDAL.GetData())
            {
                if (n.maNCC == mancc)
                {
                    ncc = new NCC(n);
                    break;
                }
            }
            return ncc;
        }
        public void XoaNCC(string mancc)
        {
            if (KT_MaNCC(mancc) == true)
                nccDAL.Delete(mancc);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public void SuaNCC(NCC ncc)
        {
            if (KT_MaNCC(ncc.maNCC) == true)
                nccDAL.Update(ncc);
            else
                throw new Exception("Không tồn tại mã này.");
        }
        public List<NCC> TimNCC(NCC ncc)
        {
            List<NCC> list = nccDAL.GetData();
            List<NCC> kq = new List<NCC>();
            if (ncc.maNCC == null && ncc.tenNCC == null)
            {
                kq = list;
            }
            if (ncc.tenNCC != null && ncc.maNCC == null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].tenNCC.IndexOf(ncc.tenNCC) >= 0)
                        kq.Add(new NCC(list[i]));
            }
            else if (ncc.tenNCC == null && ncc.maNCC != null)
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].maNCC == ncc.maNCC)
                        kq.Add(new NCC(list[i]));
            }
            else
                kq = null;
            return kq;
        }
        public bool KT_MaNCC(string mancc)
        {
            bool kt = false;
            foreach (NCC ncc in nccDAL.GetData())
                if (ncc.maNCC == mancc)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
        public bool KT_TenNCC(string tenncc)
        {
            bool kt = false;
            foreach (NCC ncc in nccDAL.GetData())
                if (ncc.tenNCC == tenncc || ncc.tenNCC.IndexOf(tenncc) >= 0)
                {
                    kt = true;
                    break;
                }
            return kt;
        }
    }
}
