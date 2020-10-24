using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface ILoaiMayBLL
    {
        List<LoaiMay> LayDSLoaiMay();
        void ThemLoaiMay(LoaiMay lm);
        void XoaLoaiMay(int malm);
        void SuaLoaiMay(LoaiMay lm);
        List<LoaiMay> TimLoaiMay(LoaiMay lm);
        LoaiMay LayLoaiMay(int malm);
    }
}
