using ComputerStore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Business.Interface
{
    public interface ILoaiMayBLL
    {
        List<LoaiMay> LayDSLoaiMay();
        void ThemLoaiMay(LoaiMay lm);
        void SuaLoaiMay(LoaiMay lm);
        void XoaLoaiMay(string malm);
        List<LoaiMay> TimLoaiMay(LoaiMay lm);
        LoaiMay LayLoaiMay(string malm);
    }
}
