﻿using System;
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
        public void XoaNCC(string mancc)
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
            List<NCC> list = nccDAL.GetData();
            Node<NCC> tmp = list.Head;
            bool kt = false;
            while (tmp != null)
            {
                if (tmp.Info.maNCC == mancc)
                {
                    kt = true;
                    break;
                }
                else
                    tmp = tmp.Link;
            }
            return kt;
        }
        public bool KT_TenNCC(string tenncc)
        {
            List<NCC> list = nccDAL.GetData();
            Node<NCC> tmp = list.Head;
            bool kt = false;
            while (tmp != null)
            {
                if (tmp.Info.tenNCC == tenncc)
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
