using System;
using System.Collections;
using System.Text;
using ComputerStore.Utility;
using ComputerStore.Entities;

namespace ComputerStore.Business.Interface
{
    //Xác định các yêu cầu nghiệp vụ của bài toán cần phải thực thi
    public interface ICTHDNhapBLL
    {
        List<CTHDNhap> LayDSCTHDNhap();
        void ThemCTHDNhap(CTHDNhap cthdn);
        void XoaCTHDNhap(int macthdn);
        void SuaCTHDNhap(CTHDNhap cthdn);
        List<CTHDNhap> TimCTHDNhap(CTHDNhap cthdn);
        CTHDNhap LayCTHDNhap(int macthdn);
    }
}
